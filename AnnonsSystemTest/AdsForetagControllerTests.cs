using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnnonsSystem.Controllers;
using AnnonsSystem.Entities;
using AnnonsSystem.Models;
using AnnonsSystem.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace AnnonsSystemTest 
{

    public class AdsForetagControllerTest : IDisposable
    {

        private TempDataDictionary tempData;
        private Mock<IAnnonsRepository> _repoMock { get; }
        private Mock<IMapper> _mapperMock { get;}
        private HttpContext httpContext { get; }
        private AdsForetagController adsController { get; }

        public AdsForetagControllerTest()
        {
            _repoMock = new Mock<IAnnonsRepository>();
            _mapperMock = new Mock<IMapper>();
            httpContext = new DefaultHttpContext();
            adsController = new AdsForetagController(_repoMock.Object, _mapperMock.Object);
            adsController.TempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
        }


        public void Dispose()
        {

        }



        [Fact]
        public async Task AdCreationAdInfo_ad_info_success()
        {
            //Arrange
            var AdInfo = Mock.Of<ForetagDto>();
            adsController.TempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            adsController.TempData["BadForetag"] = true;
            var expectedView = "AdCreationAdInfo";

            //Act
            var actionResult = await adsController.AdCreationAdInfo(AdInfo);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.IsAssignableFrom<AdForetagDto>(viewResult.ViewData.Model);
            Assert.True(viewResult.TempData["BadForetag"].Equals(false));
            Assert.Equal(expectedView, viewResult.ViewName);
        }

        [Fact]
        public async Task AdCreationAdInfo_invalid_model_badrequest()
        {
            //Arrange
            var AdInfo = new Mock<ForetagDto>();
            adsController.ModelState.AddModelError("errorkey", "errormessage");

            //Act
            var actionResult = await adsController.AdCreationAdInfo(AdInfo.Object);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void Create_stores_ad_in_repository()
        {
            //Arrange
            var adDtoMock = Mock.Of<AdDto>(c => c.PrisAnnons == 40);
            var adForetagMock = Mock.Of<AdForetagDto>(c => c.Ad == adDtoMock);
        
            _repoMock.Setup(c => c.CreateAd(It.IsAny<Ad>(), It.IsAny<ForetagAnnonsor>()));

            //Act
            var actionResult = adsController.Create(adForetagMock);

            //Assert
            // Verify Method was called once only
            _repoMock.Verify(c => c.CreateAd(It.IsAny<Ad>(), It.IsAny<ForetagAnnonsor>()), Times.Once());
        }

    }
}

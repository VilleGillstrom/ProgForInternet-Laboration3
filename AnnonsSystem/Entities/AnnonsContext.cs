using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AnnonsSystem.Entities
{
    public class AnnonsContext : DbContext
    {
    
        public AnnonsContext(DbContextOptions<AnnonsContext> options) : base(options)
        {
            Database.EnsureCreated(); /* Create database if not created */
        }
 
        public DbSet<Ad> Ads { get; set; }

        //These two becomes one table
        public DbSet<ForetagAnnonsor> ForetagAnnonsors { get; set; }
        public DbSet<PrenumerantAnnonsor> PrenumerantAnnonsors { get; set; }
    }
}

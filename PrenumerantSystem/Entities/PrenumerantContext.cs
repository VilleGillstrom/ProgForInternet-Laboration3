using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PrenumerantSystem.Entities;

namespace PrenumerantSystem.Controllers
{
    public class PrenumerantContext : DbContext
    {

        public DbSet<Prenumerant> Prenumerants { get; set; }

        public PrenumerantContext (DbContextOptions<PrenumerantContext> options)
            : base(options)
        {
            Database.EnsureCreated(); /* Create database if not created */
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* Ensure unique prenumerant number */
            builder.Entity<Prenumerant>()
                .HasIndex(p => p.PrenumerantNummer)
                .IsUnique();
        }

   
        /* Quick and dirty prenumerant number generation (not good at all, especially with many prenumerants) */
        public string GeneratePrenumerantNumber()
        {
            int num;
            string prenumerantNumber;
            Random rand = new Random();
            do
            {
                num = rand.Next(99999);
                prenumerantNumber = num.ToString("D5"); /* pad with zeros */

            } while (Prenumerants.Any(p => p.PrenumerantNummer == prenumerantNumber));

            return prenumerantNumber;
        }
    }
}

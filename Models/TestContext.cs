using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiEFTest.Models
{
    public class TestContext : IdentityDbContext<ApplicationUser>
    {
        public TestContext() : base("DefaultConnection") {}

        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Entity<Transfer>()
                .HasRequired<ApplicationUser>(t => t.FromUser)
                .WithMany()
                .HasForeignKey<string>(t => t.FromUserId);

            modelBuilder.Entity<Transfer>()
                .HasRequired<ApplicationUser>(t => t.ToUser)
                .WithMany()
                .HasForeignKey<string>(t => t.ToUserId);


            base.OnModelCreating(modelBuilder);
        }

    }

}
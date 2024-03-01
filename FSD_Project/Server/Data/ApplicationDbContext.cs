using System;
using FSD_Project.Server.Models;
using FSD_Project.Shared.Domain;
using Duende.IdentityServer.EntityFramework.Options;
using FSD_Project.Server.Models;
using FSD_Project.Shared.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CarRentalManagement.Server.Configurations.Entities;
using FSD_Project.Server.Configurations.Entities;

namespace FSD_Project.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<IncidentReport> Incidentreports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            
            builder.ApplyConfiguration(new DriverSeedConfiguration());
            builder.ApplyConfiguration(new BillSeedConfiguration());
            builder.ApplyConfiguration(new CustomerSeedConfiguration());
            builder.ApplyConfiguration(new FeedBackSeedConfiguration());
            builder.ApplyConfiguration(new IncidentSeedConfiguration());
            

            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());


        }
    }
}

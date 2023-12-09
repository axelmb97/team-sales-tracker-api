using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Domain;

namespace TeamSalesTracker.Infraestructure.Data.Contexts
{
    public class TeamSaleTrackerData : DbContext
    {
        private readonly IConfiguration _configuration;
        public TeamSaleTrackerData(DbContextOptions<TeamSaleTrackerData> options, IConfiguration configs ):base(options)
        {
            _configuration = configs;
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<IntervalTarget> IntervalTargets { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseNpgsql(_configuration["ConnectionStrings:SaleTrackerConnectioin"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new BranchConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new IntervalConfig());
            modelBuilder.ApplyConfiguration(new IntervalTargetConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SaleDetailConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
        }
    }
}

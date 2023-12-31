﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;
using TeamSalesTrackerApi.Models;

namespace TeamSalesTrackerApi.Data
{
    public class SalesTrackerDB:DbContext
    {
        public SalesTrackerDB(DbContextOptions<SalesTrackerDB> options): base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<IntervalTarget> IntervalTargets { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            var enumConverter = new EnumToStringConverter<IntervalState>();
            mb.Entity<Interval>()
                .Property(i => i.State)
                .HasConversion(enumConverter);
            mb.Entity<Branch>()
            .HasOne(b => b.Address)
            .WithOne(a => a.Branch)
            .HasForeignKey<Address>(a => a.BranchId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
   
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Domain;

namespace TeamSalesTracker.Infraestructure.Data
{
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("BRANCHES");
            builder.HasKey(b => b.BranchId);
            builder.HasOne(b => b.Address);
            builder
                .HasMany(b => b.Sales)
                .WithOne(b => b.Branch);
        }
    }
}

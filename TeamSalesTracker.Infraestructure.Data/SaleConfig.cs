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
    internal class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("SALES");
            builder.HasKey(s => s.SaleId);
            builder
                .HasOne(s => s.Interval)
                .WithMany(i => i.Sales);
            builder
               .HasOne(s => s.Branch)
               .WithMany(b => b.Sales);
            builder
                .HasMany(s => s.Details)
                .WithOne(d => d.Sale);
        }
    }
}

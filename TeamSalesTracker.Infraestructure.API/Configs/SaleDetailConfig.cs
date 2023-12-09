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
    internal class SaleDetailConfig : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("SALE_DETAILS");
            builder.HasKey(d => d.SaleDetailId);
            builder.HasOne(d => d.Product);
            builder
                .HasOne(d => d.Sale)
                .WithMany(s => s.Details);
        }
    }
}

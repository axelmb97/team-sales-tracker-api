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
    internal class IntervalTargetConfig : IEntityTypeConfiguration<IntervalTarget>
    {
        public void Configure(EntityTypeBuilder<IntervalTarget> builder)
        {
            builder.ToTable("INTERVAL_TARGETS");
            builder.HasKey(it => it.IntervalTargetId);
            builder.HasOne(it => it.Product);
            builder
                .HasOne(it => it.Interval)
                .WithMany(i => i.Targets);
                
        }
    }
}

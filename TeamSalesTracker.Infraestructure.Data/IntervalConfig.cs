using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Domain;

namespace TeamSalesTracker.Infraestructure.Data
{
    internal class IntervalConfig : IEntityTypeConfiguration<Interval>
    {
        public void Configure(EntityTypeBuilder<Interval> builder)
        {
            builder.ToTable("INTERVALS");
            builder.HasKey(i => i.IntervalId);
            builder
                .HasOne(i => i.User)
                .WithMany(u => u.Intervals);
            builder
                .HasMany(i => i.Targets)
                .WithOne(t => t.Interval);
            builder
                .HasMany(i => i.Sales)
                .WithOne(s => s.Interval);
            var enumConverter = new EnumToStringConverter<IntervalState>();
            builder
            .Property(i => i.State)
                .HasConversion(enumConverter);
        }
    }
}

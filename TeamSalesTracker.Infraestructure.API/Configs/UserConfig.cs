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
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS");
            builder.HasKey(user => user.UserId);
            builder.HasOne(u => u.Address);
            builder
                .HasMany(u => u.Intervals)
                .WithOne(i => i.User);
            builder
                .HasMany(u => u.Roles)
                .WithOne(us => us.User);
        }
    }
}

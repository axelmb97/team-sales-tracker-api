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
    internal class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("USER_ROLES");
            builder.HasKey(ur => ur.UserRoleId);
            builder
                .HasOne(ur => ur.User)
                .WithMany(u => u.Roles);
            builder
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles);
        }
    }
}

using Core.Entities.Base;
using Infastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infastructure.Extensions
{
    public static class CustomLinqExtensions
    {
        /// <summary>
        /// Renames AspNet Identity tables
        /// </summary>
        /// <param name="builder"></param>
        public static void RenameIdentityTables(this ModelBuilder builder)
        {
            builder.Entity<AppUser>(entity =>
            {
                entity.ToTable("User");
                entity.Property(_ => _.FirstName).IsRequired().HasColumnType("VARCHAR(100)");
                entity.Property(_ => _.LastName).IsRequired().HasColumnType("VARCHAR(100)");
                entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Role");
                entity.HasData(
                    new IdentityRole
                    { 
                        Name = "Visitor",
                        NormalizedName = "VISITOR"
                    },
                    new IdentityRole
                    {
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    }
                    );
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRole");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaim");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaim");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserToken");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogin");
            });
        }
        /// <summary>
        /// Set defalt constraint for id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        public static void SetDefaultConstraintForId<T>(this EntityTypeBuilder<T> builder)
            where T : BaseEntity
        {
            builder.Property(_ => _.Id).HasDefaultValueSql("NEWID()");
        }
    }
}

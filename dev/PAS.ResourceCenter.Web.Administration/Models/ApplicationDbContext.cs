#region Using

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#endregion

namespace PAS.ResourceCenter.Web.Administration.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Update default ASP.NET Identity table names
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.Id).HasColumnName("Id");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.Email).HasColumnName("email");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.EmailConfirmed).HasColumnName("emailConfirmed");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.PasswordHash).HasColumnName("passwordHash");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.SecurityStamp).HasColumnName("securityStamp");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.PhoneNumber).HasColumnName("phoneNumber");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.PhoneNumberConfirmed).HasColumnName("phoneNumberConfirmed");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.TwoFactorEnabled).HasColumnName("twoFactorEnabled");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.LockoutEnabled).HasColumnName("lockoutEnabled");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.AccessFailedCount).HasColumnName("accessFailedCount");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.UserName).HasColumnName("userName");
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.LastName).HasColumnName("lastName").IsRequired();
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.FirstName).HasColumnName("firstName").IsRequired();
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.MiddleName).HasColumnName("middleName").IsRequired();
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.Title).HasColumnName("title").IsRequired();
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.IsEnabled).HasColumnName("isEnabled").IsRequired();
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.DateCreated).HasColumnName("dateCreated").IsRequired();
            builder.Entity<ApplicationUser>().ToTable("users").Property(p => p.LastUpdated).HasColumnName("lastUpdated").IsRequired();

            builder.Entity<IdentityRole>().ToTable("roles").Property(p => p.Id).HasColumnName("Id");
            builder.Entity<IdentityRole>().ToTable("roles").Property(p => p.Name).HasColumnName("name");

            builder.Entity<IdentityRoleClaim<string>>().ToTable("roleClaims").Property(p => p.Id).HasColumnName("Id");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("roleClaims").Property(p => p.ClaimType).HasColumnName("claimType");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("roleClaims").Property(p => p.ClaimValue).HasColumnName("claimValue");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("roleClaims").Property(p => p.RoleId).HasColumnName("roleId");

            builder.Entity<IdentityUserClaim<string>>().ToTable("userClaims").Property(p => p.Id).HasColumnName("Id");
            builder.Entity<IdentityUserClaim<string>>().ToTable("userClaims").Property(p => p.UserId).HasColumnName("userId");
            builder.Entity<IdentityUserClaim<string>>().ToTable("userClaims").Property(p => p.ClaimType).HasColumnName("claimType");
            builder.Entity<IdentityUserClaim<string>>().ToTable("userClaims").Property(p => p.ClaimValue).HasColumnName("claimValue");

            builder.Entity<IdentityUserLogin<string>>().ToTable("userLogins").Property(p => p.LoginProvider).HasColumnName("loginProvider");
            builder.Entity<IdentityUserLogin<string>>().ToTable("userLogins").Property(p => p.ProviderKey).HasColumnName("providerKey");
            builder.Entity<IdentityUserLogin<string>>().ToTable("userLogins").Property(p => p.UserId).HasColumnName("userId");

            builder.Entity<IdentityUserRole<string>>().ToTable("userRoles").Property(p => p.UserId).HasColumnName("userId");
            builder.Entity<IdentityUserRole<string>>().ToTable("userRoles").Property(p => p.RoleId).HasColumnName("roleId");
        }
    }
}
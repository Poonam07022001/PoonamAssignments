
using BankApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(

                new ApplicationUser
                {
                    Id = "41776062-6086-1fbf-b923-7879a6680b9a",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    FirstName = "Admin",
                    LastName = "System",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123")

                },
                new ApplicationUser
                {
                    Id = "71776062-6086-1fcf-b923-2879a6680b7a",
                    Email = "poonam@gmail.com",
                    NormalizedEmail = "POONAM@GMAIL.COM",
                    FirstName = "Poonam",
                    LastName = "Suryavanshi",
                    UserName = "poonam@gmail.com",
                    NormalizedUserName = "POONAM@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Poonam@123")
                }
                );
        }
    }
}
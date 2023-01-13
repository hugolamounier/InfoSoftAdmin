using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfoSoftAdmin.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR".ToUpper()
        });
        
        var hasher = new PasswordHasher<IdentityUser?>();
        
        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                Email = "admin@admin.com",
                UserName = "admin",
                NormalizedUserName = "Admin",
                PasswordHash = hasher.HashPassword(null, "Admin123!")
            }
        );
        
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            }
        );
    }
}
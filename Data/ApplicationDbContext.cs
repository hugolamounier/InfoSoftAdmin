using InfoSoftAdmin.Models;
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

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Email).IsRequired();
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Phone).IsRequired();
        });
    }

    public DbSet<InfoSoftAdmin.Models.Customer>? Customer { get; set; }
}
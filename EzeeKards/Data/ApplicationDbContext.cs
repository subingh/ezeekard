using EzeeKard.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EzeeKards.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<ExtraInfo> ExtraInfo { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            // Configure relationships
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Companies)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExtraInfo>()
                .HasOne(e => e.Client)
                .WithMany(c => c.ExtraInfos)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExtraInfo>()
                .HasOne(e => e.Company)
                .WithMany(c => c.ExtraInfos)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ClientName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ClientId).IsRequired();
            });

            modelBuilder.Entity<ExtraInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ClientId).IsRequired();
                entity.Property(e => e.CompanyId).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(10);
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SocialMedia>().HasData(
                new SocialMedia { Id = 1, SocialMediaName = "Facebook", LogoUrl = "" },
                new SocialMedia { Id = 2, SocialMediaName = "Instagram", LogoUrl = "" },
                new SocialMedia { Id = 3, SocialMediaName = "Viber", LogoUrl = "" },
                new SocialMedia { Id = 4, SocialMediaName = "Whatsapp", LogoUrl = "" },
                new SocialMedia { Id = 5, SocialMediaName = "Twitter", LogoUrl = "" },
                new SocialMedia { Id = 6, SocialMediaName = "LinkedIn", LogoUrl = "" }
                );
        }
    }
}

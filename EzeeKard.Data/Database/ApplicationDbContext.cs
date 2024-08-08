using EzeeKards.Data.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace EzeeKards.Data.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// DbSet files for Client
        /// Stores information of client
        /// </summary>
        public DbSet<Client> Client { get; set; }

        /// <summary>
        /// DbSet files for Company
        /// Stores information of Client's company
        /// </summary>
        public DbSet<Company> Company { get; set; }

        /// <summary>
        /// DbSet files for Client's ExtraInfo
        /// Stores extra infos of Client
        /// </summary>
        public DbSet<ClientExtraInfo> ClientExtraInfo { get; set; }

        /// <summary>
        /// DbSet files for SocialMedia
        /// Stores SocialMedias details
        /// </summary>
        public DbSet<SocialMedia> SocialMedia { get; set; }

        /// <summary>
        /// DbSet files for Error
        /// Stores information of Errors
        /// </summary>
        public DbSet<Error> Error { get; set; }

        /// <summary>
        /// DbSet files for Company's ExtraInfo
        /// Stores extra infos of company
        /// </summary>
        public DbSet<CompanyExtraInfo> CompanyExtraInfo { get; set; }

        /// <summary>
        /// DbSet files for AllClientDetails
        /// To fetch data from all tables
        /// </summary>
        public DbSet<AllClientDetails> AllClientDetails { get; set; }

        /// <summary>
        /// Database creation and SQL connection
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            // Configure relationships
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Companies)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClientExtraInfo>()
                .HasOne(e => e.Client)
                .WithMany(c => c.ClientExtraInfos)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompanyExtraInfo>()
                .HasOne(e => e.Company)
                .WithMany(c => c.CompanyExtraInfos)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId);
                entity.Property(e => e.ClientName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyId);
                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ClientId).IsRequired();
            });

            modelBuilder.Entity<ClientExtraInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ClientId).IsRequired();
                entity.Property(e => e.CCountry).IsRequired(false);
                entity.Property(e => e.CState).IsRequired(false);
                entity.Property(e => e.CCity).IsRequired(false);
                entity.Property(e => e.CStreet).IsRequired(false);
                entity.Property(e => e.CMapUrl).IsRequired(false);
                entity.Property(e => e.CEmail).IsRequired(false);
                entity.Property(e => e.CWebsite).IsRequired(false);
                entity.Property(e =>e. CDescription).IsRequired(false);
                entity.Property(e => e.CSocialMedias).IsRequired(false);
                entity.Property(e => e.CPhoneNumber).IsRequired(false).HasMaxLength(10);
            });

            modelBuilder.Entity<CompanyExtraInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CompanyId).IsRequired();
                entity.Property(e => e.Designation).IsRequired(false);
                entity.Property(e => e.Country).IsRequired(false);
                entity.Property(e => e.State).IsRequired(false);
                entity.Property(e => e.City).IsRequired(false);
                entity.Property(e => e.Street).IsRequired(false);
                entity.Property(e => e.MapUrl).IsRequired(false);
                entity.Property(e => e.Email).IsRequired(false);
                entity.Property(e => e.Website).IsRequired(false);
                entity.Property(e => e.Description).IsRequired(false);
                entity.Property(e => e.SocialMedias).IsRequired(false);
                entity.Property(e => e.PhoneNumber).IsRequired(false).HasMaxLength(10);
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

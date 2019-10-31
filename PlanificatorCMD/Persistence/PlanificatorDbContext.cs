using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlanificatorCMD.Persistence
{
    public class PlanificatorDbContext : DbContext
    {
        public DbSet<SpeakerProfile> SpeakerProfiles { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(@configuration.GetConnectionString("Default"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerProfile>()
                    .Property(s => s.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();
            modelBuilder.Entity<SpeakerProfile>()
                    .Property(s => s.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
            modelBuilder.Entity<SpeakerProfile>()
                    .Property(s => s.Email)
                    .HasMaxLength(255)
                    .IsRequired();
            modelBuilder.Entity<SpeakerProfile>()
                    .Property(s => s.Bio)
                    .HasMaxLength(100)
                    .IsRequired();
            modelBuilder.Entity<SpeakerProfile>()
                    .Property(s => s.Company)
                    .HasMaxLength(60)
                    .IsRequired(false);
        }
        
    }
}

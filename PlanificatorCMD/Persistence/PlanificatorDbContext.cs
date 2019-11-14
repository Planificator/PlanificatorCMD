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
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PresentationTag> PresentationTags { get; set; }
        public DbSet<PresentationSpeaker> PresentationSpeakers { get; set; }

        public PlanificatorDbContext(DbContextOptions<PlanificatorDbContext> options)
        : base(options)
        {
        }

        public PlanificatorDbContext()
        {               
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(@configuration.GetConnectionString("Default"));
            }

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

            modelBuilder.Entity<Presentation>()
                .Property(s => s.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Presentation>()
                .Property(s => s.ShortDescription)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Presentation>()
                .Property(s => s.LongDescription)
                .HasMaxLength(800)
                .IsRequired();

            modelBuilder.Entity<Tag>()
                .Property(s => s.TagName)
                .HasMaxLength(50)
                .IsRequired();

            //PresentationTag Many to Many Configuration
            modelBuilder.Entity<PresentationTag>().HasKey(pt => new { pt.PresentationId, pt.TagId });

            modelBuilder.Entity<PresentationTag>()
                .HasOne<Presentation>(pt => pt.Presentation)
                .WithMany(p => p.PresentationTags)
                .HasForeignKey(pt => pt.PresentationId);

            modelBuilder.Entity<PresentationTag>()
                .HasOne<Tag>(pt => pt.Tag)
                .WithMany(t => t.PresentationTags)
                .HasForeignKey(pt => pt.TagId);

            //PresentationSpeaker Many to Many Configuration
            modelBuilder.Entity<PresentationSpeaker>().HasKey(pt => new { pt.PresentationId, pt.SpeakerId });

            modelBuilder.Entity<PresentationSpeaker>()
                .HasOne<Presentation>(pt => pt.Presentation)
                .WithMany(p => p.PresentationSpeakers)
                .HasForeignKey(pt => pt.PresentationId);

            modelBuilder.Entity<PresentationSpeaker>()
                .HasOne<SpeakerProfile>(pt => pt.SpeakerProfile)
                .WithMany(t => t.PresentationSpeakers)
                .HasForeignKey(pt => pt.SpeakerId);

            //Presentation with Speaker Ownership Many to One
            modelBuilder.Entity<Presentation>()
                .HasOne<SpeakerProfile>(p => p.PresentationOwner)
                .WithMany(s => s.OwnedPresentations);

            modelBuilder.Entity<SpeakerProfile>()
                .HasMany<Presentation>(s => s.OwnedPresentations)
                .WithOne(p => p.PresentationOwner);
        }     
    }
}

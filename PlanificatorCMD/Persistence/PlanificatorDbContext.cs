using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlanificatorCMD.Persistence
{
    class PlanificatorDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(@configuration.GetConnectionString("Default"));

        }

        public DbSet<SpeakerProfile> SpeakerProfiles { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}

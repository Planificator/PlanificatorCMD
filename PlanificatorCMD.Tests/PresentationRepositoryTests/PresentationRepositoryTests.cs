using PlanificatorCMD.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using PlanificatorCMD.Core;
using System.Collections.Generic;

namespace PlanificatorCMD.Tests.PresentationRepositoryTests
{
    public class PresentationRepositoryTests
    {
        [Fact]
        public void AddPresentation_writes_to_database()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new PresentationRepository(context);
                    var testData = new PresentationRepositoryTestsData();

                    service.AddPresentation(testData.presentationTags);

                    context.SaveChanges();

                    List<string> tagsNames = testData.tags.Select(tag => tag.TagName).ToList();

                    Assert.Equal(tagsNames.Count, service.GetAllTagsNames(testData.presentation.PresentationId).Count);
                    Assert.Equal(tagsNames, service.GetAllTagsNames(testData.presentation.PresentationId));

                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GetAllTags_returns_all_tags_from_one_presentation()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new PresentationRepository(context);
                    var testData = new PresentationRepositoryTestsData();

                    service.AddPresentation(testData.presentationTags);

                    context.SaveChanges();

                    Assert.Equal(testData.presentationTags.Count(), context.PresentationTags.Count());
                    Assert.Equal(1, context.Presentations.Count());
                    Assert.Equal(testData.tags.Count(), context.Tags.Count());

                    Assert.Equal(testData.presentationTags, context.PresentationTags);
                    Assert.Equal(testData.presentation.ToString(), context.Presentations.Single().ToString());
                    Assert.Equal(testData.tags, context.Tags);

                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GetAllTags_returns_null_if_thereAreNoTags()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new PresentationRepository(context);

                    Assert.Null(service.GetAllTagsNames(0));
                    Assert.Null(service.GetAllTagsNames(1));
                    Assert.Null(service.GetAllTagsNames(2));
                    Assert.Null(service.GetAllTagsNames(3));

                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GetAllPresentations_returns_null_if_thereAreNoPresentations()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new PresentationRepository(context);

                    Assert.Null(service.GetAllPresentations());

                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GetAllPresentations_returns_all_presentations()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new PresentationRepository(context);

                    var testData1 = new PresentationRepositoryTestsData();
                    var testData2 = new PresentationRepositoryTestsData();
                    var testData3 = new PresentationRepositoryTestsData();

                    List<Presentation> presentations = new List<Presentation>();
                    presentations.Add(testData1.presentation);
                    presentations.Add(testData2.presentation);
                    presentations.Add(testData3.presentation);


                    service.AddPresentation(testData1.presentationTags);
                    service.AddPresentation(testData2.presentationTags);
                    service.AddPresentation(testData3.presentationTags);

                    context.SaveChanges();

                    Assert.Equal(context.Presentations.Count(), service.GetAllPresentations().Count);
                    Assert.Equal(presentations, service.GetAllPresentations());

                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GetPresentationsCount_returns_presentations_count()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new PresentationRepository(context);

                    var testData1 = new PresentationRepositoryTestsData();
                    var testData2 = new PresentationRepositoryTestsData();
                    var testData3 = new PresentationRepositoryTestsData();

                    List<Presentation> presentations = new List<Presentation>();
                    presentations.Add(testData1.presentation);
                    presentations.Add(testData2.presentation);
                    presentations.Add(testData3.presentation);


                    service.AddPresentation(testData1.presentationTags);
                    service.AddPresentation(testData2.presentationTags);
                    service.AddPresentation(testData3.presentationTags);

                    context.SaveChanges();

                    Assert.Equal(presentations.Count(), service.GetPresentationCount());

                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void AssignSpeakerToPresentation_writes_to_database()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            SpeakerProfile speaker = new SpeakerProfile
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "test@email.net",
                Bio = "My test bio",
                Company = "Test company",
                Photo = new Photo { Path = "Test Path" }
            };


            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var presentationService = new PresentationRepository(context);
                    var speakerServie = new SpeakerRepository(context);

                    var testData = new PresentationRepositoryTestsData();

                    speakerServie.AddSpeakerProfile(speaker);
                    presentationService.AddPresentation(testData.presentationTags);
                    presentationService.AssignSpeakerToPresentation(speaker, 0);

                    context.SaveChanges();

                    Assert.Equal(1, context.SpeakerProfiles.Count());
                    Assert.Equal(1, context.Presentations.Count());
                    Assert.Equal(1, context.PresentationSpeakers.Count());
                    Assert.Equal(speaker, context.PresentationSpeakers.Include(p => p.SpeakerProfile).Single().SpeakerProfile);
                    Assert.Equal(testData.presentation, context.PresentationSpeakers.Include(p => p.Presentation).Single().Presentation);

                }
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
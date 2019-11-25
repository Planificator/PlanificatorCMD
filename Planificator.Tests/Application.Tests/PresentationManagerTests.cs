using Application.Managers;
using Domain.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistence;
using Planificator.Tests.PresentationTestData;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    public class PresentationManagerTests
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

                    var service = new PresentationManager(context);
                    var query = new PresentationRepository(context);

                    var testData = new PresentationRepositoryTestsData();

                    service.AddPresentation(testData.presentationTags);

                    context.SaveChanges();

                    List<string> tagsNames = testData.tags.Select(tag => tag.TagName).ToList();

                    Assert.Equal(tagsNames.Count, query.GetAllTagsNames(testData.presentation.PresentationId).Count);
                    Assert.Equal(tagsNames, query.GetAllTagsNames(testData.presentation.PresentationId));
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

                    var presentationService = new PresentationManager(context);
                    var speakerServie = new SpeakerManager(context);

                    var testData = new PresentationRepositoryTestsData();

                    speakerServie.AddSpeakerProfile(speaker);
                    presentationService.AddPresentation(testData.presentationTags);
                    presentationService.AssignSpeakerToPresentation(speaker, testData.presentation);

                    context.SaveChanges();

                    Assert.Equal(1, context.PresentationSpeakers.Count());
                    Assert.Equal(speaker, context.PresentationSpeakers.Single().SpeakerProfile);
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
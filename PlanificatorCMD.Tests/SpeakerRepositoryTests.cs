using PlanificatorCMD.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Tests
{
    public class SpeakerRepositoryTests
    {
        [Theory]
        [InlineData("Test Company")]
        [InlineData(null)]
        public void AddSpeakerProfile_writes_to_database_WithAndWithout_NotRequiredField(string company)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var testSpeakerProfile = new SpeakerProfile
            {
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = company,
                Photo = new Photo { Path = "testPath.jpg" }
            };

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new PlanificatorDbContext(options))
                {
                    var service = new SpeakerRepository(context);
                    service.AddSpeakerProfile(testSpeakerProfile);
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new PlanificatorDbContext(options))
                {
                    Assert.Equal(1, context.SpeakerProfiles.Count());
                    Assert.Equal(testSpeakerProfile.ToString(), context.SpeakerProfiles.Single().ToString());
                }
            }
            finally
            {
                connection.Close();
            }
        }


        [Theory]
        [InlineData("Jhon","Seed","jhon.seed@gmail.com",null)]
        [InlineData("Jhon", "Seed", "jhon.seed@gmail.com", null)]
        public void AddSpeakerProfile_writing_to_database_Fails_If_RequiredFields_AreNull
            (string firstName, string lastName, string email, Photo photo)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var testSpeakerProfile = new SpeakerProfile
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                //Bio = bio,
                Photo = photo
            };

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new PlanificatorDbContext(options))
                {
                    var service = new SpeakerRepository(context);
                    service.AddSpeakerProfile(testSpeakerProfile);
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new PlanificatorDbContext(options))
                {
                    Assert.Equal(1, context.SpeakerProfiles.Count());
                    //Assert.Equal(null, context.SpeakerProfiles.Single().ToString());
                    Assert.Null(context.SpeakerProfiles.Single().ToString());
                }
            }
            finally
            {
                connection.Close();
            }
        }

    }
}

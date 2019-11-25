using Application.Managers;
using Domain.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistence;
using System.Linq;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class SpeakerManagerTests
    {
        [Theory]
        [InlineData("Test Company")]
        [InlineData(null)]
        public void AddSpeakerProfile_writes_to_database_WithAndWithout_NotRequiredField(string company)
        {
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

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new SpeakerManager(context);
                    service.AddSpeakerProfile(testSpeakerProfile);
                    context.SaveChanges();

                    Assert.Equal(1, context.SpeakerProfiles.Count());
                    Assert.Equal(testSpeakerProfile.ToString(), context.SpeakerProfiles.Single().ToString());
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
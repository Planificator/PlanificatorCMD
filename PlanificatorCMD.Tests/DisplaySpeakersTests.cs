using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using PlanificatorCMD.Core;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Wrappers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class DisplaySpeakersTests
    {
        [Fact]
        public void DisplayAllSpeakers_ReturnsFail_WithNoSpeakers()
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
                    var cw = new Mock<IConsoleWrapper>();
                    var expected = ExecutionResult.Fail;

                    bool displayOption = true;

                    var sut = new DisplaySpeakers(context, cw.Object);
                    var actual = sut.DisplayAllSpeakers(displayOption);


                    Assert.Equal(actual, expected);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void DisplayAllSpeakers_ReturnsSuccess_WithValidSpeakersList()
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
                    var cw = new Mock<IConsoleWrapper>();
                    var expected = ExecutionResult.Succes;
                    var displayOption = true;

                    var service = new DisplaySpeakers(context, cw.Object);
                    List<SpeakerProfile> speakers = new List<SpeakerProfile>() {
                        new SpeakerProfile()
                        {
                          FirstName = "Vasily",
                         LastName = "Pascal",
                          Bio = "I'm .NET intern",
                          Email = "vasilypascal@gmail.com",
                          Company = "Endava",
                          Photo = new Photo
                          {
                              Path = @"...\something\13.jpg"
                          }}, new SpeakerProfile(){ FirstName = "Valentin",
                          LastName = "Butnaru",
                          Bio = "I'm .NET intern",
                          Email = "valentin@gmail.com",
                          Company = "Endava",
                          Photo = new Photo
                          {
                              Path = @"...\something\14.jpg"
                          }} };

                    context.SpeakerProfiles.AddRange(speakers);
                    context.SaveChanges();

                    var actual = service.DisplayAllSpeakers(displayOption);

                    Assert.Equal(expected, actual);

                    Assert.Equal(speakers.Count(), context.SpeakerProfiles.Count());
                    Assert.Equal(2, context.SpeakerProfiles.Count());
                    Assert.Equal(speakers, context.SpeakerProfiles.ToList());
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void DisplayAllSpeakers_WriteLineMethodIsCalledOnce_WithNoSpeakersList()
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
                    var cw = new Mock<IConsoleWrapper>();
                    var expected = ExecutionResult.Fail;
                    var displayOption = true;

                    var service = new DisplaySpeakers(context, cw.Object);

                    var actual = service.DisplayAllSpeakers(displayOption);

                    cw.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once);
                    Assert.Equal(expected, actual);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void DisplayAllSpeakers_WriteLineMethodIsCalledManyTimes_WithValidSpeakersList()
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
                    var cw = new Mock<IConsoleWrapper>();
                    var expected = ExecutionResult.Succes;
                    var displayoptions = true;

                    var service = new DisplaySpeakers(context, cw.Object);

                    List<SpeakerProfile> speakers = new List<SpeakerProfile>() {
                        new SpeakerProfile()
                        {
                          FirstName = "Vasily",
                         LastName = "Pascal",
                          Bio = "I'm .NET intern",
                          Email = "vasilypascal@gmail.com",
                          Company = "Endava",
                          Photo = new Photo
                          {
                              Path = @"...\something\13.jpg"
                          }}, new SpeakerProfile(){ FirstName = "Valentin",
                          LastName = "Butnaru",
                          Bio = "I'm .NET intern",
                          Email = "valentin@gmail.com",
                          Company = "Endava",
                          Photo = new Photo
                          {
                              Path = @"...\something\14.jpg"
                          }} };

                    context.SpeakerProfiles.AddRange(speakers);
                    context.SaveChanges();

                    var actual = service.DisplayAllSpeakers(displayoptions);

                    Assert.Equal(expected, actual);
                    cw.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(context.SpeakerProfiles.Count()));
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
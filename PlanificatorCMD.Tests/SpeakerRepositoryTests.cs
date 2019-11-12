using PlanificatorCMD.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using PlanificatorCMD.Core;
using System.Collections.Generic;

namespace PlanificatorCMD.Tests
{
    public class SpeakerRepositoryTests
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


                    var service = new SpeakerRepository(context);
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

        [Fact]
        public void GetMaxId_ReturnsZero_IfSpeakerProfileEntity_IsEmpty()
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


                    var service = new SpeakerRepository(context);


                    Assert.Equal(0, service.GetMaxId());
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GetMaxId_findes_max_id()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            List<SpeakerProfile> speakerProfiles = new List<SpeakerProfile>
            {
                new SpeakerProfile
                {
                    FirstName = "Test FN",
                    LastName = "Test LN",
                    Email = "test@test.test",
                    Bio = "Test Bio",
                    Company = "Test Compnay",
                    Photo = new Photo { Path = "testPath.jpg" }
                },
                new SpeakerProfile
                {
                    FirstName = "Test2 FN",
                    LastName = "Test2 LN",
                    Email = "test2@test.test",
                    Bio = "Test2 Bio",
                    Company = "Test2 Compnay",
                    Photo = new Photo { Path = "test2Path.jpg" }
                }
            };

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();
                    var service = new SpeakerRepository(context);

                    foreach (SpeakerProfile speakerProfile in speakerProfiles)
                    {
                        service.AddSpeakerProfile(speakerProfile);
                    }

                    context.SaveChanges();
                    Assert.Equal(speakerProfiles.Count(), service.GetMaxId());
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GetAllSpeakerProfile_returns_all_speaker_profiles()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            List<SpeakerProfile> speakerProfiles = new List<SpeakerProfile>
            {
                new SpeakerProfile
                {
                    FirstName = "Test FN",
                    LastName = "Test LN",
                    Email = "test@test.test",
                    Bio = "Test Bio",
                    Company = "Test Compnay",
                    Photo = new Photo { Path = "testPath.jpg" }
                },
                new SpeakerProfile
                {
                    FirstName = "Test2 FN",
                    LastName = "Test2 LN",
                    Email = "test2@test.test",
                    Bio = "Test2 Bio",
                    Company = "Test2 Compnay",
                    Photo = new Photo { Path = "test2Path.jpg" }
                }
            };

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new SpeakerRepository(context);

                    foreach (SpeakerProfile speakerProfile in speakerProfiles)
                    {
                        service.AddSpeakerProfile(speakerProfile);
                    }

                    context.SaveChanges();
                    Assert.Equal(speakerProfiles, service.GetAllSpeakersProfiles());
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GetAllSpeakerProfile_ReturnsNull_IfSpeakerProfileEntity_IsEmpty()
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


                    var service = new SpeakerRepository(context);


                    Assert.Null(service.GetAllSpeakersProfiles());
                }
            }
            finally
            {
                connection.Close();
            }
        }

        //[Fact]
        //public void GetAllSpeakerProfile_returns_all_speaker_profiles()
        //{
        //    var connection = new SqliteConnection("DataSource=:memory:");
        //    connection.Open();

        //    List<SpeakerProfile> speakerProfiles = new List<SpeakerProfile>
        //    {
        //        new SpeakerProfile
        //        {
        //            FirstName = "Test FN",
        //            LastName = "Test LN",
        //            Email = "test@test.test",
        //            Bio = "Test Bio",
        //            Company = "Test Compnay",
        //            Photo = new Photo { Path = "testPath.jpg" }
        //        },
        //        new SpeakerProfile
        //        {
        //            FirstName = "Test2 FN",
        //            LastName = "Test2 LN",
        //            Email = "test2@test.test",
        //            Bio = "Test2 Bio",
        //            Company = "Test2 Compnay",
        //            Photo = new Photo { Path = "test2Path.jpg" }
        //        }
        //    };

        //    try
        //    {
        //        var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
        //            .UseSqlite(connection)
        //            .Options;

        //        using (var context = new PlanificatorDbContext(options))
        //        {
        //            context.Database.EnsureCreated();

        //            var service = new SpeakerRepository(context);

        //            foreach (SpeakerProfile speakerProfile in speakerProfiles)
        //            {
        //                service.AddSpeakerProfile(speakerProfile);
        //            }

        //            context.SaveChanges();

        //            Assert.Equal(speakerProfiles, service.GetAllSpeakersProfiles());
        //        }
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        //[Fact]
        //public void GetAllSpeakerProfile_ReturnsNull_IfSpeakerProfileEntity_IsEmpty()
        //{
        //    var connection = new SqliteConnection("DataSource=:memory:");
        //    connection.Open();


        //    try
        //    {
        //        var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
        //            .UseSqlite(connection)
        //            .Options;

        //        using (var context = new PlanificatorDbContext(options))
        //        {
        //            context.Database.EnsureCreated();

        //            var service = new SpeakerRepository(context);

        //            Assert.Null(service.GetAllSpeakersProfiles());
        //        }
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}


    }
}





































using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Tests.PresentationRepositoryTests;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Wrappers;
using System.Linq;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class DisplayPresentationsTests
    {
        [Fact]
        public void ShowAllPresentations_ReturnsFail_WithNoPresentations()
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

                    var service = new DisplayPresentations(context, cw.Object);

                    var actual = service.ShowAllPresentations(true);

                    Assert.Equal(expected, actual);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void ShowAllPresentation_ReturnsSuccess_WithValidPresentations()
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

                    var service = new DisplayPresentations(context, cw.Object);

                    var testData = new PresentationRepositoryTestsData();
                    context.PresentationTags.AddRange(testData.presentationTags);
                    context.SaveChanges();

                    var actual = service.ShowAllPresentations(true);

                    Assert.Equal(expected, actual);

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
        public void ShowAllPresentation_WriteLineMethodIsCalledOnce_WithNoPresentations()
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

                    var service = new DisplayPresentations(context, cw.Object);

                    var actual = service.ShowAllPresentations(true);

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
        public void ShowAllPresentation_WriteLineMethodIsCalledManyTimes_WithValidPresentations()
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

                    var service = new DisplayPresentations(context, cw.Object);

                    var testData = new PresentationRepositoryTestsData();
                    context.PresentationTags.AddRange(testData.presentationTags);
                    context.SaveChanges();

                    var actual = service.ShowAllPresentations(true);

                    Assert.Equal(expected, actual);
                    cw.Verify(c => c.WriteLine(), Times.Exactly(2 + context.Presentations.Count()));
                    cw.Verify(c => c.Write(It.IsAny<string>()), Times.Exactly(context.Presentations.Count() + context.Tags.Count()));
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
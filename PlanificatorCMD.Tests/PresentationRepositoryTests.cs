using PlanificatorCMD.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using PlanificatorCMD.Core;
using System.Collections.Generic;


namespace PlanificatorCMD.Tests
{
    public class PresentationRepositoryTests
    {
        [Fact]
        public void AddPresentation_writes_to_database()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            List<Tag> tags = new List<Tag>()
            {
                new Tag { TagName = "AA" },
                new Tag { TagName = "BB" },
                new Tag { TagName = "CC" }
            };

            Presentation presentation = new Presentation
            {
                Title = "Test", 
                LongDescription = "Test" , 
                ShortDescription = "Test"
            };

            List<PresentationTag> presentationTags = new List<PresentationTag>();

            foreach(Tag tag in tags)
            {
                presentationTags.Add(new PresentationTag { Tag = tag, Presentation = presentation });
            }

            try
            {
                var options = new DbContextOptionsBuilder<PlanificatorDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new PlanificatorDbContext(options))
                {
                    context.Database.EnsureCreated();

                    var service = new PresentationRepository(context);

                    service.AddPresentation(presentationTags);

                    context.SaveChanges();

                    Assert.Equal(presentationTags.Count(), context.PresentationTags.Count());
                    Assert.Equal(1, context.Presentations.Count());
                    Assert.Equal(tags.Count(), context.Tags.Count());

                    Assert.Equal(presentationTags, context.PresentationTags);
                    Assert.Equal(presentation.ToString(), context.Presentations.Single().ToString());
                    Assert.Equal(tags, context.Tags);

                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

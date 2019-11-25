using Domain.Core;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Verbs;
using System.Collections.Generic;
using Xunit;

namespace Application.Tests
{
    public class PresentationMapperTests
    {
        [Fact]
        public void MapToPresentationTag_ShoulReturnCorrectList()
        {
            var testSpeakerProfile = new SpeakerProfile
            {
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "Endava",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            var verb = new AddPresentationVerb() { Title = "Gala", LongDescription = "Gala de seara astazi", ShortDescription = "Gala de seara", Tags = "#GALA" };
            var expected = new List<PresentationTag>()
            {
                new PresentationTag() {  Presentation = new Presentation ()
                {
                     Title = "Gala",
                     ShortDescription = "Gala de seara",
                     LongDescription = "Gala de seara astazi"
                }
                ,
                Tag = new Tag ()  { TagName = "#GALA" }
                }
            };

            var mapper = new PresentationMapper();

            var act = mapper.MapToPresentationTag(verb, testSpeakerProfile);

            Assert.Equal(expected.ToString(), act.ToString());
        }
    }
}
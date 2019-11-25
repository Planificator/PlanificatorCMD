using Domain.Core;
using Moq;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Verbs;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class SpeakerProfileMapperTests
    {
        [Fact]
        public void MapToSpeaker_WithParams_ShouldReturnCorrectSpeaker()
        {
            var expected = new SpeakerProfile
            {
                FirstName = "Sergiu",
                LastName = "Chirila",
                Bio = "Intern",
                Email = "example@example.com",
                Company = "Endava",
                Photo = new Photo()
                {
                    Path = "1.jpg"
                }
            };

            var photo = new Mock<IPhotoPathProcessing>();
            photo.Setup(p => p.PhotoCopy("1.jpg")).Returns("1.jpg");
            var verb = new AddSpeakerVerb()
            {
                FirstName = "Sergiu",
                LastName = "Chirila",
                Bio = "Intern",
                Email = "example@example.com",
                Company = "Endava",
                PhotoPath = "1.jpg"
            };
            var mapper = new SpeakerProfileMapper(photo.Object);

            var act = mapper.MapToSpeaker(verb);

            Assert.Equal(expected.ToString(), act.ToString());
        }

        [Fact]
        public void MapToSpeaker_CallingPhotoCopy_Once()
        {
            var photo = new Mock<IPhotoPathProcessing>();
            var verb = new AddSpeakerVerb()
            {
                FirstName = "Sergiu",
                LastName = "Chirila",
                Bio = "Intern",
                Email = "example@example.com",
                Company = "Endava",
                PhotoPath = "1.jpg"
            };
            var mapper = new SpeakerProfileMapper(photo.Object);

            mapper.MapToSpeaker(verb);

            photo.Verify(p => p.PhotoCopy(verb.PhotoPath), Times.Once);
        }
    }
}
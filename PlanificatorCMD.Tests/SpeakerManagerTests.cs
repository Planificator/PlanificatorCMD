using Moq;
using PlanificatorCMD.Core;
using Xunit;
using PlanificatorCMD.Managers;

namespace PlanificatorCMD.Tests
{
    public class SpeakerManagerTests
    {
         
        [Fact]
        public void AddSpeakerProfile_IsCalledOnce()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();

            SpeakerProfile speakerProfile = new SpeakerProfile()
            {
                FirstName = "Vasily",
                LastName = "Pascal",
                Bio = "I'm .NET intern",
                Email = "vasilypascal@gmail.com",
                Company = "Endava",
                Photo = new Photo
                {
                    Path = @"...\something\13.jpg"
                }
            };

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object);

            sut.AddSpeakerProfile(speakerProfile);

            speakerRepository.Verify(s => s.AddSpeakerProfile(speakerProfile), Times.Once);
        }

        [Fact]
        public void GetSpeakerBySpeakerIndex_CallGetSpeakerBySpeakerIndex_Once()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object);

            sut.GetSpeakerBySpeakerIndex(It.IsAny<int>());

            speakerRepository.Verify(s => s.GetSpeakerBySpeakerIndex(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetSpeakerCount_CallGetSpeakersCount_Once()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object);

            sut.GetSpeakersCount();

            speakerRepository.Verify(s => s.GetSpeakersCount(), Times.Once);
        }
    }
}

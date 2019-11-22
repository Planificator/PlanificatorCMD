using Application.Managers;
using Domain.Core;
using Moq;
using Persistence.Persistence;
using PlanificatorCMD.Wrappers;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class SpeakerManagerTests
    {
        [Fact]
        public void AddSpeakerProfile_IsCalledOnce()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();
            var cw = new Mock<IConsoleWrapper>();

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
        public void GetSpeakerBySpeakerId_CallGetSpeakerBySpeakerId_Once()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object);

            sut.GetSpeakerBySpeakerId(It.IsAny<int>());

            speakerRepository.Verify(s => s.GetSpeakerBySpeakerId(It.IsAny<int>()), Times.Once);
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
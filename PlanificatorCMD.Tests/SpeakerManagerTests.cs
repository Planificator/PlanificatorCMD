using Moq;
using PlanificatorCMD.Core;
using Xunit;
using PlanificatorCMD.Utils;
using System.Collections.Generic;
using PlanificatorCMD.Wrappers;

namespace PlanificatorCMD.Tests
{
    public class SpeakerManagerTests
    {
         
        [Fact]
        public void AddSpeakerProfile_IsCalledOnce()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();
            Mock<IDisplaySpeakers> displaySpeakers = new Mock<IDisplaySpeakers>();
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

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object, displaySpeakers.Object);

            sut.AddSpeakerProfile(speakerProfile);

            speakerRepository.Verify(s => s.AddSpeakerProfile(speakerProfile), Times.Once);
        }

        [Fact]
        public void ShowSpeakersProfiles_GetAllSpeakersProfiles_IsCalledOnce()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();
            Mock<IDisplaySpeakers> displaySpeakers = new Mock<IDisplaySpeakers>();
            var cw = new Mock<IConsoleWrapper>();

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object, displaySpeakers.Object);

            sut.ShowSpeakersProfiles(true);

            speakerRepository.Verify(s => s.GetAllSpeakersProfiles(), Times.Once);
        }

        [Fact]
        public void GetSpeakerBySpeakerIndex_CallGetSpeakerBySpeakerIndex_Once()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();
            Mock<IDisplaySpeakers> displaySpeakers = new Mock<IDisplaySpeakers>();

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object, displaySpeakers.Object);

            sut.GetSpeakerBySpeakerIndex(It.IsAny<int>());

            speakerRepository.Verify(s => s.GetSpeakerBySpeakerIndex(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetSpeakerCount_CallGetSpeakersCount_Once()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();
            Mock<IDisplaySpeakers> displaySpeakers = new Mock<IDisplaySpeakers>();

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object, displaySpeakers.Object);

            sut.GetSpeakersCount();

            speakerRepository.Verify(s => s.GetSpeakersCount(), Times.Once);
        }
    }
}

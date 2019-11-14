using Moq;
using PlanificatorCMD.Core;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Wrappers;
using System.Collections.Generic;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class DisplaySpeakersTests
    {
        [Fact]
        public void DisplayAllSpeakers_ReturnFalse_WithEmptySpeakersList()
        {
            var consoleWrapper = new Mock<IConsoleWrapper>();
            var speakerRepository = new Mock<ISpeakerRepository>();
            var expected = ExecutionResult.Fail;

            bool displayOption = true;

            var sut = new DisplaySpeakers(speakerRepository.Object, consoleWrapper.Object);
            var actual = sut.DisplayAllSpeakers(displayOption);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DisplayAllSpeakers_WriteLineMethodIsCalledOnce_WithNoSpeakersList()
        {
            var consoleWrapper = new Mock<IConsoleWrapper>();
            var speakerRepository = new Mock<ISpeakerRepository>();
            var expected = ExecutionResult.Fail;
            var displayOption = true;

            var service = new DisplaySpeakers(speakerRepository.Object, consoleWrapper.Object);

            var actual = service.DisplayAllSpeakers(displayOption);

            consoleWrapper.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public void DisplayAllSpeaker_ShouldReturnExecutionResultSucces_WithFalseDisplayOption()
        {
            var consoleWrapper = new Mock<IConsoleWrapper>();
            var speakerRepository = new Mock<ISpeakerRepository>();
            var expected = ExecutionResult.Succes;

            bool displayOption = false;

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

            speakerRepository.Setup(s => s.GetAllSpeakersProfiles()).Returns(speakers);
            var sut = new DisplaySpeakers(speakerRepository.Object, consoleWrapper.Object);
            var actual = sut.DisplayAllSpeakers(displayOption);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DisplayAllSpeaker_ShouldReturnExecutionResultSucces_WithTrueDisplayOption()
        {
            var consoleWrapper = new Mock<IConsoleWrapper>();
            var speakerRepository = new Mock<ISpeakerRepository>();
            var expected = ExecutionResult.Succes;

            bool displayOption = true;

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

            speakerRepository.Setup(s => s.GetAllSpeakersProfiles()).Returns(speakers);
            var sut = new DisplaySpeakers(speakerRepository.Object, consoleWrapper.Object);
            var actual = sut.DisplayAllSpeakers(displayOption);

            Assert.Equal(expected, actual);
        }
    }
}
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
            Assert.Equal(expected, actual);
        }


        // My tests like examples (they don't work properly, but are good like a template)


        //[Fact]
        //public void DisplayAllSpeakers_ReturnsSuccess_WithValidSpeakersList()
        //{
        //    var consoleWrapper = new Mock<IConsoleWrapper>();
        //    var speakerRepository = new Mock<ISpeakerRepository>();
        //    var expected = ExecutionResult.Succes;
        //    var displayOption = true;

        //    List<SpeakerProfile> speakers = new List<SpeakerProfile>() {
        //                new SpeakerProfile()
        //                {
        //                  FirstName = "Vasily",
        //                 LastName = "Pascal",
        //                  Bio = "I'm .NET intern",
        //                  Email = "vasilypascal@gmail.com",
        //                  Company = "Endava",
        //                  Photo = new Photo
        //                  {
        //                      Path = @"...\something\13.jpg"
        //                  }}, new SpeakerProfile(){ FirstName = "Valentin",
        //                  LastName = "Butnaru",
        //                  Bio = "I'm .NET intern",
        //                  Email = "valentin@gmail.com",
        //                  Company = "Endava",
        //                  Photo = new Photo
        //                  {
        //                      Path = @"...\something\14.jpg"
        //                  }} };

        //    speakerRepository.Object.AddSpeakerProfile(speakers[0]);
        //    speakerRepository.Object.AddSpeakerProfile(speakers[1]);
        //    var service = new DisplaySpeakers(speakerRepository.Object, consoleWrapper.Object);

        //    var actual = service.DisplayAllSpeakers(displayOption);

        //    Assert.Equal(expected, actual);

        //    Assert.Equal(speakers.Count(), speakerRepository.Object.GetSpeakersCount());
        //    Assert.Equal(2, speakerRepository.Object.GetSpeakersCount());
        //    Assert.Equal(speakers, speakerRepository.Object.GetAllSpeakersProfiles().ToList());
        //}


        //[Fact]
        //public void DisplayAllSpeakers_WriteLineMethodIsCalledManyTimes_WithValidSpeakersList()
        //{
        //var consoleWrapper = new Mock<IConsoleWrapper>();
        //var speakerRepository = new Mock<ISpeakerRepository>();
        //var expected = ExecutionResult.Succes;
        //var displayoptions = true;

        //var service = new DisplaySpeakers(speakerRepository.Object, consoleWrapper.Object);

        //List<SpeakerProfile> speakers = new List<SpeakerProfile>() {
        //            new SpeakerProfile()
        //            {
        //              FirstName = "Vasily",
        //             LastName = "Pascal",
        //              Bio = "I'm .NET intern",
        //              Email = "vasilypascal@gmail.com",
        //              Company = "Endava",
        //              Photo = new Photo
        //              {
        //                  Path = @"...\something\13.jpg"
        //              }}, new SpeakerProfile(){ FirstName = "Valentin",
        //              LastName = "Butnaru",
        //              Bio = "I'm .NET intern",
        //              Email = "valentin@gmail.com",
        //              Company = "Endava",
        //              Photo = new Photo
        //              {
        //                  Path = @"...\something\14.jpg"
        //              }} };

        //var actual = service.DisplayAllSpeakers(displayoptions);

        //Assert.Equal(expected, actual);
        //consoleWrapper.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(speakerRepository.Object.GetSpeakersCount()));
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Core;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Wrappers;

namespace PlanificatorCMD.Tests
{
    public class DisplaySpeakersTests
    {
        [Fact]
        public void DisplayAllSpeakers_ReturnFalse_WithEmptySpeakersList()
        {
            List<SpeakerProfile> speakers = null;
            bool displayOption = true;
            var cw = new Mock<IConsoleWrapper>();

            var expected = false;
            DisplaySpeakers sut = new DisplaySpeakers(cw.Object);
            var actual = sut.DisplayAllSpeakers(speakers, displayOption);

            Assert.Equal(actual, expected);

        }

        [Fact]
        public void DisplayAllSpeakers_ReturnTrue_WithValidSpeakersList()
        {
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

            bool displayOption = true;

            var cw = new Mock<IConsoleWrapper>();
            var expected = true;
            DisplaySpeakers sut = new DisplaySpeakers(cw.Object);
            var actual = sut.DisplayAllSpeakers(speakers, displayOption);

            Assert.Equal(actual, expected);

        }


    }
}

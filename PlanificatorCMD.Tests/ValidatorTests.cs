using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("ex@@@@@")]
        [InlineData("")]
        [InlineData("         ")]
        [InlineData("example@gmail.....com")]
        [InlineData("cog@wheel")]
        public void IsValid_IsValidEmail_ShouldReturnFalse(string email)
        {
            var expected = 1;
            var speakerManager = new Mock<ISpeakerManager>();
            var validator = new Validator(speakerManager.Object);

            var speaker = new AddSpeakerVerb() { Email = email, FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = @"C:\Users\vbutnaru\Desktop\InternProject\PlanificatorCMD\SpeakersPhotos\1.jpg" };

            var act = validator.IsValid(speaker);

            Assert.Equal(expected, act);
        }

        [Theory]
        [InlineData("C:/abc*d")]
        [InlineData("C:/abc?d")]
        [InlineData("./abc")]
        [InlineData("/abc")]
        [InlineData("C:/abc>d")]
        [InlineData("")]
        [InlineData("     ")]
        public void IsValid_IsValidPath_ShouldReturnFalse(string path)
        {
            var expected = 1;
            var speakerManager = new Mock<ISpeakerManager>();
            var validator = new Validator(speakerManager.Object);

            var speaker = new AddSpeakerVerb() { Email = "example@example.com", FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = path };

            var act = validator.IsValid(speaker);

            Assert.Equal(expected, act);
        }

        [Theory]
        [InlineData(@"C:\\abc.png")]
        [InlineData(@"C:\\abc.jpeg")]
        [InlineData(@"C:\\abc.gif")]
        public void IsValid_IsValidFormat_ShouldReturnFalse(string path)
        {
            var expected = 1;
            var speakerManager = new Mock<ISpeakerManager>();
            var validator = new Validator(speakerManager.Object);

            var speaker = new AddSpeakerVerb() { Email = "example@example.com", FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = path };

            var act = validator.IsValid(speaker);

            Assert.Equal(expected, act);
        }

        [Fact]
        public void IsValid_CallingAddSpeakerProfile_Once()
        {
            var speakerManager = new Mock<ISpeakerManager>();
            var validator = new Validator(speakerManager.Object);

            var speaker = new AddSpeakerVerb() { Email = "example@example.com", FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = @"C:\Users\vbutnaru\Desktop\InternProject\PlanificatorCMD\SpeakersPhotos\1.jpg" };

            validator.IsValid(speaker);

            speakerManager.Verify(s => s.AddSpeakerProfile(speaker), Times.Once);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Verbs;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Core;

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
            var expected = false;
            var validator = new AddSpeakerVerbValidator();
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
            var expected = false;
            var validator = new AddSpeakerVerbValidator();

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
            var expected = false;
            var validator = new AddSpeakerVerbValidator();

            var speaker = new AddSpeakerVerb() { Email = "example@example.com", FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = path };

            var act = validator.IsValid(speaker);

            Assert.Equal(expected, act);
        }
    }
}


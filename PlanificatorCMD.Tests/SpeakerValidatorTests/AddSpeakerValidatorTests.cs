using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Verbs;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Core;
using System.IO;
using System.Reflection;

namespace PlanificatorCMD.Tests.SpeakerValidatorTests
{
    public class AddSpeakerValidatorTests
    {


        [Fact]
        public void IsValid_ShouldReturn_True()
        {
            var expected = true;
            var validator = new AddSpeakerVerbValidator();
            var speaker = new AddSpeakerVerb()
            {
                Email = "example@example.com",
                FirstName = "Sergiu",
                LastName = "Lapusneanu",
                Bio = "Dev",
                Company = "Endava",
                PhotoPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"PlanificatorCMD.Tests\SpeakerValidatorTests\test.jpg")
            };

            var actual = validator.IsValid(speaker);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ex@@@@@")]
        [InlineData("")]
        [InlineData("         ")]
        [InlineData("example@gmail.....com")]
        [InlineData("cog@wheel")]
        public void IsValid_IsValidEmail_ShouldReturnFalse(string email)
        {
            var validator = new AddSpeakerVerbValidator();
            var speaker = new AddSpeakerVerb() { Email = email, FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = @"C:\Users\vbutnaru\Desktop\InternProject\PlanificatorCMD\SpeakersPhotos\1.jpg" };

            Action act = () => validator.IsValid(speaker);

            Assert.Throws<ArgumentException>(act);

        }

        [Fact]
        public void IsValid_IsValidEmail_NullString_ShouldReturnFalse()
        {

            var validator = new AddSpeakerVerbValidator();
            var speaker = new AddSpeakerVerb() { Email = null, FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = @"C:\Users\vbutnaru\Desktop\InternProject\PlanificatorCMD\SpeakersPhotos\1.jpg" };


            Action act = () => validator.IsValid(speaker);

            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData("C:/abc*d")]
        [InlineData("C:/abc?d")]
        [InlineData("./abc")]
        [InlineData("/abc")]
        [InlineData("C:/abc>d")]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void IsValid_IsValidPath_ShouldReturnFalse(string path)
        {
            var validator = new AddSpeakerVerbValidator();

            var speaker = new AddSpeakerVerb() { Email = "example@example.com", FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = path };

            Action act = () => validator.IsValid(speaker);

            Assert.Throws<ArgumentNullException>("Invalid path", act);
        }

        [Fact]
        public void IsValid_IsValidFormat_ShouldReturnFalse()
        {
            var validator = new AddSpeakerVerbValidator();

            var speaker = new AddSpeakerVerb() { Email = "example@example.com", FirstName = "Sergiu", LastName = "Lapusneanu", Bio = "Dev", Company = "Endava", PhotoPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"PlanificatorCMD.Tests\SpeakerValidatorTests\test.png" )};

            Action act = () => validator.IsValid(speaker);

            Assert.Throws<ArgumentException>(act);
        }

    }
}


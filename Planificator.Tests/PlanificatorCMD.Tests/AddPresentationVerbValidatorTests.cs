using Domain.Core;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;
using System;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class AddPresentationVerbValidatorTests
    {
        [Fact]
        public void IsValid_ValidVerb_True()
        {
            var testSpeakerProfile = new SpeakerProfile
            {
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "Endava",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            var expected = true;
            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = "tyt-pyt",
                ShortDescription = "lkjkj",
                LongDescription = "jiyl",
                Tags = "ygugkj"
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            var actual = sut.IsValid(addPresentationVerb, testSpeakerProfile);
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("")]
        [InlineData(null)]
        public void IsValid_NotValidShortDescrition_False(string shortDescrition)
        {
            var testSpeakerProfile = new SpeakerProfile
            {
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "Endava",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = "tyt-pyt",
                ShortDescription = shortDescrition,
                LongDescription = "jiyl",
                Tags = "ygugkj"
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            Action act = () => sut.IsValid(addPresentationVerb, testSpeakerProfile);
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
           "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
           "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
           "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("")]
        [InlineData(null)]
        public void IsValid_NotValidTitle_False(string title)
        {
            var testSpeakerProfile = new SpeakerProfile
            {
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "Endava",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = title,
                ShortDescription = "ty-tpyt",
                LongDescription = "jiyl",
                Tags = "ygugkj"
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            Action act = () => sut.IsValid(addPresentationVerb, testSpeakerProfile);
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII" +
            "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII")]
        [InlineData("")]
        [InlineData(null)]
        public void IsValid_NotValidLongDescription_False(string longD)
        {
            var testSpeakerProfile = new SpeakerProfile
            {
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "Endava",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = "jiyl",
                ShortDescription = "ty-tpyt",
                LongDescription = longD,
                Tags = "ygugkj"
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            Action act = () => sut.IsValid(addPresentationVerb, testSpeakerProfile);
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsValid_NotValidTags_False(string tags)
        {
            var testSpeakerProfile = new SpeakerProfile
            {
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "Endava",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = "jiyl",
                ShortDescription = "ty-tpyt",
                LongDescription = "ygugkj",
                Tags = tags
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            Action act = () => sut.IsValid(addPresentationVerb, testSpeakerProfile);
            Assert.Throws<ArgumentException>(act);
        }
    }
}
using PlanificatorCMD.Verbs;
using PlanificatorCMD.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class AddPresentationVerbValidatorTests
    {
        [Fact]
        public void IsValid_ValidVerb_True()
        {
            var expected = true;
            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = "tyt-pyt",
                ShortDescription = "lkjkj",
                LongDescription = "jiyl",
                Tags = "ygugkj"
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            var actual = sut.IsValid(addPresentationVerb);
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
            var expected = false;
            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = "tyt-pyt",
                ShortDescription = shortDescrition,
                LongDescription = "jiyl",
                Tags = "ygugkj"
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            var actual = sut.IsValid(addPresentationVerb);
            Assert.Equal(actual, expected);
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
            var expected = false;
            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = title,
                ShortDescription = "ty-tpyt",
                LongDescription = "jiyl",
                Tags = "ygugkj"
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            var actual = sut.IsValid(addPresentationVerb);
            Assert.Equal(actual, expected);
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
            var expected = false;
            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = "jiyl",
                ShortDescription = "ty-tpyt",
                LongDescription = longD,
                Tags = "ygugkj"
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            var actual = sut.IsValid(addPresentationVerb);
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsValid_NotValidTags_False(string tags)
        {
            var expected = false;
            AddPresentationVerb addPresentationVerb = new AddPresentationVerb()
            {
                Title = "jiyl",
                ShortDescription = "ty-tpyt",
                LongDescription = "ygugkj",
                Tags = tags
            };

            AddPresentationVerbValidator sut = new AddPresentationVerbValidator();

            var actual = sut.IsValid(addPresentationVerb);
            Assert.Equal(actual, expected);
        }
    }
}

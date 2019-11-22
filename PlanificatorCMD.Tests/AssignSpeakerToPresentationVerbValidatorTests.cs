using Application.Core;
using PlanificatorCMD.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class AssignSpeakerToPresentationVerbValidatorTests
    {
        [Fact]
        public void IsValid_ReturnsTrue_WithValidId()
        {
            Presentation presentation = new Presentation
            {
                PresentationId = 1,
                Title = "Test",
                LongDescription = "Test",
                ShortDescription = "Test",
                PresentationOwner = new SpeakerProfile { SpeakerId = 1, FirstName = "a", LastName = "b", Email = "c", Bio = "b", Photo = new Photo { Path = "TEST" } },
            };
            SpeakerProfile speaker = new SpeakerProfile
            {
                SpeakerId = 2,
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "company",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            var expected = true;

            AssignSpeakerToPresentationVerbValidator sut = new AssignSpeakerToPresentationVerbValidator();

            var actual = sut.IsValid(speaker, presentation);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void IsValid_ReturnsFalse_WithNullPresentation()
        {
            Presentation presentation = null;

            SpeakerProfile speaker = new SpeakerProfile
            {
                SpeakerId = 2,
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "company",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            AssignSpeakerToPresentationVerbValidator sut = new AssignSpeakerToPresentationVerbValidator();

            Action act = () => sut.IsValid(speaker, presentation);

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void IsValid_ReturnsFalse_WithNullSpeaker()
        {
            Presentation presentation = new Presentation
            {
                PresentationId = 1,
                Title = "Test",
                LongDescription = "Test",
                ShortDescription = "Test",
                PresentationOwner = new SpeakerProfile { SpeakerId = 1, FirstName = "a", LastName = "b", Email = "c", Bio = "b", Photo = new Photo { Path = "TEST" } }
            };

            SpeakerProfile speaker = null;

            AssignSpeakerToPresentationVerbValidator sut = new AssignSpeakerToPresentationVerbValidator();

            Action act = () => sut.IsValid(speaker, presentation);

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void IsValid_ReturnsFalse_WithNullSpeakerAndNullPresentation()
        {
            Presentation presentation = null;

            SpeakerProfile speaker = null;

            AssignSpeakerToPresentationVerbValidator sut = new AssignSpeakerToPresentationVerbValidator();

            Action act = () => sut.IsValid(speaker, presentation);

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void IsValid_ReturnsFalse_WithSameOwnerIdAndSpeakerId()
        {
            Presentation presentation = new Presentation
            {
                PresentationId = 1,
                Title = "Test",
                LongDescription = "Test",
                ShortDescription = "Test",
                PresentationOwner = new SpeakerProfile { SpeakerId = 1, FirstName = "a", LastName = "b", Email = "c", Bio = "b", Photo = new Photo { Path = "TEST" } }
            };
            SpeakerProfile speaker = new SpeakerProfile
            {
                SpeakerId = 1,
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "company",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            AssignSpeakerToPresentationVerbValidator sut = new AssignSpeakerToPresentationVerbValidator();

            Action act = () => sut.IsValid(speaker, presentation);

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void IsValid_ReturnsFalse_WithSamePresentationSpeakersIdsAndSpeakerId()
        {
            SpeakerProfile presentationSpeaker1 = new SpeakerProfile
            {
                SpeakerId = 1,
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "company",
                Photo = new Photo { Path = "testPath.jpg" }
            };
            SpeakerProfile presentationSpeaker2 = new SpeakerProfile
            {
                SpeakerId = 2,
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "company",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            Presentation presentation = new Presentation
            {
                PresentationId = 1,
                Title = "Test",
                LongDescription = "Test",
                ShortDescription = "Test",
                PresentationOwner = new SpeakerProfile { SpeakerId = 1, FirstName = "a", LastName = "b", Email = "c", Bio = "b", Photo = new Photo { Path = "TEST" } }
            };
            PresentationSpeaker presentationSpeakers1 = new PresentationSpeaker
            {
                Presentation = presentation,
                PresentationId = 1,
                SpeakerProfile = presentationSpeaker1,
                SpeakerId = presentationSpeaker1.SpeakerId
            };
            PresentationSpeaker presentationSpeakers2 = new PresentationSpeaker
            {
                Presentation = presentation,
                PresentationId = 1,
                SpeakerProfile = presentationSpeaker2,
                SpeakerId = presentationSpeaker2.SpeakerId
            };
            List<PresentationSpeaker> PS = new List<PresentationSpeaker>();
            PS.Add(presentationSpeakers1);
            PS.Add(presentationSpeakers2);
            presentation.PresentationSpeakers = PS;

            SpeakerProfile speaker = new SpeakerProfile
            {
                SpeakerId = 1,
                FirstName = "Test FN",
                LastName = "Test LN",
                Email = "test@test.test",
                Bio = "Test Bio",
                Company = "company",
                Photo = new Photo { Path = "testPath.jpg" }
            };

            AssignSpeakerToPresentationVerbValidator sut = new AssignSpeakerToPresentationVerbValidator();

            Action act = () => sut.IsValid(speaker, presentation);

            Assert.Throws<ArgumentException>(act);
        }
    }
}
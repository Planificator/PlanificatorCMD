using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Utils;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Verbs;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Tests
{
    public class AddSpeakerVerbProcessingTests
    {
        [Fact]
        public void AddSpeaker_CallingIsValid_Once()
        {
            var validator = new Mock<IAddSpeakerVerbValidator>();
            var manager = new Mock<ISpeakerManager>();
            var mapper = new Mock<ISpeakerProfileMapper>();

            var verb = new AddSpeakerVerb()
            {
                FirstName = "Sergiu",
                LastName = "Chirila",
                Bio = "Intern",
                Email = "example@example.com",
                Company = "Endava",
                PhotoPath = "1.jpg"
            };

            var sut = new AddSpeakerVerbProcessing(validator.Object, mapper.Object, manager.Object);

            sut.AddSpeaker(verb);

            validator.Verify(v => v.IsValid(verb), Times.Once);
        }

        [Fact]
        public void AddSpeaker_CallingMapToSpeaker_Once()
        {
            var validator = new Mock<IAddSpeakerVerbValidator>();
            var manager = new Mock<ISpeakerManager>();
            var mapper = new Mock<ISpeakerProfileMapper>();

            var verb = new AddSpeakerVerb()
            {
                FirstName = "Sergiu",
                LastName = "Chirila",
                Bio = "Intern",
                Email = "example@example.com",
                Company = "Endava",
                PhotoPath = "1.jpg"
            };

            validator.Setup(v => v.IsValid(verb)).Returns(true);
            var sut = new AddSpeakerVerbProcessing(validator.Object, mapper.Object, manager.Object);

            sut.AddSpeaker(verb);

            mapper.Verify(m => m.MapToSpeaker(verb), Times.Once);
        }

        [Fact]
        public void AddSpeaker_CallingAddSpeaker_Once()
        {
            var validator = new Mock<IAddSpeakerVerbValidator>();
            var manager = new Mock<ISpeakerManager>();
            var mapper = new Mock<ISpeakerProfileMapper>();

            var verb = new AddSpeakerVerb()
            {
                FirstName = "Sergiu",
                LastName = "Chirila",
                Bio = "Intern",
                Email = "example@example.com",
                Company = "Endava",
                PhotoPath = "1.jpg"
            };

            validator.Setup(v => v.IsValid(verb)).Returns(true);
            var sut = new AddSpeakerVerbProcessing(validator.Object, mapper.Object, manager.Object);

            sut.AddSpeaker(verb);

            manager.Verify(v => v.AddSpeakerProfile(It.IsAny<SpeakerProfile>()), Times.Once);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Managers;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Verbs;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Tests
{
    public class AddPresentationVerbProcessingTests
    {

        [Fact]
        public void AddPresentation_CallingIsValidOnce()
        {
            var validator = new Mock<IAddPresentationVerbValidator>();
            var mapper = new Mock<IPresentationMapper>();
            var manager = new Mock<IPresentationManager>();
            var repository = new Mock<ISpeakerRepository>();
            
            
            
            var verb = new AddPresentationVerb() { Title = "Gala", ShortDescription = "Gala de seara", LongDescription = "Gala de seara astazi", Tags = "#Tusa" };
            repository.Setup(s => s.GetSpeakerBySpeakerId(verb.PresentationOwnerSpeakerId)).Returns(It.IsAny<SpeakerProfile>());

            var processing = new AddPresentationVerbProcessing(validator.Object, mapper.Object, manager.Object, repository.Object);
            
            processing.AddPresentation(verb);

            validator.Verify(v => v.IsValid(verb, It.IsAny<SpeakerProfile>()), Times.Once);

        }

        [Fact]
        public void AddPresentation_CallingMapToPresentationTagOnce()
        {
            var validator = new Mock<IAddPresentationVerbValidator>();
            var mapper = new Mock<IPresentationMapper>();
            var manager = new Mock<IPresentationManager>();
            var repository = new Mock<ISpeakerRepository>();
            
            var verb = new AddPresentationVerb() { Title = "Gala", ShortDescription = "Gala de seara", LongDescription = "Gala de seara astazi", Tags = "#Tusa", PresentationOwnerSpeakerId = 1 };

            var prossec = new AddPresentationVerbProcessing(validator.Object, mapper.Object, manager.Object, repository.Object);

            repository.Setup(r => r.GetSpeakerBySpeakerId(verb.PresentationOwnerSpeakerId)).Returns(It.IsAny<SpeakerProfile>());
            validator.Setup(v => v.IsValid(verb, It.IsAny<SpeakerProfile>())).Returns(true);

            prossec.AddPresentation(verb);

            mapper.Verify(m => m.MapToPresentationTag(verb, It.IsAny<SpeakerProfile>()), Times.Once);

        }


        [Fact]
        public void AddPresentation_CallingManagerAddPresentationOnce()
        {
            var validator = new Mock<IAddPresentationVerbValidator>();
            var mapper = new Mock<IPresentationMapper>();
            var manager = new Mock<IPresentationManager>();
            var repository = new Mock<ISpeakerRepository>();

            var prossec = new AddPresentationVerbProcessing(validator.Object, mapper.Object, manager.Object, repository.Object);

            var verb = new AddPresentationVerb() { Title = "Gala", ShortDescription = "Gala de seara", LongDescription = "Gala de seara astazi", Tags = "#Tusa" };
            repository.Setup(r => r.GetSpeakerBySpeakerId(verb.PresentationOwnerSpeakerId)).Returns(It.IsAny<SpeakerProfile>());
            validator.Setup(v => v.IsValid(verb, It.IsAny<SpeakerProfile>())).Returns(true);
            mapper.Setup(m => m.MapToPresentationTag(verb, It.IsAny<SpeakerProfile>()));

            prossec.AddPresentation(verb);

            manager.Verify(m => m.AddPresentation(It.IsAny<ICollection<PresentationTag>>()), Times.Once);
        }
    }
}

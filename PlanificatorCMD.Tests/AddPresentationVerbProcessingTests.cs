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
        public void AddPresentation_CallingValidOnce()
        {
            var validator = new Mock<IAddPresentationVerbValidator>();
            var mapper = new Mock<IPresentationMapper>();
            var manager = new Mock<IPresentationManager>();

            var prossec = new AddPresentationVerbProcessing(validator.Object, mapper.Object, manager.Object);
            var verb = new AddPresentationVerb() { Title = "Gala", ShortDescription = "Gala de seara", LongDescription = "Gala de seara astazi", Tags = "#Tusa" };

            prossec.AddPresentation(verb);

            validator.Verify(v => v.IsValid(verb), Times.Once);

        }

        [Fact]
        public void AddPresentation_CallingMapToPresentationTagOnce()
        {
            var validator = new Mock<IAddPresentationVerbValidator>();
            var mapper = new Mock<IPresentationMapper>();
            var manager = new Mock<IPresentationManager>();

            var prossec = new AddPresentationVerbProcessing(validator.Object, mapper.Object, manager.Object);
            var verb = new AddPresentationVerb() { Title = "Gala", ShortDescription = "Gala de seara", LongDescription = "Gala de seara astazi", Tags = "#Tusa" };
            validator.Setup(v => v.IsValid(verb)).Returns(true);

            prossec.AddPresentation(verb);

            mapper.Verify(m => m.MapToPresentationTag(verb), Times.Once);

        }


        [Fact]
        public void AddPresentation_CallingManagerAddPresentationOnce()
        {
            var validator = new Mock<IAddPresentationVerbValidator>();
            var mapper = new Mock<IPresentationMapper>();
            var manager = new Mock<IPresentationManager>();

            var prossec = new AddPresentationVerbProcessing(validator.Object, mapper.Object, manager.Object);
            var verb = new AddPresentationVerb() { Title = "Gala", ShortDescription = "Gala de seara", LongDescription = "Gala de seara astazi", Tags = "#Tusa" };
            validator.Setup(v => v.IsValid(verb)).Returns(true);

            prossec.AddPresentation(verb);

            manager.Verify(m => m.AddPresentation(It.IsAny<ICollection<PresentationTag>>()), Times.Once);
        }
    }
}

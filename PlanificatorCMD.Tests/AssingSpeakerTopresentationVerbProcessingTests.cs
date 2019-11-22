using Application.Core;
using Application.Managers;
using Moq;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class AssingSpeakerTopresentationVerbProcessingTests
    {
        [Fact]
        public void AssignSpeakerToPresentation_CallingIsValid_Once()
        {
            var presManager = new Mock<IPresentationManager>();
            var spekManager = new Mock<ISpeakerManager>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerId = 1, PresentationId = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presManager.Object, spekManager.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            validator.Verify(v => v.IsValid(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>()), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_CallingGetSpeakerByIndex_Once()
        {
            var presManager = new Mock<IPresentationManager>();
            var spekManager = new Mock<ISpeakerManager>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            spekManager.Setup(s => s.GetSpeakersCount()).Returns(1);
            validator.Setup(v => v.IsValid(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>())).Returns(true);
            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerId = 1, PresentationId = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presManager.Object, spekManager.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            spekManager.Verify(s => s.GetSpeakerBySpeakerId(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_CallingAssingSpeakerToPresentation_Once()
        {
            var presManager = new Mock<IPresentationManager>();
            var spekManager = new Mock<ISpeakerManager>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            presManager.Setup(p => p.GetPresentationsCount()).Returns(1);
            validator.Setup(v => v.IsValid(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>())).Returns(true);
            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerId = 1, PresentationId = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presManager.Object, spekManager.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            presManager.Verify(p => p.AssignSpeakerToPresentation(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>()), Times.Once);
        }
    }
}
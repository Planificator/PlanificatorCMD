using Application.Managers;
using Domain.Core;
using Moq;
using Persistence.Persistence;
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
            var presentationManager = new Mock<IPresentationManager>();
            var presentationRepository = new Mock<IPresentationRepository>();
            var speakerRepository = new Mock<ISpeakerRepository>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();
            

            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerId = 1, PresentationId = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presentationManager.Object, presentationRepository.Object, speakerRepository.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            validator.Verify(v => v.IsValid(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>()), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_CallingGetSpeakerByIndex_Once()
        {
            var presentationManager = new Mock<IPresentationManager>();
            var presentationRepository = new Mock<IPresentationRepository>();
            var speakerRepository = new Mock<ISpeakerRepository>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            speakerRepository.Setup(s => s.GetSpeakersCount()).Returns(1);
            validator.Setup(v => v.IsValid(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>())).Returns(true);
            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerId = 1, PresentationId = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presentationManager.Object, presentationRepository.Object, speakerRepository.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            speakerRepository.Verify(s => s.GetSpeakerBySpeakerId(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_CallingAssingSpeakerToPresentation_Once()
        {
            var presentationManager = new Mock<IPresentationManager>();
            var presentationRepository = new Mock<IPresentationRepository>();
            var speakerRepository = new Mock<ISpeakerRepository>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            presentationRepository.Setup(p => p.GetPresentationCount()).Returns(1);
            validator.Setup(v => v.IsValid(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>())).Returns(true);
            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerId = 1, PresentationId = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presentationManager.Object, presentationRepository.Object, speakerRepository.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            presentationManager.Verify(p => p.AssignSpeakerToPresentation(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>()), Times.Once);
        }
    }
}
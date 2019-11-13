﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Managers;
using PlanificatorCMD.Validators;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Verbs;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Tests
{
    public class AssingSpeakerTopresentationVerbProcessingTests
    {
        [Fact]
        public void AssignSpeakerToPresentation_GetSpeakerCount_Calling_Once()
        {
            var presManager = new Mock<IPresentationManager>();
            var spekManager = new Mock<ISpeakerManager>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerIndex = 1, PresentationIndex = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presManager.Object, spekManager.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            spekManager.Verify(s => s.GetSpeakersCount(), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_GetPresentationsCount_Calling_Once()
        {
            var presManager = new Mock<IPresentationManager>();
            var spekManager = new Mock<ISpeakerManager>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerIndex = 1, PresentationIndex = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presManager.Object, spekManager.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            presManager.Verify(p => p.GetPresentationsCount(), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_CallingIsValid_Once()
        {
            var presManager = new Mock<IPresentationManager>();
            var spekManager = new Mock<ISpeakerManager>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerIndex = 1, PresentationIndex = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presManager.Object, spekManager.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            validator.Verify(v => v.IsValid(It.IsAny<int>(),It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_CallingGetSpeakerByIndex_Once()
        {
            var presManager = new Mock<IPresentationManager>();
            var spekManager = new Mock<ISpeakerManager>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            spekManager.Setup(s => s.GetSpeakersCount()).Returns(1);
            validator.Setup(v => v.IsValid(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerIndex = 1, PresentationIndex = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presManager.Object, spekManager.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            spekManager.Verify(s => s.GetSpeakerBySpeakerIndex(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_CallingAssingSpeakerToPresentation_Once()
        {
            var presManager = new Mock<IPresentationManager>();
            var spekManager = new Mock<ISpeakerManager>();
            var validator = new Mock<IAssignSpeakerToPresentationVerbValidator>();

            presManager.Setup(p => p.GetPresentationsCount()).Returns(1);
            validator.Setup(v => v.IsValid(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            AssignSpeakerToPresentationVerb verb = new AssignSpeakerToPresentationVerb() { SpeakerIndex = 1, PresentationIndex = 1 };
            var assingprocessor = new AssignSpeakerToPresentationVerbProcessing(presManager.Object, spekManager.Object, validator.Object);

            assingprocessor.AssignSpeakerToPresentation(verb);

            presManager.Verify(p => p.AssignSpeakerToPresentation(It.IsAny<SpeakerProfile>(), It.IsAny<int>()), Times.Once);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Managers;
using PlanificatorCMD.Core;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Wrappers;

namespace PlanificatorCMD.Tests
{
    public class PresentationManagerTests
    {
        [Fact]
        public void AddPresentation_CallingAddPresentation_Once ()
        {
            var repo = new Mock<IPresentationRepository>();

            var manager = new PresentationManager(repo.Object);

            manager.AddPresentation(It.IsAny<ICollection<PresentationTag>>());

            repo.Verify(r => r.AddPresentation(It.IsAny<ICollection<PresentationTag>>()), Times.Once);
        }

        [Fact]
        public void AssignSpeakerToPresentation_CallingAssignSpeakerToPresentation_Once()
        {
            var repo = new Mock<IPresentationRepository>();

            var manager = new PresentationManager(repo.Object);

            manager.AssignSpeakerToPresentation(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>());

            repo.Verify(r => r.AssignSpeakerToPresentation(It.IsAny<SpeakerProfile>(), It.IsAny<Presentation>()), Times.Once);
        }
        
        [Fact]
        public void GetPresentationsCount_CallingGetPresentationCount_Once()
        {
            var repo = new Mock<IPresentationRepository>();

            var manager = new PresentationManager(repo.Object);
            var expected = 0;

            var actual = manager.GetPresentationsCount();

            Assert.Equal(expected, actual);
        }
    }
}

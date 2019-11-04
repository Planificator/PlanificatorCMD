using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Managers;
using PlanificatorCMD.Core;
using PlanificatorCMD.Utils;

namespace PlanificatorCMD.Tests
{
    public class PresentationManagerTests
    {
        [Fact]
        public void AddPresentation_CallingAddPresentation_Once ()
        {
            var repo = new Mock<IPresentationRepository>();
            var display = new Mock<IDisplayPresentation>();

            var manager = new PresentationManager(repo.Object,display.Object);

            manager.AddPresentation(It.IsAny<ICollection<PresentationTag>>());

            repo.Verify(r => r.AddPresentation(It.IsAny<ICollection<PresentationTag>>()), Times.Once);
        }
    }
}

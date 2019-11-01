using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Managers;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Tests
{
    public class PresentationManagerTests
    {
        [Fact]
        public void AddPresentation_CallingAddPresentation_Once ()
        {
            var repo = new Mock<IPresentationRepository>();

            var manager = new PresentationManager(repo.Object);

            manager.AddPresentation(It.IsAny<Presentation>());

            repo.Verify(r => r.AddPresentation(It.IsAny<Presentation>()), Times.Once);
        }
    }
}

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
            var cw = new Mock<IConsoleWrapper>();
            var repo = new Mock<IPresentationRepository>();
            var display = new Mock<IDisplayPresentation>();

            var manager = new PresentationManager(repo.Object,display.Object, cw.Object);

            manager.AddPresentation(It.IsAny<ICollection<PresentationTag>>());

            repo.Verify(r => r.AddPresentation(It.IsAny<ICollection<PresentationTag>>()), Times.Once);
        }

        [Fact]
        public void ShowAllPresentation_CallingGetAllPresentation_Once()
        {
            var cw = new Mock<IConsoleWrapper>();
            var repo = new Mock<IPresentationRepository>();
            var display = new Mock<IDisplayPresentation>();

            var manager = new PresentationManager(repo.Object, display.Object, cw.Object);
            manager.ShowAllPresentation(true);

            repo.Verify(r => r.GetAllPresentations(), Times.Once);
        }

        [Fact]
        public void ShowAllPresentation_ReturnsFalse()
        {
            var expected = 1;  // In our App 1 means false.

            ICollection<Presentation> presentations = null;
            var repo = new Mock<IPresentationRepository>();
            var display = new Mock<IDisplayPresentation>();
            var cw = new Mock<IConsoleWrapper>();

            repo.Setup(r => r.GetAllPresentations()).Returns(presentations);

            var manager = new PresentationManager(repo.Object, display.Object, cw.Object);

            var act = manager.ShowAllPresentation(true);

            Assert.Equal(expected, act);
        }

        [Fact]
        public void ShowAllPresentation_ReturnsTrue()
        {
            var expected = 0;  // In our App 0 means true.

            List<Presentation> presentations = new List<Presentation>
            {

                new Presentation { Title = "Gala" , ShortDescription = "Gala de seara " , LongDescription = "Gala de seara astazi" }
            };
            var repo = new Mock<IPresentationRepository>();
            var display = new Mock<IDisplayPresentation>();
            var cw = new Mock<IConsoleWrapper>();

            repo.Setup(r => r.GetAllPresentations()).Returns(presentations);

            var manager = new PresentationManager(repo.Object, display.Object, cw.Object);

            var act = manager.ShowAllPresentation(true);

            Assert.Equal(expected, act);
        }
    }
}

using Moq;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Tests.PresentationRepositoryTests;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Wrappers;
using System.Linq;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class DisplayPresentationsTests
    {
        [Fact]
        public void ShowAllPresentations_ReturnsFail_WithNoPresentations()
        {
            var consoleWrapper = new Mock<IConsoleWrapper>();
            var presentationRepository = new Mock<IPresentationRepository>();
            var expected = ExecutionResult.Fail;

            var service = new DisplayPresentations(presentationRepository.Object, consoleWrapper.Object);

            var actual = service.ShowAllPresentations(true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShowAllPresentations_WriteLineMethodIsCalledOnce_WithNoPresentations()
        {
            var consoleWrapper = new Mock<IConsoleWrapper>();
            var presentationRepository = new Mock<IPresentationRepository>();
            var expected = ExecutionResult.Fail;

            var service = new DisplayPresentations(presentationRepository.Object, consoleWrapper.Object);

            var actual = service.ShowAllPresentations(true);

            consoleWrapper.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once);
            Assert.Equal(expected, actual);
        }


        // OLD TESTS FROM PRESENTATION_MANAGER !!!
        // Needs a little change to work properly


        //[Fact]
        //public void ShowAllPresentations_CallingGetAllPresentation_Once()
        //{
        //    var cw = new Mock<IConsoleWrapper>();
        //    var repo = new Mock<IPresentationRepository>();
        //    var display = new Mock<IDisplayPresentations>();

        //    var manager = new PresentationManager(repo.Object);
        //    manager.ShowAllPresentation(true);

        //    repo.Verify(r => r.GetAllPresentations(), Times.Once);
        //}

        //[Fact]
        //public void ShowAllPresentations_ReturnsFalse()
        //{
        //    var expected = 1;  // In our App 1 means false.

        //    ICollection<Presentation> presentations = null;
        //    var repo = new Mock<IPresentationRepository>();
        //    var display = new Mock<IDisplayPresentations>();
        //    var cw = new Mock<IConsoleWrapper>();

        //    repo.Setup(r => r.GetAllPresentations()).Returns(presentations);

        //    var manager = new PresentationManager(repo.Object, display.Object);

        //    var act = manager.ShowAllPresentation(true);

        //    Assert.Equal(expected, act);
        //}

        //[Fact]
        //public void ShowAllPresentations_ReturnsTrue()
        //{
        //    var expected = 0;  // In our App 0 means true.

        //    List<Presentation> presentations = new List<Presentation>
        //    {

        //        new Presentation { Title = "Gala" , ShortDescription = "Gala de seara " , LongDescription = "Gala de seara astazi" }
        //    };
        //    var repo = new Mock<IPresentationRepository>();
        //    var display = new Mock<IDisplayPresentations>();
        //    var cw = new Mock<IConsoleWrapper>();

        //    repo.Setup(r => r.GetAllPresentations()).Returns(presentations);

        //    var manager = new PresentationManager(repo.Object, display.Object);

        //    var act = manager.ShowAllPresentation(true);

        //    Assert.Equal(expected, act);
        //}
    }
}
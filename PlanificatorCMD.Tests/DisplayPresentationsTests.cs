using Application.Core;
using Application.Persistence;
using Moq;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Wrappers;
using System.Collections.Generic;
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

            var actual = service.DisplayAllPresentations(true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShowAllPresentations_WriteLineMethodIsCalledOnce_WithNoPresentations()
        {
            var consoleWrapper = new Mock<IConsoleWrapper>();
            var presentationRepository = new Mock<IPresentationRepository>();
            var expected = ExecutionResult.Fail;

            var service = new DisplayPresentations(presentationRepository.Object, consoleWrapper.Object);

            var actual = service.DisplayAllPresentations(true);

            consoleWrapper.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DisplayAllPresentations_CallingGetAllPresentation_Once()
        {
            var cw = new Mock<IConsoleWrapper>();
            var repo = new Mock<IPresentationRepository>();

            var display = new DisplayPresentations(repo.Object, cw.Object);
            display.DisplayAllPresentations(true);

            repo.Verify(r => r.GetAllPresentations(), Times.Once);
        }

        [Fact]
        public void DisplayAllPresentations_ReturnsFail()
        {
            var expected = ExecutionResult.Fail;

            ICollection<Presentation> presentations = null;
            var repo = new Mock<IPresentationRepository>();
            var cw = new Mock<IConsoleWrapper>();

            repo.Setup(r => r.GetAllPresentations()).Returns(presentations);

            var display = new DisplayPresentations(repo.Object, cw.Object);

            var act = display.DisplayAllPresentations(true);

            Assert.Equal(expected, act);
        }

        [Fact]
        public void DisplayAllPresentations_ReturnsSucces()
        {
            var expected = ExecutionResult.Succes;

            List<Presentation> presentations = new List<Presentation>
            {
                new Presentation { Title = "Gala" , ShortDescription = "Gala de seara " , LongDescription = "Gala de seara astazi" }
            };
            List<string> tags = new List<string>
            {
                "test1",
                "test2"
            };
            var repo = new Mock<IPresentationRepository>();
            var cw = new Mock<IConsoleWrapper>();

            repo.Setup(r => r.GetAllPresentations()).Returns(presentations);
            repo.Setup(r => r.GetAllTagsNames(presentations[0].PresentationId)).Returns(tags);
            var display = new DisplayPresentations(repo.Object, cw.Object);

            var act = display.DisplayAllPresentations(true);

            Assert.Equal(expected, act);
        }

        [Fact]
        public void DisplayAllPresentations_WithOptionFalse_ReturnsSucces()
        {
            var expected = ExecutionResult.Succes;

            List<Presentation> presentations = new List<Presentation>
            {
                new Presentation { Title = "Gala" , ShortDescription = "Gala de seara " , LongDescription = "Gala de seara astazi" }
            };
            List<string> tags = new List<string>
            {
                "test1",
                "test2"
            };
            var repo = new Mock<IPresentationRepository>();
            var cw = new Mock<IConsoleWrapper>();

            repo.Setup(r => r.GetAllPresentations()).Returns(presentations);
            repo.Setup(r => r.GetAllTagsNames(presentations[0].PresentationId)).Returns(tags);
            var display = new DisplayPresentations(repo.Object, cw.Object);

            var act = display.DisplayAllPresentations(false);

            Assert.Equal(expected, act);
        }
    }
}
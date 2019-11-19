using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Managers;
using PlanificatorCMD.Verbs;
using PlanificatorCMD.Utils;

namespace PlanificatorCMD.Tests
{
    public class ApplicationsTests
    {
        [Fact]
        public void Run_CallingAddSpeaker_Once()
        {
            string[] args = new string[11] { "add_speaker", "-f" ,"firstname","-l" ,"lastname","-e","example@example.com","-p","path","-b","bio"};
            var prosSpeaker = new Mock<IAddSpeakerVerbProcessing>();
            var displaySpeakers = new Mock<IDisplaySpeakers>();
            var displayPresentation = new Mock<IDisplayPresentations>();
            var prosPresentation = new Mock<IAddPresentationVerbProcessing>();
            var assingPresentation = new Mock<IAssignSpeakerToPresentationVerbProcessing>();

            var app = new Application(prosPresentation.Object, prosSpeaker.Object, displaySpeakers.Object, displayPresentation.Object, assingPresentation.Object);

            app.Run(args);

            prosSpeaker.Verify(v => v.AddSpeaker(It.IsAny<AddSpeakerVerb>()), Times.Once);
        }

        [Fact]
        public void Run_CallingShowSpeakers_Once()
        {
            string[] args = new string[3] { "show_speakers","-o","true" };
            var prosSpeaker = new Mock<IAddSpeakerVerbProcessing>();
            var displaySpeakers = new Mock<IDisplaySpeakers>();
            var displayPresentation = new Mock<IDisplayPresentations>();
            var prosPresentation = new Mock<IAddPresentationVerbProcessing>();
            var assingPresentation = new Mock<IAssignSpeakerToPresentationVerbProcessing>();

            var app = new Application(prosPresentation.Object, prosSpeaker.Object, displaySpeakers.Object, displayPresentation.Object, assingPresentation.Object);

            app.Run(args);

            displaySpeakers.Verify(s => s.DisplayAllSpeakers(true), Times.Once);
        }


        [Fact]
        public void Run_CallingAddPresentation_Once()
        {
            string[] args = new string[11] { "add_presentation", "-t", "title", "-s", "short", "-l", "long", "-T", "tags", "-o" ,"1" };
            var prosSpeaker = new Mock<IAddSpeakerVerbProcessing>();
            var displaySpeakers = new Mock<IDisplaySpeakers>();
            var displayPresentation = new Mock<IDisplayPresentations>();
            var prosPresentation = new Mock<IAddPresentationVerbProcessing>();
            var assingPresentation = new Mock<IAssignSpeakerToPresentationVerbProcessing>();

            var app = new Application(prosPresentation.Object, prosSpeaker.Object, displaySpeakers.Object, displayPresentation.Object, assingPresentation.Object);

            app.Run(args);

            prosPresentation.Verify(p => p.AddPresentation(It.IsAny<AddPresentationVerb>()), Times.Once);
        }



        [Fact]
        public void Run_CallingShowPresentations_Once()
        {
            string[] args = new string[3] { "show_presentations", "-o", "true" };
            var prosSpeaker = new Mock<IAddSpeakerVerbProcessing>();
            var displaySpeakers = new Mock<IDisplaySpeakers>();
            var displayPresentation = new Mock<IDisplayPresentations>();
            var prosPresentation = new Mock<IAddPresentationVerbProcessing>();
            var assingPresentation = new Mock<IAssignSpeakerToPresentationVerbProcessing>();

            var app = new Application(prosPresentation.Object, prosSpeaker.Object, displaySpeakers.Object, displayPresentation.Object, assingPresentation.Object);

            app.Run(args);

            displayPresentation.Verify(p => p.DisplayAllPresentations(true), Times.Once);
        }

        [Fact]
        public void Run_CallingAssingSpeakerToPresentation_Once()
        {
            string[] args = new string[5] { "assign_speaker_to_presentation", "-s", "1", "-p" ,"1"};
            var prosSpeaker = new Mock<IAddSpeakerVerbProcessing>();
            var displaySpeakers = new Mock<IDisplaySpeakers>();
            var displayPresentation = new Mock<IDisplayPresentations>();
            var prosPresentation = new Mock<IAddPresentationVerbProcessing>();
            var assingPresentation = new Mock<IAssignSpeakerToPresentationVerbProcessing>();

            var app = new Application(prosPresentation.Object, prosSpeaker.Object, displaySpeakers.Object, displayPresentation.Object, assingPresentation.Object);

            app.Run(args);

            assingPresentation.Verify(a => a.AssignSpeakerToPresentation(It.IsAny<IAssignSpeakerToPresentationVerb>()), Times.Once);
        }

    }
}

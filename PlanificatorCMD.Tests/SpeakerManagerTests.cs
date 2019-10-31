using Moq;
using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PlanificatorCMD.Tests
{
    public class SpeakerManagerTests
    {
        [Fact]
        public void ShowSpeakersProfiles_SpeakerRepositoryCallsGetAllSpeakersProfiles()
        {
            var s = new List<SpeakerProfile>();
            var mock = new Mock<ISpeakerRepository>();
            mock.Setup(foo => foo.GetAllSpeakersProfiles());
            var sm = new SpeakerManager(mock.Object);

            mock.Verify(mock => mock.GetAllSpeakersProfiles(), Times.Once());
        }
    }
}

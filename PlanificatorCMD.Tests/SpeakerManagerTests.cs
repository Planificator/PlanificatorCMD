using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PlanificatorCMD.Interfaces;


namespace PlanificatorCMD.Tests
{
    public class SpeakerManagerTests
    {
        [Fact]
        public void ShowSpeakersProfiles_SpeakerRepositoryCallsGetAllSpeakersProfiles()
        {
            var speakerRepo = Substitute.For<ISpeakerRepository>;
        }
    }
}

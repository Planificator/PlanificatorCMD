﻿using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Tests
{
    public class SpeakerManagerTests
    {

        [Fact]
        public void AddSpeakerProfile_IsCalledOnce()
        {
            Mock<ISpeakerRepository> speakerRepository = new Mock<ISpeakerRepository>();

            SpeakerProfile speakerProfile = new SpeakerProfile()
            {
                FirstName = "Vasily",
                LastName = "Pascal",
                Bio = "I'm .NET intern",
                Email = "vasilypascal@gmail.com",
                Company = "Endava",
                Photo = new Photo
                {
                    Path = @"...\something\13.jpg"
                }
            };

            SpeakerManager sut = new SpeakerManager(speakerRepository.Object);

            sut.AddSpeakerProfile(speakerProfile);

            speakerRepository.Verify(s => s.AddSpeakerProfile(speakerProfile), Times.Once);


        }

    }
}
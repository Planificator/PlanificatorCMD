using PlanificatorCMD.Core;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Verbs;
using PlanificatorCMD.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlanificatorCMD
{
    public class SpeakerManager : ISpeakerManager
    {
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IDisplaySpeakers _displaySpeakers;
        private readonly IConsoleWrapper _CW;

        public SpeakerManager(ISpeakerRepository speakerRepository, IDisplaySpeakers displaySpeakers, IConsoleWrapper CW)
        {
            _speakerRepository = speakerRepository;
            _displaySpeakers = displaySpeakers;
            _CW = CW;
        }

        public void AddSpeakerProfile(SpeakerProfile speaker)
        {
            _speakerRepository.AddSpeakerProfile(speaker);
        }

        public int ShowSpeakersProfiles(bool displayOption)
        {
            ICollection<SpeakerProfile> speakersList = _speakerRepository.GetAllSpeakersProfiles();

            if (_displaySpeakers.DisplayAllSpeakers(speakersList, displayOption, _CW) == false)
                return ExecutionResult.Fail;

            return ExecutionResult.Succes;
        }

        public SpeakerProfile GetSpeakerBySpeakerIndex(int speakerIndex)
        {
            return _speakerRepository.GetSpeakerBySpeakerIndex(speakerIndex);
        }

        public int GetSpeakersCount()
        {
            return _speakerRepository.GetSpeakersCount();
        }
    }
}

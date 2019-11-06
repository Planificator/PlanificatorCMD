using PlanificatorCMD.Core;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Verbs;
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

        public SpeakerManager(ISpeakerRepository speakerRepository, IDisplaySpeakers displaySpeakers)
        {
            _speakerRepository = speakerRepository;
            _displaySpeakers = displaySpeakers;
        }

        public void AddSpeakerProfile(SpeakerProfile speaker)
        {
            _speakerRepository.AddSpeakerProfile(speaker);
        }

        public int ShowSpeakersProfiles(bool displayOption)
        {
            List<SpeakerProfile> speakersList = _speakerRepository.GetAllSpeakersProfiles();

            if (_displaySpeakers.DisplayAllSpeakers(speakersList, displayOption) == false)
                return 1;

            return 0;
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

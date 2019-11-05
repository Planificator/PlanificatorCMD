using System;
using System.Collections.Generic;
using System.Text;
using PlanificatorCMD.Core;

namespace PlanificatorCMD
{
    public interface ISpeakerRepository
    {
        public void AddSpeakerProfile(SpeakerProfile speaker);

        public List<SpeakerProfile> GetAllSpeakersProfiles();
        public int GetMaxId();
        public int GetSpeakersCount();
        public SpeakerProfile GetSpeakerBySpeakerIndex(int index);

    }
}

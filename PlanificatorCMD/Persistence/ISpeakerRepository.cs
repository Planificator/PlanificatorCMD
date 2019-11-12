using System;
using System.Collections.Generic;
using System.Text;
using PlanificatorCMD.Core;

namespace PlanificatorCMD
{
    public interface ISpeakerRepository
    {
        void AddSpeakerProfile(SpeakerProfile speaker);
        ICollection<SpeakerProfile> GetAllSpeakersProfiles();
        int GetMaxId();
        int GetSpeakersCount();
        SpeakerProfile GetSpeakerBySpeakerIndex(int index);
        ICollection<SpeakerProfile> GetAllSpeakersProfiles();
    }
}

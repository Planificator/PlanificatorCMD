using PlanificatorCMD.Core;
using System.Collections.Generic;

namespace PlanificatorCMD
{
    public interface ISpeakerRepository
    {
        void AddSpeakerProfile(SpeakerProfile speaker);
        ICollection<SpeakerProfile> GetAllSpeakersProfiles();
        int GetMaxId();
        int GetSpeakersCount();
        SpeakerProfile GetSpeakerBySpeakerId(int speakerId);
    }
}
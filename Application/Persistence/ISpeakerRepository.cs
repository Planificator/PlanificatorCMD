using Application.Core;
using System.Collections.Generic;

namespace Application.Persistence
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
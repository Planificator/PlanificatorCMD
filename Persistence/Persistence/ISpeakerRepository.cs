using Domain.Core;
using System.Collections.Generic;

namespace Persistence.Persistence
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
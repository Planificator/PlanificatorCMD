using Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Persistence
{
    public interface ISpeakerRepository
    {
        ICollection<SpeakerProfile> GetAllSpeakersProfiles();

        int GetSpeakersCount();

        SpeakerProfile GetSpeakerBySpeakerId(string speakerId);

        Task<SpeakerProfile> GetSpeakerBySpeakerEmailAsync(string email);

        Task<SpeakerProfile> GetSpeakerBySpeakerEmailIncludingRelationshipsAsync(string email);
    }
}
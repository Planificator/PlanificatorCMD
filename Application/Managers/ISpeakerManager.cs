using Domain.Core;

namespace Application.Managers
{
    public interface ISpeakerManager
    {
        void AddSpeakerProfile(SpeakerProfile speaker);

        int GetSpeakersCount();

        SpeakerProfile GetSpeakerBySpeakerId(int speakerId);
    }
}
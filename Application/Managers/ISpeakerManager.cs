using Domain.Core;

namespace Application.Managers
{
    public interface ISpeakerManager
    {
        void AddSpeakerProfile(SpeakerProfile speaker);
        void UpdateSpeaker(SpeakerProfile speaker);
    }
}
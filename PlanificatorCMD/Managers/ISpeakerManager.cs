using PlanificatorCMD.Core;

namespace PlanificatorCMD
{
    public interface ISpeakerManager
    {
        void AddSpeakerProfile(SpeakerProfile speaker);

        int GetSpeakersCount();

        SpeakerProfile GetSpeakerBySpeakerId(int speakerId);
    }
}
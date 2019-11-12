using PlanificatorCMD.Core;

namespace PlanificatorCMD
{
    public interface ISpeakerManager
    {
        void AddSpeakerProfile(SpeakerProfile speaker);

        //int ShowSpeakersProfiles(bool DisplayOption);
        int GetSpeakersCount();

        SpeakerProfile GetSpeakerBySpeakerIndex(int speakerIndex);
    }
}
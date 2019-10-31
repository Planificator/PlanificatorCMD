using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD
{
    public interface ISpeakerManager
    {
        public void AddSpeakerProfile(SpeakerProfile speaker);

        public int ShowSpeakersProfiles(IShowAllSpeakersVerb showAllSpeakersVerb);
    }
}

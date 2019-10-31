using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD
{
    public interface ISpeakerManager
    {
        public void AddSpeakerProfile(IAddSpeakerVerb addSpeakerVerb);

        public int ShowSpeakersProfiles(IShowAllSpeakersVerb showAllSpeakersVerb);
    }
}

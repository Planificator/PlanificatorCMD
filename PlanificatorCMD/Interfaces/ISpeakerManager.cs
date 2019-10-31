using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD
{
    interface ISpeakerManager
    {
        public void AddSpeakerProfile(IAddSpeakerVerb addSpeakerVerb);

        public void ShowSpeakersProfiles();
    }
}

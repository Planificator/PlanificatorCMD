using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.DataProcessing
{
    public interface IAddSpeakerVerbProcessing
    {
        int AddSpeaker(IAddSpeakerVerb addSpeakerVerb);
    }
}
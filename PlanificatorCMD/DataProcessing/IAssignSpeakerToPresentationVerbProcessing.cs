using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.DataProcessing
{
    public interface IAssignSpeakerToPresentationVerbProcessing
    {
        int AssignSpeakerToPresentation(IAssignSpeakerToPresentationVerb assignSpeakerToPresentationVerb);
    }
}
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.Validators
{
    public interface IAddSpeakerVerbValidator
    {
        bool IsValid(IAddSpeakerVerb addSpeakerVerb);
    }
}
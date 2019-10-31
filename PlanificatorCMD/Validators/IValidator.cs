using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.Validators
{
    public interface IValidator
    {
        int IsValid(IAddSpeakerVerb addSpeakerVerb);
    }
}
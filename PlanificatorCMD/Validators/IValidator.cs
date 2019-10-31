using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.Validators
{
    public interface IValidator
    {
        int IsValid(AddSpeakerVerb addSpeakerVerb);
    }
}
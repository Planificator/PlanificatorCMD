using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.Validators
{
    public interface IAddPresentationVerbValidator
    {
        bool IsValid(IAddPresentationVerb addPresentationVerb, SpeakerProfile presentationOwner);

    }
}
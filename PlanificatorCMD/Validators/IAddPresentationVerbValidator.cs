using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.Validators
{
    interface IAddPresentationVerbValidator
    {
        bool IsValid(IAddPresentationVerb addPresentationVerb);
    }
}
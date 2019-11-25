using Domain.Core;

namespace PlanificatorCMD.Validators
{
    public interface IAssignSpeakerToPresentationVerbValidator
    {
        bool IsValid(SpeakerProfile speakerProfile, Presentation presentation);
    }
}
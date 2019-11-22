using Application.Managers;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.DataProcessing
{
    public class AssignSpeakerToPresentationVerbProcessing : IAssignSpeakerToPresentationVerbProcessing
    {
        private readonly IPresentationManager _presentationManager;
        private readonly ISpeakerManager _speakerManager;
        private readonly IAssignSpeakerToPresentationVerbValidator _validator;

        public AssignSpeakerToPresentationVerbProcessing(IPresentationManager presentationManager, ISpeakerManager speakerManager, IAssignSpeakerToPresentationVerbValidator validator)
        {
            _presentationManager = presentationManager;
            _speakerManager = speakerManager;
            _validator = validator;
        }

        public int AssignSpeakerToPresentation(IAssignSpeakerToPresentationVerb assignSpeakerToPresentationVerb)
        {
            var speakerId = assignSpeakerToPresentationVerb.SpeakerId;
            var presentationId = assignSpeakerToPresentationVerb.PresentationId;
            var speaker = _speakerManager.GetSpeakerBySpeakerId(speakerId);
            var presentation = _presentationManager.GetPresentationById(presentationId);

            if (!_validator.IsValid(speaker, presentation))
                return ExecutionResult.Fail;

            _presentationManager.AssignSpeakerToPresentation(speaker, presentation);
            return ExecutionResult.Succes;
        }
    }
}
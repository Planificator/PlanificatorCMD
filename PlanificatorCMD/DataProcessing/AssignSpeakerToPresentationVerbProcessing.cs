using Application.Managers;
using Persistence.Persistence;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.DataProcessing
{
    public class AssignSpeakerToPresentationVerbProcessing : IAssignSpeakerToPresentationVerbProcessing
    {
        private readonly IPresentationManager _presentationManager;
        private readonly IPresentationRepository _presentationRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IAssignSpeakerToPresentationVerbValidator _validator;

        public AssignSpeakerToPresentationVerbProcessing(IPresentationManager presentationManager, IPresentationRepository presentationRepository, ISpeakerRepository speakerRepository, IAssignSpeakerToPresentationVerbValidator validator)
        {
            _presentationManager = presentationManager;
            _presentationRepository = presentationRepository;
            _speakerRepository = speakerRepository;
            _validator = validator;
        }

        public int AssignSpeakerToPresentation(IAssignSpeakerToPresentationVerb assignSpeakerToPresentationVerb)
        {
            var speakerId = assignSpeakerToPresentationVerb.SpeakerId;
            var presentationId = assignSpeakerToPresentationVerb.PresentationId;
            var speaker = _speakerRepository.GetSpeakerBySpeakerId(speakerId);
            var presentation = _presentationRepository.GetPresentationById(presentationId);

            if (!_validator.IsValid(speaker, presentation))
                return ExecutionResult.Fail;

            _presentationManager.AssignSpeakerToPresentation(speaker, presentation);
            return ExecutionResult.Succes;
        }
    }
}
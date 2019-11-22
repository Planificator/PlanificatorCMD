using Application.Managers;
using Application.Persistence;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.DataProcessing
{
    public class AddPresentationVerbProcessing : IAddPresentationVerbProcessing
    {
        private readonly IAddPresentationVerbValidator _presentationValidator;
        private readonly IPresentationMapper _presentationMapper;
        private readonly IPresentationManager _presentationManager;
        private readonly ISpeakerRepository _speakerRepository;

        public AddPresentationVerbProcessing(IAddPresentationVerbValidator presentationValidator, IPresentationMapper presentationMapper, IPresentationManager presentationManager, ISpeakerRepository speakerRepository)
        {
            _presentationValidator = presentationValidator;
            _presentationMapper = presentationMapper;
            _presentationManager = presentationManager;
            _speakerRepository = speakerRepository;
        }

        public int AddPresentation(IAddPresentationVerb addPresentationVerb)
        {
            var presentationOwner = _speakerRepository.GetSpeakerBySpeakerId(addPresentationVerb.PresentationOwnerSpeakerId);
            if (!_presentationValidator.IsValid(addPresentationVerb, presentationOwner))
            {
                return ExecutionResult.Fail;
            }
            var presentationTags = _presentationMapper.MapToPresentationTag(addPresentationVerb, presentationOwner);
            _presentationManager.AddPresentation(presentationTags);

            return ExecutionResult.Succes;
        }
    }
}
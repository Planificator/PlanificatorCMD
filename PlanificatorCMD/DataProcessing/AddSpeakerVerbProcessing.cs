using Application.Managers;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.DataProcessing
{
    public class AddSpeakerVerbProcessing : IAddSpeakerVerbProcessing
    {
        private readonly IAddSpeakerVerbValidator _validatorSpeaker;
        private readonly ISpeakerProfileMapper _speakerProfileMapper;
        private readonly ISpeakerManager _speakerManager;

        public AddSpeakerVerbProcessing(IAddSpeakerVerbValidator validator, ISpeakerProfileMapper speakerProfileMapper, ISpeakerManager speakerManager)
        {
            _validatorSpeaker = validator;
            _speakerProfileMapper = speakerProfileMapper;
            _speakerManager = speakerManager;
        }

        public int AddSpeaker(IAddSpeakerVerb addSpeakerVerb)
        {
            if (!_validatorSpeaker.IsValid(addSpeakerVerb))
            {
                return ExecutionResult.Fail;
            }

            _speakerManager.AddSpeakerProfile(_speakerProfileMapper.MapToSpeaker(addSpeakerVerb));

            return ExecutionResult.Succes;
        }
    }
}
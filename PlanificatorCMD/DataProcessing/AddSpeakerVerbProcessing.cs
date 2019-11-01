using PlanificatorCMD.Utils;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Text;

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
                return 1;
            }

            _speakerManager.AddSpeakerProfile(_speakerProfileMapper.MapToSpeaker(addSpeakerVerb));

            return 0;
        }
    }
}

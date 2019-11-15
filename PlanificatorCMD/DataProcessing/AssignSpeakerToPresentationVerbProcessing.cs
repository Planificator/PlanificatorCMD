using PlanificatorCMD.Managers;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Text;

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
            var speakerIndex = assignSpeakerToPresentationVerb.SpeakerIndex - 1;
            var presentationIndex = assignSpeakerToPresentationVerb.PresentationIndex - 1;
            var speakersCount = _speakerManager.GetSpeakersCount();
            var presentatiosCount = _presentationManager.GetPresentationsCount();

            if (!_validator.IsValid(speakerIndex, speakersCount)
                || !_validator.IsValid(presentationIndex, presentatiosCount))
            {
                return ExecutionResult.Fail;
            }
            var speaker = _speakerManager.GetSpeakerBySpeakerId(speakerIndex);
            //_presentationManager.AssignSpeakerToPresentation(speaker, presentationIndex);
            return ExecutionResult.Succes;
        }


    }
}

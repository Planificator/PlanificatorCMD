using PlanificatorCMD.Managers;
using PlanificatorCMD.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.DataProcessing
{
    public class AssignSpeakerToPresentationVerbProcessing
    {
        private IPresentationManager _presentationManager;
        private ISpeakerManager _speakerManager;
        private IAssignSpeakerToPresentationVerbValidator _validator;

        public AssignSpeakerToPresentationVerbProcessing(IPresentationManager presentationManager, ISpeakerManager speakerManager, IAssignSpeakerToPresentationVerbValidator validator)
        {
            _presentationManager = presentationManager;
            _speakerManager = speakerManager;
            _validator = validator;
        }

        public int AssignSpeakerToPresentation(IAssignSpeakerToPresentationVerb assignSpeakerToPresentationVerb)
        {
            var speakerIndex = assignSpeakerToPresentationVerb.speakerIndex - 1;
            var presentationIndex = assignSpeakerToPresentationVerb.presentationIndex - 1;
            var speakersCount = _speakerManager.GetSpeakersCount();
            var presentatiosCount = _presentationManager.GetPresentationsCount();

            if (!_validator.IsValid(speakerIndex, speakersCount) 
                || !_validator.IsValid(presentationIndex, presentatiosCount))
            {
                return 1;
            }
            return 0;
        }
    }
}

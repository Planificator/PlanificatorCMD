using PlanificatorCMD.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PlanificatorCMD.Validators
{
    public class AssignSpeakerToPresentationVerbValidator : IAssignSpeakerToPresentationVerbValidator
    {
        public bool IsValid(SpeakerProfile speakerProfile, Presentation presentation)
        {
            if (speakerProfile == null || presentation == null)
                return false;
            if (presentation.PresentationSpeakers != null)
            {
                var presentationSpeakersId = presentation.PresentationSpeakers.Select(p => p.SpeakerId).ToList();
                if (!IsAlreadyAssigned(speakerProfile.SpeakerId, presentationSpeakersId))
                    return false;
            }
            if (!IsAlreadyOwner(speakerProfile.SpeakerId, presentation.PresentationOwner.SpeakerId))
                return false;
            return true;
        }

        private bool IsAlreadyAssigned(int speakerProfileId, ICollection<int> presentationSpeakersId)
        {
            foreach(int presentationSpeakerId in presentationSpeakersId)
            {
                if (speakerProfileId == presentationSpeakerId) 
                    return false;
            }
            return true;
        }
        private bool IsAlreadyOwner(int speakerProfileId, int presentationOwnerId)
        {
            if (speakerProfileId == presentationOwnerId)
                return false;
            return true;
        }




        //public bool IsValid(int index, int totalCount)
        //{
        //    if (index >= 0 && totalCount >= 0 && index <= totalCount)
        //        return true;
        //    return false;
        //}
    }
}

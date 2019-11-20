using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanificatorCMD.Validators
{
    public class AssignSpeakerToPresentationVerbValidator : IAssignSpeakerToPresentationVerbValidator
    {
        public bool IsValid(SpeakerProfile speakerProfile, Presentation presentation)
        {
            if (speakerProfile == null || presentation == null)
            {
                throw new ArgumentException("Speaker or presentation does not exist");
            }

            if (IsAlreadyOwner(speakerProfile.SpeakerId, presentation.PresentationOwner.SpeakerId))
            {
                throw new ArgumentException("Exception. Speaker is already Owner");
            }
            if (presentation.PresentationSpeakers != null)
            {
                var presentationSpeakersId = presentation.PresentationSpeakers.Select(p => p.SpeakerId).ToList();
                if (IsAlreadyAssigned(speakerProfile.SpeakerId, presentationSpeakersId))
                {
                    throw new ArgumentException("Exception. Speaker is already assigned");
                }
            }
            return true;
        }

        private bool IsAlreadyAssigned(int speakerProfileId, ICollection<int> presentationSpeakersId)
        {
            if (presentationSpeakersId.Contains(speakerProfileId))
                return true;
            return false;
        }

        private bool IsAlreadyOwner(int speakerProfileId, int presentationOwnerId)
        {
            if (speakerProfileId == presentationOwnerId)
                return true;
            return false;
        }
    }
}
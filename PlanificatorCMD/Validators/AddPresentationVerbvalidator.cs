using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanificatorCMD.Validators
{
    public class AddPresentationVerbValidator : IAddPresentationVerbValidator
    {
        public bool IsValid(IAddPresentationVerb addPresentationVerb, SpeakerProfile presentationOwner)
        {
            if (!IsValidPresentationOwner(presentationOwner))
            {
                throw new ArgumentException("Speaker by selected Id is not existing", nameof(addPresentationVerb.PresentationOwnerSpeakerId));
            }
            if (!IsValidTitle(addPresentationVerb.Title))
            {
                throw new ArgumentException("Incorrect insert of the title", nameof(addPresentationVerb.Title));
            }
            if (!IsValidShortDescription(addPresentationVerb.ShortDescription))
            {
                throw new ArgumentException("Incorrect insert of the short description", nameof(addPresentationVerb.ShortDescription));
            }
            if (!IsValidLongDescription(addPresentationVerb.LongDescription))
            {
                throw new ArgumentException("Incorrect insert of the long description", nameof(addPresentationVerb.LongDescription));
            }
            if (!IsValidTags(addPresentationVerb.Tags))
            {
                throw new ArgumentException("Enter the tag", nameof(addPresentationVerb.Tags));
            }
            
            return true;

        }

        private bool IsValidPresentationOwner(SpeakerProfile presentationOwner)
        {
            if (presentationOwner == null)
                return false;
            return true;
        }

        private bool IsValidTags(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return false;
            }

            return true;
        }

        private bool IsValidLongDescription(string longDescription)
        {
            if (string.IsNullOrEmpty(longDescription) || longDescription.Length > 800)
            {
                return false;
            }

            return true;
        }

        private bool IsValidShortDescription(string shortDescription)
        {
            if (string.IsNullOrEmpty(shortDescription) || shortDescription.Length > 200)
            {
                return false;
            }

            return true;
        }

        private bool IsValidTitle(string title)
        {
            if (string.IsNullOrEmpty(title) || title.Length > 100)
            {
                return false;
            }

            return true;
        }
    }
}

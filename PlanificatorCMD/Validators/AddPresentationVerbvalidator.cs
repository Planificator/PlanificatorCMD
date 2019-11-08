using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanificatorCMD.Validators
{
    public class AddPresentationVerbValidator : IAddPresentationVerbValidator
    {
        public bool IsValid(IAddPresentationVerb addPresentationVerb)
        {

            if (!IsValidTitle(addPresentationVerb.Title))
            {
                return false;
            }
            if (!IsValidShortDescription(addPresentationVerb.ShortDescription))
            {
                return false;
            }
            if (!IsValidLongDescription(addPresentationVerb.LongDescription))
            {
                return false;
            }
            if (!IsValidTags(addPresentationVerb.Tags))
            {
                return false;
            }

            return true;

        }

        private bool IsValidTags(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentException("Enter the tag", nameof(tag));
            }

            return true;
        }

        private bool IsValidLongDescription(string longDescription)
        {
            if (string.IsNullOrEmpty(longDescription))
            {
                throw new ArgumentException("Enter the long description", nameof(longDescription));
            }

            if (longDescription.Length > 800)
            {
                throw new ArgumentException("Long description is too long", nameof(longDescription));
            }

            return true;
        }

        private bool IsValidShortDescription(string shortDescription)
        {
            if (string.IsNullOrEmpty(shortDescription))
            {
                throw new ArgumentException("Enter the Short Description", nameof(shortDescription));
            }

            if (shortDescription.Length > 200)
            {
                throw new ArgumentException("ShortDescription is too long", nameof(shortDescription));
            }

            return true;
        }

        private bool IsValidTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Enter the title of the presentation", nameof(title));
            }

            if (title.Length > 100)
            {
                throw new ArgumentException("Title is too long", nameof(title));
            }
            return true;
        }
    }
}

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
            bool res = true;
            if (!IsValidTitle(addPresentationVerb.Title))
                res = false;
            if (!IsValidShortDescription(addPresentationVerb.ShortDescription))
                res = false;
            if (!IsValidLongDescription(addPresentationVerb.LongDescription))
                res = false;
            if (!IsValidTags(addPresentationVerb.Tags))
                res = false;

            return res;

        }

        private bool IsValidTags(string a)
        {
            if (a == null || a == String.Empty)
            {
                Console.WriteLine("Enter Tags");
                return false;
            }

            return true;
        }

        private bool IsValidLongDescription(string a)
        {
            if (a == null || a == String.Empty)
            {
                Console.WriteLine("Enter the long description");
                return false;
            }

            if (a.Length > 800)
            {
                Console.WriteLine("Long description is too long");
                return false;
            }
      
            return true;
        }

        private bool IsValidShortDescription(string a)
        {
            if (a == null || a == String.Empty)
            {
                Console.WriteLine("Enter the Short Description");
                return false;
            }

            if (a.Length > 200)
            {
                Console.WriteLine("ShortDescription is too long");
                return false;
            }       

            return true;
        }

        private bool IsValidTitle(string a)
        {
            if (a == null || a == String.Empty)
            {
                Console.WriteLine("Enter the title of the presentation");
                return false;
            }

            if (a.Length > 100)
            {
                Console.WriteLine("Title is too long");
                return false;
            }

            return true;
        }
    }
}

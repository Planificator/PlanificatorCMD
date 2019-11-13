using PlanificatorCMD.Verbs;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PlanificatorCMD.Validators
{
    public class AddSpeakerVerbValidator : IAddSpeakerVerbValidator
    {
        public bool IsValid(IAddSpeakerVerb addSpeakerVerb)
        {
            if(!IsValidEmail(addSpeakerVerb.Email))
            {
                throw new ArgumentException("Incorrect format of email", nameof(addSpeakerVerb.Email));
            }

            if(!IsValidPath(addSpeakerVerb.PhotoPath))
            {
                throw new ArgumentException("Invalid path", nameof(addSpeakerVerb.PhotoPath));
            }

            if(!IsValidFormat(addSpeakerVerb.PhotoPath))
            {
                throw new ArgumentException("Not supported format", nameof(addSpeakerVerb.PhotoPath));
            }

            return true;
        }

        private bool IsValidFormat(string path)
        {
            string[] imageEndsWith = { ".JPG" };
            string extension = Path.GetExtension(path);
            if (StringComparer.InvariantCultureIgnoreCase.Compare(extension,imageEndsWith) < 0)
            {
                return false;
            }

            return true;
        }

        public bool IsValidEmail(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsValidPath(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            return true;
        }
    }
}
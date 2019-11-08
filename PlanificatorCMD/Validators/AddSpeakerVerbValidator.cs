using PlanificatorCMD.Utils;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PlanificatorCMD.Validators
{
    public class AddSpeakerVerbValidator : IAddSpeakerVerbValidator
    {

        public bool IsValid(IAddSpeakerVerb addSpeakerVerb)
        {
            if (!IsValidEmail(addSpeakerVerb.Email))
            {
                return false;
            }
            if (!IsValidPath(addSpeakerVerb.PhotoPath))
            {
                return false;
            }
            if (!IsValidFormat(addSpeakerVerb.PhotoPath))
            {
                return false;
            }

            return true;

        }
        private bool IsValidFormat(string path)
        {
            string[] imageEndsWith = { ".jpg" };
            string extension = Path.GetExtension(path);
            if (StringComparer.InvariantCultureIgnoreCase.Compare(extension, imageEndsWith.ToString()) < 0)
                throw new ArgumentException("Not supported format", nameof(extension));

            return true;

        }
        public static bool IsValidEmail(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            throw new ArgumentException("Incorrect format of email", nameof(email));
        }
        private bool IsValidPath(string path)
        {
            Regex r = new Regex(@"^(([a-zA-Z]:)|(\))(\{1}|((\{1})[^\]([^/:*?<>""|]*))+)$");
            if (!r.IsMatch(path))
                throw new ArgumentException("Invalid path", path);
            return true;
        }
    }
}


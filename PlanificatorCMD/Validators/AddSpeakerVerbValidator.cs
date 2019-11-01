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
                Console.WriteLine("Incorrect format of email");
                return false;
            }
            if (!IsValidPath(addSpeakerVerb.PhotoPath))
            {
                Console.WriteLine("Invalid path");
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
            string[] imageEndsWith = { ".jpg", ".JPG" };
            if (imageEndsWith.Any(x => path.EndsWith(x)))
            {
                return true;
            }
            else
            {
                Console.WriteLine("The format of image is not supported");
                return false;
            }
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private bool IsValidPath(string path)
        {
            bool isValid = true;

            try
            {
                string fullPath = Path.GetFullPath(path);
                string root = Path.GetPathRoot(path);
                isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                isValid = Path.IsPathRooted(path);
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}


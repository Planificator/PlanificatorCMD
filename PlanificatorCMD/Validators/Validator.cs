﻿using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PlanificatorCMD.Validators
{
    public class Validator : IValidator
    {
        private readonly ISpeakerManager _speakerManager;

        public Validator(ISpeakerManager speakerManager)
        {
            _speakerManager = speakerManager;
        }

        public int IsValid(AddSpeakerVerb addSpeakerVerb)
        {
            if (!IsValidEmail(addSpeakerVerb.Email))
            {
                return 1;
            }
            else if (!IsValidPath(addSpeakerVerb.PhotoPath))
            {
                Console.WriteLine("Invalid path");
                return 1;
            }
            else if (!IsValidFormat(addSpeakerVerb.PhotoPath))
            {
                return 1;
            }
            else
            {
                _speakerManager.AddSpeakerProfile(addSpeakerVerb);
                return 0;
            }
        }
        private bool IsValidFormat(string path)
        {
            string[] imageEndsWith = {".jpg", ".JPG" };
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
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                Console.WriteLine("Incorrect type of email insert");
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
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}

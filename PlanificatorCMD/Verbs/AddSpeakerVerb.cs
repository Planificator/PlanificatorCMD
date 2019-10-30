using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace PlanificatorCMD.Verbs
{
    [Verb("add_speaker", HelpText = "adding a new speaker")]
    public class AddSpeakerVerb : IAddSpeakerVerb
    {
        [Option('f', "firstname", Required = true, HelpText = "Inserting Firstname")]
        public string FirstName { get; set; }

        [Option('l', "lastname", Required = true, HelpText = "Inserting Lastname")]
        public string LastName { get; set; }

        [Option('e', "email", Required = true, HelpText = "Inserting the Email")]
        public string Email { get; set; }

        [Option('p', "photo", Required = true, HelpText = "Introducting the path to the photo ")]
        public string PhotoPath { get; set; }

        [Option('b', "bio", Required = true, HelpText = "Inserting the bio")]
        public string Bio { get; set; }

        [Option('c', "company", Required = false, HelpText = "Inserting the company")]
        public string Company { get; set; }

    }
}

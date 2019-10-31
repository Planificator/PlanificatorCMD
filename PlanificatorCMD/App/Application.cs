using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD
{
    public class Application : IApplication
    {
        private readonly IValidator _validator;

        public Application(IValidator validator)
        {
            _validator = validator;
        }
        public void Run(string[] args)
        {
            Parser.Default.ParseArguments<AddSpeakerVerb>(args)
               .WithParsed<AddSpeakerVerb>(opt => _validator.IsValid(opt));
        }
    }
}

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
        private readonly ISpeakerManager _speakerManager;

        public Application(IValidator validator, ISpeakerManager speakerManager)
        {
            _validator = validator; 
            _speakerManager = speakerManager;
        }
        public void Run(string[] args)
        {
            Parser.Default.ParseArguments<AddSpeakerVerb, ShowAllSpeakersVerb>(args)
            .MapResult(
                (AddSpeakerVerb opts) => _validator.IsValid(opts),
                (ShowAllSpeakersVerb opts) => _speakerManager.ShowSpeakersProfiles(opts),
                errs => 1
                );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD
{
    public class Application : IApplication
    {
        private readonly IAddSpeakerVerbProcessing _addSpeakerVerbProcessing;
        private readonly ISpeakerManager _speakerManager;

        public Application(IAddSpeakerVerbProcessing addSpeakerVerbProcessing, ISpeakerManager speakerManager)
        {
            _addSpeakerVerbProcessing = addSpeakerVerbProcessing;
            _speakerManager = speakerManager;
        }
        public void Run(string[] args)
        {
            Parser.Default.ParseArguments<AddSpeakerVerb, ShowAllSpeakersVerb>(args)
            .MapResult(
                (AddSpeakerVerb opts) => _addSpeakerVerbProcessing.AddSpeaker(opts),
                (ShowAllSpeakersVerb opts) => _speakerManager.ShowSpeakersProfiles(opts.DisplayOption),
                errs => 1
                );
        }
    }
}

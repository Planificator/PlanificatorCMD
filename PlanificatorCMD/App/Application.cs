using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Managers;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD
{
    public class Application : IApplication
    {
        private readonly IPresentationManager _presentationManager;
        private readonly IAddSpeakerVerbProcessing _addSpeakerVerbProcessing;
        private readonly ISpeakerManager _speakerManager;

        public Application(IAddSpeakerVerbProcessing addSpeakerVerbProcessing, ISpeakerManager speakerManager, IPresentationManager presentationManager)
        {
            _presentationManager = presentationManager;
            _addSpeakerVerbProcessing = addSpeakerVerbProcessing;
            _speakerManager = speakerManager;
        }
        public void Run(string[] args)
        {
            Parser.Default.ParseArguments<AddSpeakerVerb, ShowAllSpeakersVerb,ShowAllPresentation>(args)
            .MapResult(
                (AddSpeakerVerb opts) => _addSpeakerVerbProcessing.AddSpeaker(opts),
                (ShowAllSpeakersVerb opts) => _speakerManager.ShowSpeakersProfiles(opts.DisplayOption),
                (ShowAllPresentation opts) => _presentationManager.ShowAllPresentation(opts.DisplayOption),
                errs => 1
                );
        }
    }
}

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
        private readonly IAddPresentationVerbProcessing _addPresentationVerbProcessing;

        public Application(IAddPresentationVerbProcessing addPresentationVerbProcessing, IAddSpeakerVerbProcessing addSpeakerVerbProcessing, ISpeakerManager speakerManager, IPresentationManager presentationManager)
        {
            _addPresentationVerbProcessing = addPresentationVerbProcessing;
            _presentationManager = presentationManager;
            _addSpeakerVerbProcessing = addSpeakerVerbProcessing;
            _speakerManager = speakerManager;
        }
        public void Run(string[] args)
        {

            try
            {
                Parser.Default.ParseArguments<AddSpeakerVerb, ShowAllSpeakersVerb, AddPresentationVerb ,ShowAllPresentation, AssignSpeakerToPresentationVerb>(args)
                .MapResult(
                    (AddSpeakerVerb opts) => _addSpeakerVerbProcessing.AddSpeaker(opts),
                    (ShowAllSpeakersVerb opts) => _speakerManager.ShowSpeakersProfiles(opts.DisplayOption),
                    (AddPresentationVerb opts) => _addPresentationVerbProcessing.AddPresentation(opts),
                    (ShowAllPresentation opts) => _presentationManager.ShowAllPresentation(opts.DisplayOption),
                    errs => 1
                    );

            }
            catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }
}

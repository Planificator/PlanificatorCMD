using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Managers;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD
{
    public class Application : IApplication
    {
        private readonly IAddSpeakerVerbProcessing _addSpeakerVerbProcessing;
        private readonly IAddPresentationVerbProcessing _addPresentationVerbProcessing;
        private readonly IAssignSpeakerToPresentationVerbProcessing _assignSpeakerToPresentationVerbProcessing;
        private readonly IDisplayPresentations _displayPresentations;
        private readonly IDisplaySpeakers _displaySpeakers;

        public Application(IAddPresentationVerbProcessing addPresentationVerbProcessing, IAddSpeakerVerbProcessing addSpeakerVerbProcessing, IAssignSpeakerToPresentationVerbProcessing assignSpeakerToPresentationVerbProcessing, IDisplayPresentations displayPresentations, IDisplaySpeakers displaySpeakers)
        {
            _addPresentationVerbProcessing = addPresentationVerbProcessing;
            _addSpeakerVerbProcessing = addSpeakerVerbProcessing;
            _assignSpeakerToPresentationVerbProcessing = assignSpeakerToPresentationVerbProcessing;
            _displayPresentations = displayPresentations;
            _displaySpeakers = displaySpeakers;
        }
        public void Run(string[] args)
        {

            try
            {
                Parser.Default.ParseArguments<AddSpeakerVerb, ShowAllSpeakersVerb, AddPresentationVerb ,ShowAllPresentation, AssignSpeakerToPresentationVerb>(args)
                .MapResult(
                    (AddSpeakerVerb opts) => _addSpeakerVerbProcessing.AddSpeaker(opts),
                    (ShowAllSpeakersVerb opts) => _displaySpeakers.DisplayAllSpeakers(opts.DisplayOption),
                    (AddPresentationVerb opts) => _addPresentationVerbProcessing.AddPresentation(opts),
                    (ShowAllPresentation opts) => _displayPresentations.ShowAllPresentations(opts.DisplayOption),
                    (AssignSpeakerToPresentationVerb opts) => _assignSpeakerToPresentationVerbProcessing.AssignSpeakerToPresentation(opts),
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

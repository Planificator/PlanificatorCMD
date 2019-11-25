using CommandLine;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Verbs;
using System;

namespace PlanificatorCMD
{
    public class Application : IApplication
    {
        private readonly IDisplaySpeakers _displaySpeakers;
        private readonly IAddSpeakerVerbProcessing _addSpeakerVerbProcessing;
        private readonly IDisplayPresentations _displayPresentations;
        private readonly IAddPresentationVerbProcessing _addPresentationVerbProcessing;
        private readonly IAssignSpeakerToPresentationVerbProcessing _assignSpeakerToPresentationVerbProcessing;

        public Application(IAddPresentationVerbProcessing addPresentationVerbProcessing, IAddSpeakerVerbProcessing addSpeakerVerbProcessing, IDisplaySpeakers displaySpeakers, IDisplayPresentations displayPresentations, IAssignSpeakerToPresentationVerbProcessing assignSpeakerToPresentationVerbProcessing)
        {
            _addPresentationVerbProcessing = addPresentationVerbProcessing;
            _displaySpeakers = displaySpeakers;
            _addSpeakerVerbProcessing = addSpeakerVerbProcessing;
            _displayPresentations = displayPresentations;
            _assignSpeakerToPresentationVerbProcessing = assignSpeakerToPresentationVerbProcessing;
        }

        public void Run(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<AddSpeakerVerb, ShowAllSpeakersVerb, AddPresentationVerb, ShowAllPresentation, AssignSpeakerToPresentationVerb>(args)
                .MapResult(
                    (AddSpeakerVerb opts) => _addSpeakerVerbProcessing.AddSpeaker(opts),
                    (ShowAllSpeakersVerb opts) => _displaySpeakers.DisplayAllSpeakers(opts.DisplayOption),
                    (AddPresentationVerb opts) => _addPresentationVerbProcessing.AddPresentation(opts),
                    (ShowAllPresentation opts) => _displayPresentations.DisplayAllPresentations(opts.DisplayOption),
                    (AssignSpeakerToPresentationVerb opts) => _assignSpeakerToPresentationVerbProcessing.AssignSpeakerToPresentation(opts),
                    errs => 1
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
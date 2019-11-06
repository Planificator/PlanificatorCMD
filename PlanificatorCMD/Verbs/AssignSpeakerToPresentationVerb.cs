using CommandLine;

namespace PlanificatorCMD.Verbs
{
    [Verb("assign_speaker_to_presentation", HelpText = "Assign a Speaker to a Presentation")]
    class AssignSpeakerToPresentationVerb : IAssignSpeakerToPresentationVerb
    {
        [Option('s', "speakerIndex", Required = true, HelpText = "Inserting Speker Index which is shown in firs column in show_speakers verb")]
        public int SpeakerIndex { get; set; }

        [Option('p', "presentationIndex", Required = true, HelpText = "Inserting Speker Index which is shown in firs column in show_presentation verb")]
        public int PresentationIndex { get; set; }
    }
}

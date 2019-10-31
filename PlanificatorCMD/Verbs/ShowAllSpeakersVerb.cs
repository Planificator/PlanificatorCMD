using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Verbs
{
    [Verb("show_speakers", HelpText = "Showing all speakers")]
    public class ShowAllSpeakersVerb : IShowAllSpeakersVerb
    {
        [Option('o',"option", HelpText = "Display Option: \"True\" - Showing all Speaker info.", Default = false)]
        public bool DisplayOption { get; set; }
    }
}

using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Verbs
{
    [Verb("show_speakers", HelpText = "Showing all speakers")]
    public class ShowSpeakersVerb : IShowSpeakersVerb
    {
        [Option('o',"option", HelpText = "Display Option: \"True\" - Showing all Speakers. \"False\" - Showing first 10 Speakers.", Default = false)]
        public bool DisplayOption { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace PlanificatorCMD.Verbs
{
    [Verb("show_presentations", HelpText = "Displaying all presentations")]
    public class ShowAllPresentation : IShowAllPresentation
    {
        [Option('o', "option", HelpText = "Display Option: \"True\" - Showing all Presentation info.", Required = false, Default = false)]
        public bool DisplayOption { get; set; }

    }
}

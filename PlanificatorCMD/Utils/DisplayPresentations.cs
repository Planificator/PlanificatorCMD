using PlanificatorCMD.Core;
using PlanificatorCMD.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanificatorCMD.Utils
{
    public class DisplayPresentation : IDisplayPresentation

    {
        public void DisplayAllPresentation(ICollection<string> tags, Presentation presentation, bool displayOption, IConsoleWrapper CW)
        {
            CW.WriteLine();
            if (displayOption == false)
            {
                CW.WriteLine(presentation.Title + " " + presentation.ShortDescription);
            }
            if (displayOption == true)
            {
                CW.Write(presentation.Title + " " + presentation.ShortDescription + " " + presentation.LongDescription + " ");
                foreach (var tag in tags)
                {
                    CW.Write(tag + " ");
                }
                CW.WriteLine();
                CW.WriteLine();

            }
        }
    }
}

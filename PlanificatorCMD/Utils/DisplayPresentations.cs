using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanificatorCMD.Utils
{
    public class DisplayPresentation : IDisplayPresentation

    {
        public void DisplayAllPresentation(ICollection<string> tags, Presentation presentation, bool displayOption)
        {
                Console.WriteLine();
            if (displayOption == false)
            {
                Console.WriteLine(presentation.Title + " " + presentation.ShortDescription);
            }
            if (displayOption == true)
            {
                Console.Write(presentation.Title + " " + presentation.ShortDescription + " " + presentation.LongDescription + " ");
                foreach (var tag in tags)
                {
                    Console.Write(tag + " ");
                }
                Console.WriteLine();
                Console.WriteLine();

            }
        }
    }
}

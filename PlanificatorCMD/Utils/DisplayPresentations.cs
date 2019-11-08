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
        private readonly IConsoleWrapper _cw;

        public DisplayPresentation(IConsoleWrapper cw)
        {
            _cw = cw;
        }
        public void DisplayAllPresentation(ICollection<string> tags, Presentation presentation, bool displayOption)
        {
            _cw.WriteLine();
            if (displayOption == false)
            {
                _cw.WriteLine(presentation.Title + " " + presentation.ShortDescription);
            }
            if (displayOption == true)
            {
                _cw.Write(presentation.Title + " " + presentation.ShortDescription + " " + presentation.LongDescription + " ");
                foreach (var tag in tags)
                {
                    _cw.Write(tag + " ");
                }
                _cw.WriteLine();
                _cw.WriteLine();

            }
        }
    }
}

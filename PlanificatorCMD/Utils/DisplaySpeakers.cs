using PlanificatorCMD.Core;
using PlanificatorCMD.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Utils
{
    public class DisplaySpeakers : IDisplaySpeakers
    {
        private readonly IConsoleWrapper _cw;

        public DisplaySpeakers(IConsoleWrapper cw)
        {
            _cw = cw;
        }
        public bool DisplayAllSpeakers(ICollection<SpeakerProfile> speakers, bool displayOption)
        {
            int i = 1;
            if (speakers == null)
            {
                _cw.WriteLine("No speakers found");
                return false;
            }
            if (displayOption == true)
                foreach (SpeakerProfile s in speakers)
                {
                    _cw.WriteLine(i++ + ")\t" + s.FirstName + " " + s.LastName + " " + s.Email + " " + s.Company + " " + s.Bio);
                }

            else
                foreach (var s in speakers)
                {
                    _cw.WriteLine(i++ + ")\t" + s.FirstName + " " + s.LastName);
                }
            return true;
        }
    }
}

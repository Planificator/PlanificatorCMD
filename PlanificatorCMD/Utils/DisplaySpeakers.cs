using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Utils
{
    public class DisplaySpeakers : IDisplaySpeakers
    {
        public bool DisplayAllSpeakers(ICollection<SpeakerProfile> speakers, bool displayOption)
        {
            int i = 1;
            if (speakers == null)
            {
                Console.WriteLine("No speakers found");
                return false;
            }
            if (displayOption == true)
                foreach (SpeakerProfile s in speakers)
                {
                    Console.WriteLine(i++ + ")\t" + s.FirstName + " " + s.LastName + " " + s.Email + " " + s.Company + " " + s.Bio);
                }

            else
                foreach (var s in speakers)
                {
                    Console.WriteLine(i++ + ")\t" + s.FirstName + " " + s.LastName);
                }
            return true;
        }
    }
}

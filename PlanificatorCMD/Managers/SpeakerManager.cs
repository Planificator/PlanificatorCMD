using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlanificatorCMD
{
    public class SpeakerManager : ISpeakerManager
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerManager(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public void AddSpeakerProfile(SpeakerProfile speaker)
        {
            _speakerRepository.AddSpeakerProfile(speaker);
        }

        public int ShowSpeakersProfiles(IShowAllSpeakersVerb showAllSpeakersVerb)
        {
            List<SpeakerProfile> speakersList = _speakerRepository.GetAllSpeakersProfiles();
            if (speakersList == null)
            {
                Console.WriteLine("No speakers found");
                return 1;
            }

            else if (showAllSpeakersVerb.DisplayOption == true)
                foreach (SpeakerProfile s in speakersList)
                {
                    Console.WriteLine(s.SpeakerId + ")\t" + s.FirstName + " " + s.LastName + " " + s.Email + " " + s.Company + " " + s.Bio);
                }

            else 
                foreach (var s in speakersList)
                {
                    Console.WriteLine(s.SpeakerId + ")\t" + s.FirstName + " " + s.LastName);
                }

            return 0;
        }
    }
}

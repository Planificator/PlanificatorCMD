using PlanificatorCMD.Core;
using PlanificatorCMD.Wrappers;
using System;
using System.Collections.Generic;

namespace PlanificatorCMD.Utils
{
    public class DisplaySpeakers : IDisplaySpeakers
    {
        private readonly IConsoleWrapper _consoleWrapper;
        private readonly ISpeakerRepository _speakerRepository;

        public DisplaySpeakers(ISpeakerRepository speakerRepository, IConsoleWrapper consoleWrapper)
        {
            _speakerRepository = speakerRepository;
            _consoleWrapper = consoleWrapper;
        }

        public int DisplayAllSpeakers(bool displayOption)
        {
            ICollection<SpeakerProfile> speakerProfiles = _speakerRepository.GetAllSpeakersProfiles();
            int i = 1;
            if (speakers == null)
            {
                _consoleWrapper.WriteLine("No speakers found");
                return ExecutionResult.Fail;
            }
            if (displayOption == true)
                foreach (SpeakerProfile s in speakers)
                {
                    _consoleWrapper.WriteLine(i++ + ")\t" + s.FirstName + " " + s.LastName + " " + s.Email + " " + s.Company + " " + s.Bio);
                }

            else
                foreach (var s in speakers)
                {
                    _consoleWrapper.WriteLine(i++ + ")\t" + s.FirstName + " " + s.LastName);
                }
            return true;
        }
    }
}

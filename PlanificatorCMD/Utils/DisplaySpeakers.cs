using Domain.Core;
using Persistence.Persistence;
using PlanificatorCMD.Wrappers;
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
            if (speakerProfiles == null)
            {
                _consoleWrapper.WriteLine("No speakers found");
                return ExecutionResult.Fail;
            }
            if (displayOption == true)
                foreach (SpeakerProfile s in speakerProfiles)
                {
                    _consoleWrapper.WriteLine(s.SpeakerId + ")\t" + s.FirstName + " " + s.LastName + " " + s.Email + " " + s.Company + " " + s.Bio);
                }
            else
                foreach (var s in speakerProfiles)
                {
                    _consoleWrapper.WriteLine(s.SpeakerId + ")\t" + s.FirstName + " " + s.LastName);
                }
            return ExecutionResult.Succes;
        }
    }
}
using PlanificatorCMD.Core;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace PlanificatorCMD.Utils
{
    public class DisplaySpeakers : IDisplaySpeakers
    {
        private readonly IConsoleWrapper _cw;
        private readonly PlanificatorDbContext _dbContext;

        public DisplaySpeakers(PlanificatorDbContext dbContext, IConsoleWrapper cw)
        {
            _cw = cw;
            _dbContext = dbContext;
        }
        public int DisplayAllSpeakers(bool displayOption)
        {
            ICollection<SpeakerProfile> speakerProfiles = GetAllSpeakersProfiles();
            int i = 1;
            if (speakerProfiles == null)
            {
                _cw.WriteLine("No speakers found");
                return ExecutionResult.Fail;
            }
            if (displayOption == true)
                foreach (SpeakerProfile s in speakerProfiles)
                {
                    _cw.WriteLine(i++ + ")\t" + s.FirstName + " " + s.LastName + " " + s.Email + " " + s.Company + " " + s.Bio);
                }

            else
                foreach (SpeakerProfile s in speakerProfiles)
                {
                    _cw.WriteLine(i++ + ")\t" + s.FirstName + " " + s.LastName);
                }
            return ExecutionResult.Succes;
        }

        private ICollection<SpeakerProfile> GetAllSpeakersProfiles()
        {
            if (_dbContext.SpeakerProfiles.Count() == 0)
                return null;
            return _dbContext.SpeakerProfiles.ToList();
        }
    }
}

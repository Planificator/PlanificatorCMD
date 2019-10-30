using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Core;

namespace PlanificatorCMD
{
    class SpeakerRepository : ISpeakerRepository
    {
        private readonly PlanificatorDbContext _dbContext;

        public SpeakerRepository(PlanificatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSpeakerProfile(SpeakerProfile speaker)
        {
            _dbContext.SpeakerProfiles.Add(speaker);
        }

        public int GetMaxId()
        {
            return _dbContext.SpeakerProfiles.Max(s => s.SpeakerId);
        }
  
        
    }
}

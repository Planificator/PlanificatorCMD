using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Core;

namespace PlanificatorCMD
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly PlanificatorDbContext _dbContext;

        public SpeakerRepository(PlanificatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSpeakerProfile(SpeakerProfile speaker)
        {
            _dbContext.SpeakerProfiles.Add(speaker);
            _dbContext.SaveChanges();
        }

        public int GetMaxId()
        {
            if (_dbContext.SpeakerProfiles.Count() == 0)
            {
                return 0;
            }
            return _dbContext.SpeakerProfiles.Max(s => s.Photo.PhotoId);
        }

        public int GetSpeakersCount()
        {
            return _dbContext.SpeakerProfiles.Count();
        }

        public SpeakerProfile GetSpeakerBySpeakerIndex(int index)
        {
            return _dbContext.SpeakerProfiles.ToList()[index];
        }

        public ICollection<SpeakerProfile> GetAllSpeakersProfiles()
        {
            if (_dbContext.SpeakerProfiles.Count() == 0)
                return null;
            return _dbContext.SpeakerProfiles.ToList();
        }
    }
}

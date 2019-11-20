using PlanificatorCMD.Core;
using System.Collections.Generic;
using System.Linq;

namespace PlanificatorCMD.Persistence
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

        public SpeakerProfile GetSpeakerBySpeakerId(int speakerId)
        {
            return _dbContext.SpeakerProfiles.SingleOrDefault(s => s.SpeakerId == speakerId);
        }

        public ICollection<SpeakerProfile> GetAllSpeakersProfiles()
        {
            if (_dbContext.SpeakerProfiles.Count() == 0)
                return null;
            return _dbContext.SpeakerProfiles.ToList();
        }
    }
}
using Domain.Core;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Persistence
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly PlanificatorDbContext _dbContext;

        public SpeakerRepository(PlanificatorDbContext dbContext)
        {
            _dbContext = dbContext;
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
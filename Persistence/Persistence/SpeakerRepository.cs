using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Persistence
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly PlanificatorDbContext _dbContext;

        public SpeakerRepository(PlanificatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetSpeakersCount()
        {
            return _dbContext.SpeakerProfiles.Count();
        }

        public SpeakerProfile GetSpeakerBySpeakerId(string speakerId)
        {
            return _dbContext.SpeakerProfiles.SingleOrDefault(s => s.SpeakerId == speakerId);
        }

        public async Task<SpeakerProfile> GetSpeakerBySpeakerEmailAsync(string email)
        {
            return await _dbContext.SpeakerProfiles
                .SingleOrDefaultAsync(s => s.Email == email);
        }

        public async Task<SpeakerProfile> GetSpeakerBySpeakerEmailIncludingRelationshipsAsync(string email)
        {
            return await _dbContext.SpeakerProfiles
                .Include(s => s.OwnedPresentations)
                .ThenInclude(p => p.PresentationTags)
                .ThenInclude(pt => pt.Tag)
                .SingleOrDefaultAsync(s => s.Email == email);
        }

        public ICollection<SpeakerProfile> GetAllSpeakersProfiles()
        {
            if (_dbContext.SpeakerProfiles.Count() == 0)
                return null;
            return _dbContext.SpeakerProfiles.ToList();
        }
    }
}
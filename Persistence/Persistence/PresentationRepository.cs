using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Persistence
{
    public class PresentationRepository : IPresentationRepository
    {
        private readonly PlanificatorDbContext _dbContext;

        public PresentationRepository(PlanificatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<string> GetAllTagsNames(int presentationId)
        {
            List<string> tags = new List<string>();
            if (_dbContext.Tags.Count() == 0)
                return null;

            tags = _dbContext.Tags.Where(x => _dbContext.PresentationTags.Any(y => y.PresentationId == presentationId && x.TagId == y.TagId)).Select(x => x.TagName).ToList();

            return tags;
        }

        public ICollection<Presentation> GetAllPresentations()
        {
            if (_dbContext.Presentations.Count() == 0)
                return null;

            return _dbContext.Presentations.ToList();
        }

        public int GetPresentationCount()
        {
            return _dbContext.Presentations.Count();
        }

        public Presentation GetPresentationById(int presentationId)
        {
            return _dbContext.Presentations.Include(s => s.PresentationOwner).Include(s => s.PresentationSpeakers).SingleOrDefault(p => p.PresentationId == presentationId);
        }
    }
}
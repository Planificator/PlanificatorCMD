using Application.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Persistence
{
    public class PresentationRepository : IPresentationRepository
    {
        private readonly PlanificatorDbContext _dbContext;

        public PresentationRepository(PlanificatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPresentation(ICollection<PresentationTag> presentationTags)
        {
            foreach (var presantationTag in presentationTags)
            {
                _dbContext.PresentationTags.Add(presantationTag);
            }

            _dbContext.SaveChanges();
        }

        public void AssignSpeakerToPresentation(SpeakerProfile speaker, Presentation presentation)
        {
            PresentationSpeaker presentationSpeaker = new PresentationSpeaker
            {
                SpeakerProfile = speaker,
                Presentation = presentation,
            };
            _dbContext.PresentationSpeakers.Add(presentationSpeaker);
            _dbContext.SaveChanges();
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
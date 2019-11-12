using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanificatorCMD.Persistence
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

        public void AssignSpeakerToPresentation(SpeakerProfile speaker, int presentationIndex)
        {
            var presentation = _dbContext.Presentations.ToList()[presentationIndex];

            PresentationSpeaker presentationSpeaker = new PresentationSpeaker
            {
                SpeakerProfile = speaker,
                Presentation = presentation
            };
            _dbContext.PresentationSpeakers.Add(presentationSpeaker);
            _dbContext.SaveChanges();
        }

        public ICollection<Presentation> GetAllPresentations()
        {
            if (_dbContext.Presentations.Count() == 0)
                return null;


            return _dbContext.Presentations.ToList();
        }


        public ICollection<string> GetAllTagsNames(int presentationId)
        {

            List<string> result = new List<string>();
            if (_dbContext.Tags.Count() == 0)
                return null;

            result = _dbContext.Tags.Where(x => _dbContext.PresentationTags.Any(y => y.PresentationId == presentationId && x.TagId == y.TagId)).Select(x => x.TagName).ToList();

            return result;
        }

        public int GetPresentationCount()
        {
            return _dbContext.Presentations.Count();
        }
    }
}

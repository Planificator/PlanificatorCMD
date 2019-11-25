using Domain.Core;
using Persistence.Persistence;
using System.Collections.Generic;

namespace Application.Managers
{
    public class PresentationManager : IPresentationManager
    {
        //private readonly IPresentationRepository _presentationRepository;
        private readonly PlanificatorDbContext _planificatorDbContext;

        public PresentationManager(PlanificatorDbContext planificatorDbContext)
        {
            //_presentationRepository = presentationRepository;
            _planificatorDbContext = planificatorDbContext;
        }

        public void AddPresentation(ICollection<PresentationTag> presentationTags)
        {
            foreach (var presantationTag in presentationTags)
            {
                _planificatorDbContext.PresentationTags.Add(presantationTag);
            }
            _planificatorDbContext.SaveChanges();
        }

        public void AssignSpeakerToPresentation(SpeakerProfile speaker, Presentation presentation)
        {
            PresentationSpeaker presentationSpeaker = new PresentationSpeaker
            {
                SpeakerProfile = speaker,
                Presentation = presentation,
            };
            _planificatorDbContext.PresentationSpeakers.Add(presentationSpeaker);
            _planificatorDbContext.SaveChanges();
        }
    }
}
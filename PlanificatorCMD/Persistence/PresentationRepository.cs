﻿using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public int GetPresentationCount()
        {
            return _dbContext.Presentations.Count();
        }
    }
}

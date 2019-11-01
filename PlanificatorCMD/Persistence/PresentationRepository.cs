using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
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

        public void AddPresentation(Presentation presentation)
        {
            _dbContext.Presentations.Add(presentation);
            _dbContext.SaveChanges();
        }
    }
}

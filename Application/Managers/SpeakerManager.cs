using Domain.Core;

using Persistence.Persistence;

namespace Application.Managers
{
    public class SpeakerManager : ISpeakerManager
    {
        private readonly PlanificatorDbContext _planificatorDbContext;

        public SpeakerManager(PlanificatorDbContext planificatorDbContext)
        {
            _planificatorDbContext = planificatorDbContext;
        }

        public void AddSpeakerProfile(SpeakerProfile speaker)
        {
            _planificatorDbContext.SpeakerProfiles.Add(speaker);
            _planificatorDbContext.SaveChanges();
        }
    }
}
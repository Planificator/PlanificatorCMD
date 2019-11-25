using Domain.Core;

using Persistence.Persistence;

namespace Application.Managers
{
    public class SpeakerManager : ISpeakerManager
    {
        private readonly PlanificatorDbContext _planificatorDbContext;
        //private readonly ISpeakerRepository _speakerRepository;

        public SpeakerManager(PlanificatorDbContext planificatorDbContext)
        {
            //_speakerRepository = speakerRepository;
            _planificatorDbContext = planificatorDbContext;
        }

        public void AddSpeakerProfile(SpeakerProfile speaker)
        {
            _planificatorDbContext.SpeakerProfiles.Add(speaker);
            _planificatorDbContext.SaveChanges();
        }
    }
}
using PlanificatorCMD.Core;
using PlanificatorCMD.Persistence;
using System.Collections.Generic;

namespace PlanificatorCMD.Managers
{
    public class PresentationManager : IPresentationManager
    {
        private readonly IPresentationRepository _presentationRepository;

        public PresentationManager(IPresentationRepository presentationRepository)
        {
            _presentationRepository = presentationRepository;
        }

        public void AddPresentation(ICollection<PresentationTag> presentationTags)
        {
            _presentationRepository.AddPresentation(presentationTags);
        }

        public void AssignSpeakerToPresentation(SpeakerProfile speaker, int presentationId)
        {
            _presentationRepository.AssignSpeakerToPresentation(speaker, presentationId);
        }

        public int GetPresentationsCount()
        {
            return _presentationRepository.GetPresentationCount();
        }
    }
}
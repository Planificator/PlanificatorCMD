using PlanificatorCMD.Core;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Managers
{
    public class PresentationManager : IPresentationManager
    {
        private readonly IPresentationRepository _presentationRepository;
        private readonly IDisplayPresentation _displayPresentation;

        public PresentationManager(IPresentationRepository presentationRepository, IDisplayPresentation displayPresentation)
        {
            _presentationRepository = presentationRepository;
            _displayPresentation = displayPresentation;
        }

        public void AddPresentation(ICollection<PresentationTag> presentationTags)
        {
            _presentationRepository.AddPresentation(presentationTags);
        }

        public int ShowAllPresentation(bool displayOption)
        {
            ICollection<Presentation> presentations = _presentationRepository.GetAllPresentations();

            if (presentations == null)
                return 1;

            foreach(Presentation presentation in presentations)
            {
                ShowPresentation(presentation, displayOption);
            }

            return 0;
        }

        private void ShowPresentation(Presentation presentation, bool displayOption)
        {
            var tags = _presentationRepository.GetAllTags(presentation.PresentationId);
            
            _displayPresentation.DisplayAllPresentation(tags, presentation, displayOption);

        }
    }
}

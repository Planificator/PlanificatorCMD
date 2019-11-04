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
        private readonly IDisplayPresentations _displayPresentations;

        public PresentationManager(IPresentationRepository presentationRepository, IDisplayPresentations displayPresentations)
        {
            _presentationRepository = presentationRepository;
            _displayPresentations = displayPresentations;
        }

        public void AddPresentation(ICollection<PresentationTag> presentationTags)
        {
            _presentationRepository.AddPresentation(presentationTags);
        }

        public int ShowAllPresentation(bool displayOption)
        {
            
            ICollection<PresentationTag> presentations = _presentationRepository.GetAllPresentations();

            if (_displayPresentations.DisplayAllPresentations(presentations, displayOption) == false)
                return 1;
            _displayPresentations.DisplayAllPresentations(presentations, displayOption);

            return 0;
        }
    }
}

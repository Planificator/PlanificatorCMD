using Application.Core;
using PlanificatorCMD.Verbs;
using System.Collections.Generic;

namespace PlanificatorCMD.Utils
{
    public interface IPresentationMapper
    {
        public ICollection<PresentationTag> MapToPresentationTag(IAddPresentationVerb addPresentationVerb, SpeakerProfile presentationOwner);
    }
}
using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;
using System.Collections.Generic;

namespace PlanificatorCMD.Utils
{
    public interface IPresentationMapper
    {
        public ICollection<PresentationTag> MapToPresentationTag(AddPresentationVerb addPresentationVerb);
    }
}

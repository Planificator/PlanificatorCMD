using System.Collections.Generic;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Utils
{
    public interface IDisplayPresentations
    {
        bool DisplayAllPresentations(ICollection<PresentationTag> presentationTags, bool displayOption);
    }
}
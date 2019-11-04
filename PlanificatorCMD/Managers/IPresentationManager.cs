using PlanificatorCMD.Core;
using System.Collections.Generic;

namespace PlanificatorCMD.Managers
{
    public interface IPresentationManager
    {
        void AddPresentation(ICollection<PresentationTag> presentation);
        int ShowAllPresentation(bool displayOption);
    }
}
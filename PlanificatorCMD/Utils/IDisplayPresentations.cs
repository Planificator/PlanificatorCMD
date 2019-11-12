using System.Collections.Generic;
using PlanificatorCMD.Core;
using PlanificatorCMD.Wrappers;

namespace PlanificatorCMD.Utils
{
    public interface IDisplayPresentation
    {
        void DisplayAllPresentation(ICollection<string> tags,Presentation presentations, bool displayOption);
    }
}
using System.Collections.Generic;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Utils
{
    public interface IDisplayPresentation
    {
        void DisplayAllPresentation(ICollection<string> tags,Presentation presentations, bool displayOption);
    }
}
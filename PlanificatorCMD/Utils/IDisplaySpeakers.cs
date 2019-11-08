using System.Collections.Generic;
using PlanificatorCMD.Core;
using PlanificatorCMD.Wrappers;

namespace PlanificatorCMD.Utils
{
    public interface IDisplaySpeakers
    {
        bool DisplayAllSpeakers(ICollection<SpeakerProfile> speakers, bool displayOption, IConsoleWrapper CW);
    }
}
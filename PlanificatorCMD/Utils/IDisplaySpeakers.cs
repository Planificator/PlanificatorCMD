using System.Collections.Generic;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Utils
{
    public interface IDisplaySpeakers
    {
        bool DisplayAllSpeakers(IEnumerable<SpeakerProfile> speakers, bool displayOption);
    }
}
using System.Collections.Generic;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Utils
{
    public interface IDisplaySpeakers
    {
        bool DisplayAllSpeakers(ICollection<SpeakerProfile> speakers, bool displayOption);
    }
}
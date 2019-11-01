using System.Collections.Generic;
using PlanificatorCMD.Core;

namespace PlanificatorCMD.Utils
{
    public interface IDisplaySpeakers
    {
        bool DisplayAllSpeakers(List<SpeakerProfile> speakers, bool displayOption);
    }
}
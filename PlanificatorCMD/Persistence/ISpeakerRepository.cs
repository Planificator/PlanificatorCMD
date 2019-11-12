using System;
using System.Collections.Generic;
using System.Text;
using PlanificatorCMD.Core;

namespace PlanificatorCMD
{
    public interface ISpeakerRepository
    {
        void AddSpeakerProfile(SpeakerProfile speaker);
        int GetMaxId();
        int GetSpeakersCount();
        SpeakerProfile GetSpeakerBySpeakerIndex(int index);
    }
}

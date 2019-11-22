using Application.Core;
using PlanificatorCMD.Verbs;

namespace PlanificatorCMD.Utils
{
    public interface ISpeakerProfileMapper
    {
        SpeakerProfile MapToSpeaker(IAddSpeakerVerb addSpeakerVerb);
    }
}
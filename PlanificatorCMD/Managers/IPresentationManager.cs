using PlanificatorCMD.Core;
using System.Collections.Generic;

namespace PlanificatorCMD.Managers
{
    public interface IPresentationManager
    {
        void AddPresentation(ICollection<PresentationTag> presentation);
        void AssignSpeakerToPresentation(SpeakerProfile speaker, int presentationId);
        int GetPresentationsCount();
        int GetPresentationById(int presentationId);
    }
}
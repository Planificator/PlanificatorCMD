using PlanificatorCMD.Core;
using System.Collections.Generic;

namespace PlanificatorCMD.Managers
{
    public interface IPresentationManager
    {
        void AddPresentation(ICollection<PresentationTag> presentation);
        int ShowAllPresentation(bool displayOption);
        void ShowPresentation(Presentation presentation, bool displayOption);
        void AssignSpeakerToPresentation(SpeakerProfile speaker, int presentationIndex);
        int GetPresentationsCount();
        

    }
}
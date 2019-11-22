using Domain.Core;
using System.Collections.Generic;

namespace Application.Managers
{
    public interface IPresentationManager
    {
        void AddPresentation(ICollection<PresentationTag> presentation);

        void AssignSpeakerToPresentation(SpeakerProfile speaker, Presentation presentation);

        int GetPresentationsCount();

        Presentation GetPresentationById(int presentationId);
    }
}
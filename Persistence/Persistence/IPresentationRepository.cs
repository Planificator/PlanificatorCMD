using Domain.Core;
using System.Collections.Generic;

namespace Persistence.Persistence
{
    public interface IPresentationRepository
    {
        void AddPresentation(ICollection<PresentationTag> presentation);

        ICollection<Presentation> GetAllPresentations();

        public void AssignSpeakerToPresentation(SpeakerProfile speaker, Presentation presentationIndex);

        public int GetPresentationCount();

        ICollection<string> GetAllTagsNames(int presentationId);

        public Presentation GetPresentationById(int presentationId);
    }
}
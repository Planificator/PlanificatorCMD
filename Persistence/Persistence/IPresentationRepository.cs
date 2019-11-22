using Domain.Core;
using System.Collections.Generic;

namespace Persistence.Persistence
{
    public interface IPresentationRepository
    {
        ICollection<Presentation> GetAllPresentations();

        public int GetPresentationCount();

        ICollection<string> GetAllTagsNames(int presentationId);

        public Presentation GetPresentationById(int presentationId);
    }
}
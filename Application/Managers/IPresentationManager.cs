using Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Managers
{
    public interface IPresentationManager
    {
        Task AddPresentation(ICollection<PresentationTag> presentation);

        void AssignSpeakerToPresentation(SpeakerProfile speaker, Presentation presentation);
    }
}
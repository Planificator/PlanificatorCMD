using PlanificatorCMD.Core;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Wrappers;
using System.Collections.Generic;

namespace PlanificatorCMD.Utils
{
    public class DisplayPresentations : IDisplayPresentations
    {
        private readonly IConsoleWrapper _consoleWrapper;
        private readonly IPresentationRepository _presentationRepository;

        public DisplayPresentations(IPresentationRepository presentationRepository, IConsoleWrapper consoleWrapper)
        {
            _presentationRepository = presentationRepository;
            _consoleWrapper = consoleWrapper;
        }
        public int DisplayAllPresentations(bool displayOption)
        {
            ICollection<Presentation> presentations = _presentationRepository.GetAllPresentations();

            if (presentations == null)
            {
                _consoleWrapper.WriteLine("no presentations found");
                return ExecutionResult.Fail;
            }

            _consoleWrapper.WriteLine();
            if (displayOption == false)
                foreach (Presentation presentation in presentations)
                {
                    _consoleWrapper.WriteLine(presentation.PresentationId + ")\t" + presentation.Title + " " + presentation.ShortDescription);
                }
            if (displayOption == true)
            {
                foreach (Presentation presentation in presentations)
                {
                    var tags = _presentationRepository.GetAllTagsNames(presentation.PresentationId);
                    _consoleWrapper.Write(presentation.PresentationId + ")\t" + presentation.Title + " " + presentation.ShortDescription + " " + presentation.LongDescription + " ");
                    foreach (var tag in tags)
                    {
                        _consoleWrapper.Write(tag + " ");
                    }
                    _consoleWrapper.WriteLine();
                }
            }
            _consoleWrapper.WriteLine();
            return ExecutionResult.Succes;
        }
    }
}

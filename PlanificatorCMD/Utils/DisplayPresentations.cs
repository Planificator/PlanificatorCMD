using PlanificatorCMD.Core;
using PlanificatorCMD.Wrappers;
using System.Collections.Generic;

namespace PlanificatorCMD.Utils
{
    public class DisplayPresentation : IDisplayPresentation
    {
        private readonly IConsoleWrapper _consoleWrapper;
        private readonly IPresentationRepository _presentationRepository;

        public DisplayPresentations(IPresentationRepository presentationRepository, IConsoleWrapper consoleWrapper)
        {
            _presentationRepository = presentationRepository;
            _consoleWrapper = consoleWrapper;
        }
        public void DisplayAllPresentation(ICollection<string> tags, Presentation presentation, bool displayOption)
        {
            ICollection<Presentation> presentations = _presentationRepository.GetAllPresentations();

            if (presentations == null)
            {
                _consoleWrapper.WriteLine("no presentations found");
                return ExecutionResult.Fail;
            }

            _consoleWrapper.WriteLine();
            int i = 1;
            if (displayOption == false)
                foreach (Presentation presentation in presentations)
                {
                    _consoleWrapper.WriteLine(i++ + ")\t" + presentation.Title + " " + presentation.ShortDescription);
                }
            if (displayOption == true)
            {
                _cw.Write(presentation.Title + " " + presentation.ShortDescription + " " + presentation.LongDescription + " ");
                foreach (var tag in tags)
                {
                    var tags = _presentationRepository.GetAllTagsNames(presentation.PresentationId);
                    _consoleWrapper.Write(i++ + ")\t" + presentation.Title + " " + presentation.ShortDescription + " " + presentation.LongDescription + " ");
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

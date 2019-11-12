using PlanificatorCMD.Core;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanificatorCMD.Utils
{
    public class DisplayPresentations : IDisplayPresentations
    {
        private readonly IConsoleWrapper _cw;
        private readonly PlanificatorDbContext _dbContext;

        public DisplayPresentations(PlanificatorDbContext dbContext, IConsoleWrapper cw)
        {
            _cw = cw;
            _dbContext = dbContext;
        }

        public int ShowAllPresentations(bool displayOption)
        {
            ICollection<Presentation> presentations = GetAllPresentations();

            if (presentations == null)
            {
                _cw.WriteLine("no presentations found");
                return ExecutionResult.Fail;
            }

            _cw.WriteLine();
            int i = 1;
            if (displayOption == false)
                foreach (Presentation presentation in presentations)
                {
                    _cw.WriteLine(i++ + ")\t" + presentation.Title + " " + presentation.ShortDescription);
                }
            if (displayOption == true)
            {
                foreach (Presentation presentation in presentations)
                {
                    var tags = GetAllTagsNames(presentation.PresentationId);
                    _cw.Write(i++ + ")\t" + presentation.Title + " " + presentation.ShortDescription + " " + presentation.LongDescription + " ");
                    foreach (var tag in tags)
                    {
                        _cw.Write(tag + " ");
                    }
                    _cw.WriteLine();
                } 
            }
            _cw.WriteLine();
            return ExecutionResult.Succes;
        }

        private ICollection<string> GetAllTagsNames(int presentationId)
        {
            List<string> tags = new List<string>();
            if (_dbContext.Tags.Count() == 0)
                return null;

            tags = _dbContext.Tags.Where(x => _dbContext.PresentationTags.Any(y => y.PresentationId == presentationId && x.TagId == y.TagId)).Select(x => x.TagName).ToList();

            return tags;
        }
        private ICollection<Presentation> GetAllPresentations()
        {
            if (_dbContext.Presentations.Count() == 0)
                return null;

            return _dbContext.Presentations.ToList();
        }
    }
}

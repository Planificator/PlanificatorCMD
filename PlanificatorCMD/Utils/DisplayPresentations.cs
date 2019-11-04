using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Utils
{
    public class DisplayPresentations : IDisplayPresentations
    {
        public bool DisplayAllPresentations(ICollection<PresentationTag> presentationTags, bool displayOption)
        {
            if (presentationTags == null)
            {
                Console.WriteLine("No presentations finded");
                return false;
            }

            if (displayOption == false)
            {
                foreach (var presentationTag in presentationTags)
                {
                    Console.WriteLine(presentationTag.Presentation.Title + " " + presentationTag.Presentation.ShortDescription);
                }
            }

            else
            {
                foreach (var presentationTag in presentationTags)
                {
                    Console.WriteLine(presentationTag.Presentation.Title + " " + presentationTag.Presentation.ShortDescription + " " + presentationTag.Presentation.LongDescription);
                    foreach (var tag in presentationTag.Presentation.PresentationTags)
                        Console.Write(tag.Tag.TagName + " ");
                }
            }

            return true;
        }
    }
}


﻿using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Utils
{
    class PresentationMapper
    {
        public ICollection<PresentationTag> MapToPresentationTag (Add_PresentationVerb addPresentationVerb)
        {
            ICollection<string> tags = addPresentationVerb.Tags.Split(" ");

            Presentation presentation = new Presentation()
            {
                Title = addPresentationVerb.Title,
                ShortDescription = addPresentationVerb.ShortDescription,
                LongDescription = addPresentationVerb.LongDescription
            };

            List<PresentationTag> presentationTags = new List<PresentationTag>();

            foreach (var tagName in tags) 
            {
                PresentationTag presentationTag = new PresentationTag()
                {
                    Presentation = presentation,
                    Tag = new Tag() { TagName = tagName }
                };
                presentationTags.Add(presentationTag);
            }
            return presentationTags;
        }
    }
}

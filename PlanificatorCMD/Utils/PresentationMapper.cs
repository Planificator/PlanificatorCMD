
﻿using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Utils
{
    public class PresentationMapper : IPresentationMapper
    {
        public ICollection<PresentationTag> MapToPresentationTag (IAddPresentationVerb addPresentationVerb)
        {
            ICollection<string> tags = addPresentationVerb.Tags.Split(" ");

            Presentation presentation = new Presentation()
            {
                Title = addPresentationVerb.Title,
                ShortDescription = addPresentationVerb.ShortDescription,
                LongDescription = addPresentationVerb.LongDescription
            };

            ICollection<PresentationTag> presentationTags = new List<PresentationTag>();

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
using PlanificatorCMD.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Tests.PresentationRepositoryTests
{
    public class PresentationRepositoryTestsData
    {
        public PresentationRepositoryTestsData()
        {
            foreach (Tag tag in tags)
            {
                presentationTags.Add(new PresentationTag { Tag = tag, Presentation = presentation });
            }
        }

        public List<Tag> tags = new List<Tag>()
        {
                new Tag { TagName = "AA" },
                new Tag { TagName = "BB" },
                new Tag { TagName = "CC" }
        };

        public Presentation presentation = new Presentation
        {
            Title = "Test",
            LongDescription = "Test",
            ShortDescription = "Test"
        };

        public List<PresentationTag> presentationTags = new List<PresentationTag>();

       
    }
}

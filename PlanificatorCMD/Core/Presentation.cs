using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlanificatorCMD.Core
{
    public class Presentation
    {
        public int PresentationId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public ICollection<PresentationTag> PresentationTags { get; set; }
        public ICollection<PresentationSpeaker> PresentationSpeakers { get; set; }
    }
}

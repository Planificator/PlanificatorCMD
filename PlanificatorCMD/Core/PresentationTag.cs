using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlanificatorCMD.Core
{
    public class PresentationTag
    {
        public int PresentationId { get; set; }
        public Presentation Presentation { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}

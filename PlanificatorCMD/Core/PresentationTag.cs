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
        public virtual Presentation Presentation { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}

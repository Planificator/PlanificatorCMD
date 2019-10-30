using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlanificatorCMD.Core
{
    class Photo
    {
        [ForeignKey("SpeakerProfile")]
        public int PhotoId { get; set; }
        public string Path { get; set; }

        public virtual SpeakerProfile SpeakerProfile { get; set; }
    }
}
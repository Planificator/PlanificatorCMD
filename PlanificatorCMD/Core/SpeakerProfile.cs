using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanificatorCMD.Core
{
    class SpeakerProfile
    {
        [Key]
        public int SpeakerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public virtual Photo Photo { get; set; }
    }
}

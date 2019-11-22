using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Core
{
    public class SpeakerProfile
    {
        [Key]
        public int SpeakerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public virtual Photo Photo { get; set; }
        public string Company { get; set; }
        public virtual ICollection<PresentationSpeaker> PresentationSpeakers { get; set; }
        public virtual ICollection<Presentation> OwnedPresentations { get; set; }
    }
}
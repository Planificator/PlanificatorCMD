using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Core
{
    public class Photo
    {
        [ForeignKey("SpeakerProfile")]
        public int PhotoId { get; set; }

        public string Path { get; set; }

        public virtual SpeakerProfile SpeakerProfile { get; set; }
    }
}
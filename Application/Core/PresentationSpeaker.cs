namespace Application.Core
{
    public class PresentationSpeaker
    {
        public int PresentationId { get; set; }
        public virtual Presentation Presentation { get; set; }
        public int SpeakerId { get; set; }
        public virtual SpeakerProfile SpeakerProfile { get; set; }
    }
}
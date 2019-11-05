using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Core
{
    public class PresentationSpeaker
    {
        public int PresentationId { get; set; }
        public Presentation Presentation { get; set; }
        public int SpeakerId { get; set; }
        public SpeakerProfile SpeakerProfile { get; set; }
    }
}

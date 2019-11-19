namespace PlanificatorCMD.Verbs
{
    public interface IAssignSpeakerToPresentationVerb
    {
        int PresentationId { get; set; }
        int SpeakerId { get; set; }
    }
}
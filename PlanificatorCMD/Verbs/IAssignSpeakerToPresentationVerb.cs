namespace PlanificatorCMD.Verbs
{
    public interface IAssignSpeakerToPresentationVerb
    {
        int PresentationIndex { get; set; }
        int SpeakerIndex { get; set; }
    }
}
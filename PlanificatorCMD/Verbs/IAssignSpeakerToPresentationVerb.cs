namespace PlanificatorCMD.Verbs
{
    interface IAssignSpeakerToPresentationVerb
    {
        int presentationIndex { get; set; }
        int speakerIndex { get; set; }
    }
}
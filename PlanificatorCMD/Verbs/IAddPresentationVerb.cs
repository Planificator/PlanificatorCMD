namespace PlanificatorCMD.Verbs
{
    public interface IAddPresentationVerb
    {
        string Title { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string Tags { get; set; }
        int PresentationOwnerSpeakerId { get; set; }
    }
}
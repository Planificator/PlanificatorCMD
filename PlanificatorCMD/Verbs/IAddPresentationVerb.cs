namespace PlanificatorCMD.Verbs
{
    public interface IAdd_PresentationVerb
    {
        string Title { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string Tags { get; set; }
    }
}
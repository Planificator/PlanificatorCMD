namespace PlanificatorCMD.Verbs
{
    public interface IAddSpeakerVerb
    {
        string Bio { get; set; }
        string Company { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhotoPath { get; set; }

    }
}
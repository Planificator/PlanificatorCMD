namespace PlanificatorCMD.Validators
{
    public interface IAssignSpeakerToPresentationVerbValidator
    {
        bool IsValid(int index, int totalCount);
    }
}
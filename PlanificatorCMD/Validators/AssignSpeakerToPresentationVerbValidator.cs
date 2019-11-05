using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Validators
{
    public class AssignSpeakerToPresentationVerbValidator : IAssignSpeakerToPresentationVerbValidator
    {
        public bool IsValid(int index, int totalCount)
        {
            if (index >= 0 && totalCount >= 0 && index <= totalCount)
                return true;
            return false;
        }
    }
}

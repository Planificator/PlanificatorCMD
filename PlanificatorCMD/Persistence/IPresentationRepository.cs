﻿using PlanificatorCMD.Core;
using System.Collections.Generic;

namespace PlanificatorCMD.Persistence
{
    public interface IPresentationRepository
    {
        void AddPresentation(ICollection<PresentationTag> presentation);
        public void AssignSpeakerToPresentation(SpeakerProfile speaker, int presentationIndex);
        public int GetPresentationCount();
        ICollection<Presentation> GetAllPresentations();
        ICollection<string> GetAllTagsNames(int presentationId);
    }
}
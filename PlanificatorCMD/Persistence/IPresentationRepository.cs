﻿using PlanificatorCMD.Core;
using System.Collections.Generic;

namespace PlanificatorCMD.Persistence
{
    public interface IPresentationRepository
    {
        void AddPresentation(ICollection<PresentationTag> presentation);
    }
}
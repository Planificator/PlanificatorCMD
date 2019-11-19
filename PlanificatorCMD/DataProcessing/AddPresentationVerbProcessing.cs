using PlanificatorCMD.Managers;
using PlanificatorCMD.Utils;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.DataProcessing
{
    public class AddPresentationVerbProcessing : IAddPresentationVerbProcessing
    {
        private readonly IAddPresentationVerbValidator _presentationValidator;
        private readonly IPresentationMapper _presentationMapper;
        private readonly IPresentationManager _presentationManager;

        public AddPresentationVerbProcessing(IAddPresentationVerbValidator presentationValidator, IPresentationMapper presentationMapper, IPresentationManager presentationManager)
        {
            _presentationValidator = presentationValidator;
            _presentationMapper = presentationMapper;
            _presentationManager = presentationManager;
        }

        public int AddPresentation(IAddPresentationVerb addPresentationVerb) 
        { 
            if (!_presentationValidator.IsValid(addPresentationVerb))
            {
                return ExecutionResult.Fail;
            }
            var presentationTags = _presentationMapper.MapToPresentationTag(addPresentationVerb);
            _presentationManager.AddPresentation(presentationTags);

            return ExecutionResult.Succes;
        }

    }
}

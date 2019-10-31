using PlanificatorCMD.Core;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Utils
{
    public class SpeakerProfileMapper : ISpeakerProfileMapper
    {

        private readonly IPhotoPathProcessing _photoPathProcessing;

        public SpeakerProfileMapper(IPhotoPathProcessing photoPathProcessing)
        {
            _photoPathProcessing = photoPathProcessing;
        }

        public SpeakerProfile MapToSpeaker(IAddSpeakerVerb addSpeakerVerb)
        {
            SpeakerProfile speakerProfile = new SpeakerProfile()
            {
                FirstName = addSpeakerVerb.FirstName,
                LastName = addSpeakerVerb.LastName,
                Email = addSpeakerVerb.Email,
                Bio = addSpeakerVerb.Bio,
                Company = addSpeakerVerb.Company,
                Photo = new Photo()
                {
                    Path = _photoPathProcessing.PhotoCopy(addSpeakerVerb.PhotoPath),
                }
            };

            return speakerProfile;
        }
    }
}

using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlanificatorCMD
{
    class SpeakerManager : ISpeakerManager
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerManager(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public void AddSpeakerProfile(IAddSpeakerVerb addSpeakerVerb)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, Constants.Constants.speakerPhotosPath);
            File.Copy(addSpeakerVerb.PhotoPath, path);

            int newPhotoId = _speakerRepository.GetMaxId() + 1;
            string newPhotoPath = Path.Combine(path, String.Concat(newPhotoId.ToString(),".jpg"));

            SpeakerProfile speakerProfile = new SpeakerProfile()
            {
                SpeakerId = newPhotoId,
                FirstName = addSpeakerVerb.FirstName,
                LastName = addSpeakerVerb.LastName,
                Email = addSpeakerVerb.Email,
                Bio = addSpeakerVerb.Bio,
                Company = addSpeakerVerb.Company, 
                Photo = new Photo() 
                { 
                    Path = newPhotoPath,
                    PhotoId = newPhotoId,
                }
            };

            _speakerRepository.AddSpeakerProfile(speakerProfile);
        }
    }
}

using PlanificatorCMD.Core;
using PlanificatorCMD.Verbs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlanificatorCMD
{
    public class SpeakerManager : ISpeakerManager
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerManager(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public void AddSpeakerProfile(IAddSpeakerVerb addSpeakerVerb)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, Constants.Constants.speakerPhotosPath);
            int newPhotoId = _speakerRepository.GetMaxId() + 1;
            string newPhotoPath = Path.Combine(path, newPhotoId.ToString() + ".jpg");
            File.Copy(addSpeakerVerb.PhotoPath, newPhotoPath);

            SpeakerProfile speakerProfile = new SpeakerProfile()
            {
                FirstName = addSpeakerVerb.FirstName,
                LastName = addSpeakerVerb.LastName,
                Email = addSpeakerVerb.Email,
                Bio = addSpeakerVerb.Bio,
                Company = addSpeakerVerb.Company, 
                Photo = new Photo() 
                { 
                    Path = newPhotoPath,
                }
            };

            _speakerRepository.AddSpeakerProfile(speakerProfile);
        }
    }
}

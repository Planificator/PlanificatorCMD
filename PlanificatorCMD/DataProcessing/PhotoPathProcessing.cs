using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlanificatorCMD.DataProcessing
{
    public class PhotoPathProcessing : IPhotoPathProcessing
    {

        private readonly ISpeakerRepository _speakerRepository;

        public PhotoPathProcessing(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }
        public string PhotoCopy(string photoPath)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, Constants.Constants.speakerPhotosPath);
            int newPhotoId = _speakerRepository.GetMaxId() + 1;
            string newPhotoPath = Path.Combine(path, newPhotoId.ToString() + ".jpg");
            File.Copy(photoPath, newPhotoPath);

            return newPhotoPath;
        }
    }
}

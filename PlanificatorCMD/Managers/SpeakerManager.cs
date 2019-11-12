using PlanificatorCMD.Core;

namespace PlanificatorCMD.Managers
{
    public class SpeakerManager : ISpeakerManager
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerManager(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public void AddSpeakerProfile(SpeakerProfile speaker)
        {
            _speakerRepository.AddSpeakerProfile(speaker);
        }

        public SpeakerProfile GetSpeakerBySpeakerIndex(int speakerIndex)
        {
            return _speakerRepository.GetSpeakerBySpeakerIndex(speakerIndex);
        }

        public int GetSpeakersCount()
        {
            return _speakerRepository.GetSpeakersCount();
        }
    }
}

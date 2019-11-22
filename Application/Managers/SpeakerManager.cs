using Application.Core;
using Application.Persistence;

namespace Application.Managers
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

        public SpeakerProfile GetSpeakerBySpeakerId(int speakerId)
        {
            return _speakerRepository.GetSpeakerBySpeakerId(speakerId);
        }

        public int GetSpeakersCount()
        {
            return _speakerRepository.GetSpeakersCount();
        }
    }
}
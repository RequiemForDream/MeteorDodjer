using Core.Interfaces;
using UnityEngine;

namespace Sounds
{
    public class SoundFactory
    {
        private readonly AudioClip _turnSound;
        private readonly AudioSource _soundSource;

        public SoundFactory(IInputService inputService, SoundsConfig soundsConfig, AudioSource soundSource)
        {
            inputService.OnScreenTap += PlayTrunSound;
            _turnSound = soundsConfig.TurnSound;
            _soundSource = soundSource;
        }

        private void PlayTrunSound()
        {
            _soundSource.PlayOneShot(_turnSound);
        }
    }
}

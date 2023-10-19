using Sounds.Interfaces;
using UnityEngine;

namespace Sounds
{
    public class SoundFactory : ISoundFactory
    {
        private readonly AudioSource _soundSource;

        public SoundFactory(SoundsConfig soundsConfig, AudioSource soundSource)
        {
            _soundSource = soundSource;
        }

        public void PlaySound(AudioClip clip)
        {
           _soundSource.PlayOneShot(clip);
        }
    }
}

using Core.Interfaces;
using UnityEngine;

namespace Sounds
{
    public class BackgroundMusic : IClearable, IInitializable
    {
        private readonly AudioSource _backgroundPlayer;

        public BackgroundMusic(AudioSource backgroundPlayer, IListenersHandler<IInitializable> initializer,
            IListenersHandler<IClearable> clearer)
        {
            _backgroundPlayer = backgroundPlayer;
            initializer.AddListener(this);
            clearer.AddListener(this);
        }

        public void Initialize()
        {
            _backgroundPlayer.Play();
        }

        public void Clear()
        {
            _backgroundPlayer.Stop();
        }
    }
}

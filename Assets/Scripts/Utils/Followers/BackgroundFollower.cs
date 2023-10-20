using Core;
using Core.Interfaces;
using UnityEngine;

namespace Utils
{
    public class BackgroundFollower : Follower, IInitializable, IClearable
    {
        private SpriteRenderer _spriteRenderer;
        private BackgroundConfig _backgroundConfig;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Config(BackgroundConfig backgroundConfig, IListenersHandler<IInitializable> initializer,
            IListenersHandler<IClearable> clearer)
        {
            _backgroundConfig = backgroundConfig;
            initializer.AddListener(this);
            clearer.AddListener(this);
        }

        public void Initialize()
        {
            _spriteRenderer.sprite = _backgroundConfig.GetRandomSprite();
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }

        public void Clear()
        {
            _spriteRenderer.sprite = null;
        }
    }
}

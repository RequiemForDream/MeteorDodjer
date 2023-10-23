using Core.Interfaces;
using UnityEngine;

namespace Utils.Visual
{
    public class Background : Follower, IInitializable, IClearable
    {
        private SpriteRenderer _spriteRenderer;
        private BackgroundModel _backgroundModel;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Construct(BackgroundModel backgroundModel, IListenersHandler<IInitializable> initializer,
            IListenersHandler<IClearable> clearer)
        {
            _backgroundModel = backgroundModel;
            initializer.AddListener(this);
            clearer.AddListener(this);
        }

        public void Initialize()
        {
            _spriteRenderer.sprite = GetRandomSprite();
        }

        private Sprite GetRandomSprite()
        {
            var sprite = _backgroundModel.Backgrounds[Random.Range(0, _backgroundModel.Backgrounds.Length)];
            return sprite;
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

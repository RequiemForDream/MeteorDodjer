using Core.Interfaces;
using UnityEngine;

namespace Utils.Visual
{
    public class BackgroundParticle : Follower, IInitializable, IClearable
    {
        public void Construct(IListenersHandler<IInitializable> initializator, IListenersHandler<IClearable> clearer)
        {
            initializator.AddListener(this);
            clearer.AddListener(this);
            gameObject.SetActive(false);
        }

        public void Initialize()
        {
            gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }

        public void Clear()
        {
            gameObject.SetActive(false);
        }
    }
}

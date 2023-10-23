using UI.Interfaces;
using UnityEngine;

namespace UI
{
    public abstract class GameScreen : MonoBehaviour
    {
        private void Awake()
        {
            OnAwake();
        }

        protected abstract void OnAwake();

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public void SetCanvas(Canvas canvas)
        {
            transform.SetParent(canvas.transform, false);
        }
    }
}

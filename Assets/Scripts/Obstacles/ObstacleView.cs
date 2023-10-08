using Core.Interfaces;
using System;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleView : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroyHandler;
        public event Action OnEnabledHandler;
        public event Action OnDisabledHandler;

        public Rigidbody2D Rigidbody2D { get; private set; } 

        public void Initialize()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            OnEnabledHandler?.Invoke();
        }
        
        private void OnDisable()
        {
            OnDestroyHandler?.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}

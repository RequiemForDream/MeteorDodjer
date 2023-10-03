using Core.Interfaces;
using System;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleView : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroyHandler;
        public bool IsInvisible = false;

        public Rigidbody2D Rigidbody2D { get; private set; } 

        public void Initialize()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnBecameInvisible()
        {
            IsInvisible = true;
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}

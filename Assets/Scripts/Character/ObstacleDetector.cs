using Character.Interfaces;
using Obstacles;
using System;
using UnityEngine;

namespace Character
{
    public class ObstacleDetector : MonoBehaviour, IDetector
    {
        public event Action OnCollided;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ObstacleView obstacle))
            {
                OnCollided?.Invoke();
            }
        }
    }
}

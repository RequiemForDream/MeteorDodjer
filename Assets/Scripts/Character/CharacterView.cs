using Character.Interfaces;
using Core.Interfaces;
using System;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ObstacleDetector))]
    public class CharacterView : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroyHandler;
        public Rigidbody2D Rigidbody2D { get; private set; }
        public TrailRenderer TrailRenderer { get; private set; } 
        public IDetector ObstacleDetector { get; private set; }

        public void Initialize()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            ObstacleDetector = GetComponent<IDetector>();
            TrailRenderer = GetComponentInChildren<TrailRenderer>();
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}

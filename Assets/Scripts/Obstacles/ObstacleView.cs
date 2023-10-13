using Core.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace Obstacles
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class ObstacleView : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroyHandler;
        private float _lifeTime;

        public Rigidbody2D Rigidbody2D { get; private set; } 

        public void Initialize()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetLifeTime(float lifeTime)
        {
            _lifeTime = lifeTime;
        }

        public void Deactivate()
        {   
            gameObject.SetActive(false);  
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(_lifeTime);
            Deactivate();
        }

        private void OnEnable()
        {
            StartCoroutine(LifeRoutine());
        }
        
        private void OnDisable()
        {
            StopCoroutine(LifeRoutine());  
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}

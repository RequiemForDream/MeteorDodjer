using Core.Interfaces;
using Obstacles.Intefaces;
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
        public IPerfectCollideDetector PerfectCollideDetector { get; private set; }

        public void Initialize(ObstacleModel obstacleModel)
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            PerfectCollideDetector = GetComponentInChildren<IPerfectCollideDetector>();
            PerfectCollideDetector.SetObstacleModel(obstacleModel);
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

        public void Destroy()
        {
            Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}

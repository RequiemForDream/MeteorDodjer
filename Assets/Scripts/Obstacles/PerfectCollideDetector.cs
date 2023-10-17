using Character;
using Character.Interfaces;
using System;
using UnityEngine;

namespace Obstacles
{
    public class PerfectCollideDetector : MonoBehaviour, IDetector
    {
        public float PerfectCollideTime;
        public float currentTime;
        public event Action OnCollided;
        private LineRenderer _colliderRenderer;

        private void Awake()
        {
            currentTime = PerfectCollideTime;
            _colliderRenderer = GetComponent<LineRenderer>();

            Initialize();
        }

        private void Initialize()
        {
            _colliderRenderer.positionCount = 5;

            Vector3[] cubeVertices = new Vector3[5];
            float halfSize = 0.6f;

            cubeVertices[0] = new Vector3(-halfSize * 1.5f, -halfSize, 0f);
            cubeVertices[1] = new Vector3(halfSize, -halfSize, 0f);
            cubeVertices[2] = new Vector3(halfSize, halfSize, 0f);
            cubeVertices[3] = new Vector3(-halfSize, halfSize, 0f);
            cubeVertices[4] = new Vector3(-halfSize, -halfSize, 0f);

            _colliderRenderer.SetPositions(cubeVertices);
            _colliderRenderer.startWidth = halfSize;
            _colliderRenderer.endWidth = halfSize;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ObstacleDetector characterDetector))
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0)
                {
                    OnCollided?.Invoke();
                    Debug.Log("Collided");
                    currentTime = PerfectCollideTime;
                    return;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ObstacleDetector characterDetector))
            {
                currentTime = PerfectCollideTime;
            }
        }
    }
}

using Character;
using Obstacles.Intefaces;
using System;
using UnityEngine;

namespace Obstacles
{
    public class PerfectCollideDetector : MonoBehaviour, IPerfectCollideDetector
    {
        public event Action OnPerfectCollideDetect;
        private ObstacleModel _obstacleModel;
        private LineRenderer _colliderRenderer;

        private float currentTime;

        public void SetObstacleModel(ObstacleModel obstacleModel)
        {
            _obstacleModel = obstacleModel;
            _colliderRenderer = GetComponent<LineRenderer>();
            currentTime = _obstacleModel.PerfectCollideTime;
            RenderCircle();
            //RenderLine();
        }

        private void RenderLine()
        {
            _colliderRenderer.positionCount = 5;

            Vector3[] cubeVertices = new Vector3[5];
            float halfSize = _obstacleModel.PerfectCollideSize;

            cubeVertices[0] = new Vector3(-halfSize * 1.5f, -halfSize, 0f);
            cubeVertices[1] = new Vector3(halfSize, -halfSize, 0f);
            cubeVertices[2] = new Vector3(halfSize, halfSize, 0f);
            cubeVertices[3] = new Vector3(-halfSize, halfSize, 0f);
            cubeVertices[4] = new Vector3(-halfSize, -halfSize, 0f);

            _colliderRenderer.SetPositions(cubeVertices);
            _colliderRenderer.startWidth = halfSize;
            _colliderRenderer.endWidth = halfSize;
        }

        private void RenderCircle()
        {
            int numPoints = 36; 
            float radius = 0.5f;

            _colliderRenderer.positionCount = numPoints;

            float angle = 0f;
            for (int i = 0; i < numPoints; i++)
            {
                float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
                float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
                Vector3 pos = new Vector3(x, y, 0f);
                _colliderRenderer.SetPosition(i, pos);
                angle += 360f / numPoints;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ObstacleDetector characterDetector))
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0)
                {
                    OnPerfectCollideDetect?.Invoke();
                    Debug.Log("Collided");
                    currentTime = _obstacleModel.PerfectCollideTime;
                    return;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ObstacleDetector characterDetector))
            {
                currentTime = _obstacleModel.PerfectCollideTime;
            }
        }
    }
}

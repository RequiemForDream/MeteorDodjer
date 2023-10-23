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
        private float currentTime;

        public void SetObstacleModel(ObstacleModel obstacleModel)
        {
            _obstacleModel = obstacleModel;
            currentTime = _obstacleModel.PerfectCollideTime;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ObstacleDetector characterDetector))
            {
                currentTime -= Time.deltaTime;
                if (currentTime <= 0)
                {
                    OnPerfectCollideDetect?.Invoke();
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

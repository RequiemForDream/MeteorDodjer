using Core;
using Obstacles.Intefaces;
using Sounds.Interfaces;
using System;
using UI.Interfaces;
using UnityEngine;
using Utils;

namespace Obstacles
{
    public class Obstacle : IObstacle
    {
        public event Action OnPerfectCollided;
        public ObstacleView ObstacleView { get; set; }
        public ObstacleModel ObstacleModel { get; private set; }

        private readonly Updater _updater;
        private readonly ISoundFactory _soundFactory;
        private readonly ICounter<int> _multiplierCounter;

        private Vector2 Direction;

        public Obstacle(ObstacleView obstacleView, ObstacleModel obstacleModel, Updater updater, ISoundFactory soundFactory,
            ICounter<int> multiplierCounter)
        {
            ObstacleView = obstacleView;
            ObstacleModel = obstacleModel;
            _updater = updater;
            _soundFactory = soundFactory;
            _multiplierCounter = multiplierCounter;

            Initialize();
        }

        private void Initialize()
        {
            ObstacleView.Initialize(ObstacleModel);
            _updater.AddFixedUpdateListener(this);
            ObstacleView.OnDestroyHandler += Destroy;
            ObstacleView.PerfectCollideDetector.OnPerfectCollideDetect += PerfectCollideDetected;
            ObstacleView.SetLifeTime(ObstacleModel.LifeTime);
        }

        public void SetPosition(Vector2 position)
        {
            ObstacleView.transform.position = position;
        }

        public void SetDirection(Vector2 direction)
        {
            Direction = direction;
        }

        public void SetParent(Transform parent)
        {
            ObstacleView.transform.SetParent(parent);
        }

        public void FixedTick(float fixedDeltaTime)
        {
            ObstacleView.Rigidbody2D.velocity = Direction;
        }

        public void Clear()
        {
            Extensions.Deactivate(ObstacleView.gameObject);
        }

        private void PerfectCollideDetected()
        {
            OnPerfectCollided?.Invoke();
            _multiplierCounter.AddValue(1);
            _soundFactory.PlaySound(ObstacleModel.PerfectCollideSound);
        }

        private void Destroy()
        {
            _updater.RemoveFixedUpdateListener(this);
            ObstacleView.OnDestroyHandler -= Destroy;
        }
    }
}

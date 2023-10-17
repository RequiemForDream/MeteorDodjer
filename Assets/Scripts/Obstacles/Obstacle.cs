using Core;
using Obstacles.Intefaces;
using System;
using UnityEngine;
using Utils;

namespace Obstacles
{
    public class Obstacle : IObstacle, ITest
    {
        public ObstacleView ObstacleView { get; set; }
        public ObstacleModel ObstacleModel { get; private set; }

        private readonly Updater _updater;
        private Vector2 Direction;

        public event Action OnPerfectCollide;

        public Obstacle(ObstacleView obstacleView, ObstacleModel obstacleModel, Updater updater)
        {
            ObstacleView = obstacleView;
            ObstacleModel = obstacleModel;
            _updater = updater;

            Initialize();
            ObstacleView.OnDestroyHandler += Destroy;
            ObstacleView.SetLifeTime(ObstacleModel.LifeTime);
            ObstacleView.Initialize();
        }

        public void Initialize()
        {        
            _updater.AddFixedUpdateListener(this);
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
           // _updater.RemoveFixedUpdateListener(this);
            //ObstacleView.Destroy();
        }

        private void Destroy()
        {
            _updater.RemoveFixedUpdateListener(this);
            ObstacleView.OnDestroyHandler -= Destroy;
        }
    }
}

using Core;
using Core.Interfaces;
using Obstacles.Intefaces;
using UnityEngine;

namespace Obstacles
{
    public class Obstacle : IFixedUpdateListener, IObstacle
    {
        public ObstacleView ObstacleView { get; set; }
        public ObstacleModel ObstacleModel { get; private set; }

        private readonly Updater _updater;
        private Vector2 Direction;

        public Obstacle(ObstacleView obstacleView, ObstacleModel obstacleModel, Updater updater)
        {
            ObstacleView = obstacleView;
            ObstacleModel = obstacleModel;
            _updater = updater;
            ObstacleView.Initialize();
            ObstacleView.OnDestroyHandler += Destroy;
            _updater.AddFixedUpdateListener(this);
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

        public void FixedTick(float fixedDeltaTime)
        {
            ObstacleView.Rigidbody2D.velocity = Direction;
        }

        private void Destroy()
        {
            _updater.RemoveFixedUpdateListener(this);
            ObstacleView.OnDestroyHandler -= Destroy;
        }
    }
}

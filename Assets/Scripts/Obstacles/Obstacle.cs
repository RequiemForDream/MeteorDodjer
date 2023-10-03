using Core;
using Core.Interfaces;
using UnityEngine;

namespace Obstacles
{
    public class Obstacle : IUpdateListener
    {
        public ObstacleView ObstacleView { get; set; }
        public ObstacleModel ObstacleModel { get; set; }

        private readonly Updater _updater;
        private DirectionEnum _direction;

        public Obstacle(ObstacleView obstacleView, ObstacleModel obstacleModel, Updater updater)
        {
            ObstacleView = obstacleView;
            ObstacleModel = obstacleModel;
            _updater = updater;

            ObstacleView.Initialize();
            
            ObstacleView.OnDestroyHandler += Destroy;
        }

        public void Initialize(DirectionEnum direction)
        {
            _direction = direction;
            _updater.AddListener(this);
        }

        public void Tick(float deltaTime)
        {
            switch (_direction)
            {
                case DirectionEnum.Down:
                    ObstacleView.Rigidbody2D.velocity = new Vector2(0, -2);
                    break;
                case DirectionEnum.Left:
                    ObstacleView.Rigidbody2D.velocity = new Vector2(-2, 0);
                    break;
                case DirectionEnum.Right:
                    ObstacleView.Rigidbody2D.velocity = new Vector2(2, 0);
                    break;
                case DirectionEnum.Up:
                    ObstacleView.Rigidbody2D.velocity = new Vector2(0, 2);
                    break;
            }
        }

        private void Destroy()
        {
            _updater?.RemoveListener(this);
            ObstacleView.OnDestroyHandler -= Destroy;
        }
    }
}

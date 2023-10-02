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

        public Obstacle(ObstacleView obstacleView, ObstacleModel obstacleModel, Updater updater)
        {
            ObstacleView = obstacleView;
            ObstacleModel = obstacleModel;
            _updater = updater;
        }

        public void Initialize()
        {
            _updater.AddListener(this);
            ObstacleView.OnDestroyHandler += Destroy;
        }

        public void Tick(float deltaTime)
        {
            
        }

        private void Destroy()
        {
            _updater?.RemoveListener(this);
            ObstacleView.OnDestroyHandler -= Destroy;
        }
    }
}

using Core;
using Factories.Interfaces;
using Obstacles;
using Obstacles.Intefaces;
using Object = UnityEngine.Object;

namespace Factories 
{
    public class ObstacleFactory : IFactory<IObstacle>
    {
        private readonly Updater _updater;
        private readonly ObstacleConfig _obstacleConfig;

        public ObstacleFactory(Updater updater, ObstacleConfig obstacleConfig)
        {
            _updater = updater;
            _obstacleConfig = obstacleConfig;
        }

        public IObstacle Create()
        {
            ObstacleView obstacleView = Object.Instantiate(_obstacleConfig.ObstaclePrefab);

            IObstacle obstacle = new Obstacle(obstacleView, _obstacleConfig.ObstacleModel, _updater);

            return obstacle;
        }
    }
}

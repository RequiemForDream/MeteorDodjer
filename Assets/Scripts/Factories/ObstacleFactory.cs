using Core;
using Factories.Interfaces;
using Obstacles;
using Object = UnityEngine.Object;

namespace Factories 
{
    public class ObstacleFactory : IFactory<Obstacle>
    {
        private readonly Updater _updater;
        public readonly ObstacleConfig _obstacleConfig;

        public ObstacleFactory(Updater updater, ObstacleConfig obstacleConfig)
        {
            _updater = updater;
            _obstacleConfig = obstacleConfig;
        }

        public Obstacle Create()
        {
            ObstacleView obstacleView = Object.Instantiate(_obstacleConfig.ObstaclePrefab);

            Obstacle obstacle = new Obstacle(obstacleView, _obstacleConfig.ObstacleModel, _updater);

            return obstacle;
        }
    }
}

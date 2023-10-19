using Core;
using Factories.Interfaces;
using Obstacles;
using Obstacles.Intefaces;
using Sounds.Interfaces;
using UI.Interfaces;
using Object = UnityEngine.Object;

namespace Factories 
{
    public class ObstacleFactory : IFactory<IObstacle>
    {
        private readonly Updater _updater;
        private readonly ObstacleConfig _obstacleConfig;
        private readonly ISoundFactory _soundFactory;
        private readonly ICounter<int> _multiplierCounter;

        public ObstacleFactory(Updater updater, ObstacleConfig obstacleConfig, ISoundFactory soundFactory,
            ICounter<int> multiplierCounter)
        {
            _updater = updater;
            _obstacleConfig = obstacleConfig;
            _soundFactory = soundFactory;
            _multiplierCounter = multiplierCounter;
        }

        public IObstacle Create()
        {
            ObstacleView obstacleView = Object.Instantiate(_obstacleConfig.ObstaclePrefab);

            IObstacle obstacle = new Obstacle(obstacleView, _obstacleConfig.ObstacleModel, _updater, _soundFactory, _multiplierCounter);

            return obstacle;
        }
    }
}

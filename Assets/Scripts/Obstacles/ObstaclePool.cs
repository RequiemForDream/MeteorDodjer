using Factories.Interfaces;
using System.Collections.Generic;

namespace Obstacles
{
    public class ObstaclePool
    {
        private readonly IFactory<Obstacle> _obstacleFactory;
        private readonly int _poolCount;
        private readonly bool _autoExpand;

        private List<Obstacle> _pool = new List<Obstacle>();

        public ObstaclePool(bool autoExpand, int poolCount, IFactory<Obstacle> obstacleFactory)
        {
            _autoExpand = autoExpand;
            _poolCount = poolCount;
            _obstacleFactory = obstacleFactory;

            CreatePool();
        }

        private void CreatePool()
        {
            for (int i = 0; i < _poolCount; i++)
            {
                SpawnObstacle();
            }
        }

        private Obstacle SpawnObstacle(bool isActiveByDefault = false)
        {
            var obstacle = _obstacleFactory.Create();
            obstacle.ObstacleView.gameObject.SetActive(isActiveByDefault);
            _pool.Add(obstacle);
            return obstacle;
        }

        public Obstacle GetFreeElement()
        {
            if (HasFreeElement(out var element))
            {
                return element;
            }

            if (_autoExpand)
            {
                return SpawnObstacle(true);
            }

            throw new System.Exception($"There is no free elements in pool of type {typeof(Obstacle)}");
        }

        public bool HasFreeElement(out Obstacle element)
        {
            foreach (var obstacle in _pool)
            {
                if (!obstacle.ObstacleView.gameObject.activeInHierarchy)
                {
                    element = obstacle;
                    obstacle.ObstacleView.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }
    }
}

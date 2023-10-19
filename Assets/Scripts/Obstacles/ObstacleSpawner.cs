using Character.Interfaces;
using Core;
using Core.Interfaces;
using Factories.Interfaces;
using Obstacles.Intefaces;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleSpawner : IObstacleSpawner
    {
        private readonly Updater _updater;
        private readonly ObstacleSpawnerConfig _obstacleSpawnerConfig;
        private readonly IFactory<IObstacle> _obstacleFactory;
        private readonly ICharacter _character;
        private GameObject _container = new GameObject("Obstacle Pool");
        private IObstaclePool _obstaclePool;

        private float _currentTime;

        public ObstacleSpawner(Updater updater, IFactory<IObstacle> obstacleFactory, ObstacleSpawnerConfig obstacleSpawnerConfig, 
            IListenersHandler<IInitializable> initializator, IListenersHandler<IClearable> clearer, ICharacter character)
        {
            _updater = updater;
            _obstacleSpawnerConfig = obstacleSpawnerConfig;
            _obstacleFactory = obstacleFactory;
            _character = character;
            initializator.AddListener(this);
            clearer.AddListener(this);           
            _obstaclePool = new ObstaclePool(_obstacleSpawnerConfig.AutoExpand, _obstacleSpawnerConfig.Count, _obstacleFactory,
                _container);
            _obstaclePool.CreatePool();
        }

        public void Initialize()
        {
            _updater.AddUpdateListener(this);
            _currentTime = _obstacleSpawnerConfig.SpawnDelay;
        }

        public void Tick(float deltaTime)
        {
            _currentTime -= deltaTime;
            if (_currentTime < 0)
            {
                SetParameters();
                _currentTime = _obstacleSpawnerConfig.SpawnDelay;
            }
        }

        private void SetParameters()
        {
            var obstacle = _obstaclePool.GetFreeElement();
            var pos = CalculatePosition(_character.IsMovingRight, out Vector2 direction);
            obstacle.SetPosition(pos);
            obstacle.SetDirection(direction);
        }

        public void Clear()
        {
            _currentTime = 0f;
            _obstaclePool.Clear();
            _updater.RemoveUpdateListener(this);
            //_obstaclePool = null;
        }

        private Vector2 CalculatePosition(bool isMovingRight, out Vector2 direction)
        {
            var characterPosition = _character.Transform.position;
            var characterSpeed = _character.MovementSpeed;
            if (isMovingRight)
            {
                var distanceAhead = characterPosition + Vector3.right * characterSpeed;
                var randomOffset = _obstacleSpawnerConfig.ObstacleOffset;
                float randomY = Random.Range(distanceAhead.y + randomOffset, distanceAhead.y - randomOffset);
                direction = CalculateDirection(randomY, distanceAhead.y, isMovingRight); 
                return new Vector2(distanceAhead.x, randomY);
            }
            else
            {
                var distanceAhead = characterPosition + Vector3.up * characterSpeed;
                var randomOffset = _obstacleSpawnerConfig.ObstacleOffset;
                float randomX = Random.Range(distanceAhead.x + randomOffset, distanceAhead.x - randomOffset);
                direction = CalculateDirection(randomX, distanceAhead.x, isMovingRight);
                return new Vector2(randomX, distanceAhead.y);
            }
        }

        private Vector2 CalculateDirection(float obstaclePosition, float characterPos, bool isMovingRight)
        {
            var obstacleDirection = _obstacleSpawnerConfig.ObstacleDirection;
            var obstacleSpeed = _obstacleSpawnerConfig.ObstacleSpeed;
            if (isMovingRight)
            {
                if (obstaclePosition > characterPos)
                {
                    return new Vector2(-obstacleDirection, -obstacleSpeed);
                }
                else
                {
                    return new Vector2(-obstacleDirection, obstacleSpeed);
                }
            }
            else
            {
                if (obstaclePosition > characterPos)
                {
                    return new Vector2(-obstacleSpeed, -obstacleDirection);
                }
                else
                {
                    return new Vector2(obstacleSpeed, -obstacleDirection);
                }
            }
        }
    }
}

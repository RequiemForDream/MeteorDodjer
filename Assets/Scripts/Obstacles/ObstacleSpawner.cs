using Character.Interfaces;
using Core;
using Core.Interfaces;
using Factories.Interfaces;
using Obstacles.Intefaces;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleSpawner : IUpdateListener
    {
        private readonly Updater _updater;
        private readonly ICharacter _character;
        private readonly ObstacleSpawnerConfig _obstacleSpawnerConfig;
        private IObstaclePool _obstaclePool;

        private float _currentTime;

        public ObstacleSpawner(Updater updater, IFactory<IObstacle> obstacleFactory, ICharacter character, 
            ObstacleSpawnerConfig obstacleSpawnerConfig)
        {
            _updater = updater;
            _character = character;
            _obstacleSpawnerConfig = obstacleSpawnerConfig;
            
            _obstaclePool = new ObstaclePool(_obstacleSpawnerConfig.AutoExpand, _obstacleSpawnerConfig.Count, obstacleFactory);
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
                InitializeObstacle();
                _currentTime = _obstacleSpawnerConfig.SpawnDelay;
            }
        }

        private void InitializeObstacle()
        {
            var obstacle = _obstaclePool.GetFreeElement();
            var pos = CalculatePosition(_character.IsMovingRight, out Vector2 direction);
            obstacle.SetPosition(pos);
            obstacle.SetDirection(direction);
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

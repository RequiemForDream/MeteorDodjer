using Character.Interfaces;
using Core;
using Core.Interfaces;
using Factories.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Obstacles
{
    public class ObstacleSpawner : IUpdateListener
    {
        private readonly Updater _updater;
        private readonly IFactory<Obstacle> _obstacleFactory;
        private readonly ICharacter _character;
        private readonly ObstacleSpawnerConfig _obstacleSpawnerConfig;
        private readonly Camera _camera;
        private Coroutine _coroutine;

        private List<Obstacle> _obstacles = new List<Obstacle>();

        public ObstacleSpawner(Updater updater, IFactory<Obstacle> obstacleFactory, ICharacter character, 
            ObstacleSpawnerConfig obstacleSpawnerConfig, Camera camera)
        {
            _obstacleFactory = obstacleFactory;
            _updater = updater;
            _character = character;
            _obstacleSpawnerConfig = obstacleSpawnerConfig;
            _camera = camera;
        }

        public void Initialize()
        {
            _updater.AddListener(this);
            _character.OnTurned += CountDirection;
        }

        public void Tick(float deltaTime)
        {
            
        }

        private void SpawnTest(bool isMovingRight)
        {
            Obstacle obstacle = _obstacleFactory.Create();
            _obstacles.Add(obstacle);
            
            obstacle.ObstacleView.transform.position += CalculatePosition(isMovingRight, out DirectionEnum direction);
            Debug.Log(direction);
            obstacle.Initialize(direction);
        }

        private Vector3 CalculatePosition(bool isMovingRight, out DirectionEnum direction)
        {
            DirectionEnum _direction;
            if (isMovingRight)
            {
                var characterPosition = _character.CharacterView.transform.position + Vector3.right * 5f;
                float randomY = Random.Range(characterPosition.y + 4f, characterPosition.y - 4f);
                Vector3 last = new Vector3(characterPosition.x, randomY, 0f);
                if (randomY > characterPosition.y)
                {
                    _direction = DirectionEnum.Down;
                    direction = _direction;
                    Debug.Log("Down");
                    return last;
                }
                else if(randomY < characterPosition.y)
                {
                    _direction = DirectionEnum.Up;
                    direction = _direction;
                    return last;
                }

                _direction = DirectionEnum.Down;
                direction = _direction;
                return last;
            }
            else
            {
                var characterPosition = _character.CharacterView.transform.position + Vector3.up * 5f;
                float randomX = Random.Range(characterPosition.x + 4f, characterPosition.x - 4f);
                Vector3 last = new Vector3(randomX, characterPosition.y, 0f);
                
                if (randomX < characterPosition.x)
                {
                    _direction = DirectionEnum.Right; 
                    direction = _direction;
                    return last;
                }
                else if (randomX > characterPosition.x)
                {
                    _direction = DirectionEnum.Left; 
                    direction = _direction;
                    return last;
                }

                direction = DirectionEnum.Left;
                return last;
            }
        }

        private void CountDirection(bool isMovingRight)
        {
            if (isMovingRight)
            {
                SpawnObstacle(isMovingRight);
            }
            else
            {
                SpawnObstacle(isMovingRight);
            }
        }

        private void SpawnObstacle(bool isMovingRight)
        {
            if (_coroutine != null)
            {
                CoroutineExtension.StopRoutine(_coroutine);
                _coroutine = null;
            }

           _coroutine = CoroutineExtension.StartRoutine(SpawnRoutine(isMovingRight));
        }

        private IEnumerator SpawnRoutine(bool isMovingRight)
        {
            int obstacles = 0;
            while(true)
            {
                SpawnTest(isMovingRight);
                obstacles++;
                yield return new WaitForSeconds(_obstacleSpawnerConfig.SpawnDelay);
            }
        }
    }
}

using Character.Interfaces;
using Core;
using Core.Interfaces;
using Factories.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleSpawner : IUpdateListener
    {
        private readonly Updater _updater;
        private readonly IFactory<Obstacle> _obstacleFactory;
        private readonly ICharacter _character;
        private readonly ObstacleSpawnerConfig _obstacleSpawnerConfig;
        private readonly Camera _camera;

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
        }

        public void Tick(float deltaTime)
        {
            if (_obstacles.Count > 5)
            {
                return;
            }

            SpawnObstacle();
        }

        private void SpawnObstacle()
        {
            Obstacle obstacle = _obstacleFactory.Create();
            obstacle.Initialize();
            obstacle.ObstacleView.transform.position += CalculatePosition();
            _obstacles.Add(obstacle);
        }

        private Vector3 CalculatePosition()
        {
            var viewportSpacePosition = Vector2.Lerp(_obstacleSpawnerConfig._viewportFrom, _obstacleSpawnerConfig._viewportTo,
                Random.value);

            var inWorldSpace = _camera.ViewportToWorldPoint(new Vector3(viewportSpacePosition.x, viewportSpacePosition.y, 0));
            var withOffset = inWorldSpace + _obstacleSpawnerConfig._offset;
            var pos = _character.CharacterView.transform.position + withOffset;
            return pos;
        }
    }
}

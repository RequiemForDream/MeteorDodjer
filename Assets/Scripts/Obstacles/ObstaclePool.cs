﻿using Factories.Interfaces;
using Obstacles.Intefaces;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class ObstaclePool : IObstaclePool
    {
        private readonly IFactory<IObstacle> _obstacleFactory;
        private readonly int _poolCount;
        private readonly bool _autoExpand;
        private readonly GameObject _container;
        private List<IObstacle> _pool;

        public ObstaclePool(bool autoExpand, int poolCount, IFactory<IObstacle> obstacleFactory, GameObject container)
        {
            _autoExpand = autoExpand;
            _poolCount = poolCount;
            _obstacleFactory = obstacleFactory;
            _container = container;
        }

        public void CreatePool()
        {
            _pool = new List<IObstacle>();
            for (int i = 0; i < _poolCount; i++)
            {
                SpawnObstacle();
            }
        }

        private IObstacle SpawnObstacle(bool isActiveByDefault = false)
        {
            var obstacle = _obstacleFactory.Create();
            obstacle.ObstacleView.gameObject.SetActive(isActiveByDefault);
            obstacle.SetParent(_container.transform);
            _pool.Add(obstacle);
            return obstacle;
        }

        public IObstacle GetFreeElement()
        {
            if (HasFreeElement(out var element))
            {
                return element;
            }

            if (_autoExpand)
            {
                return SpawnObstacle(true);
            }

            throw new System.Exception($"There is no free elements in pool of type {typeof(IObstacle)}");
        }

        private bool HasFreeElement(out IObstacle element)
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

        public void Clear()
        {
            foreach (var obstacle in _pool)
            {
                obstacle.Clear();
            }
        }
    }
}

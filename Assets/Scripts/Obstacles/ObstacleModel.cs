using System;
using UnityEngine;

namespace Obstacles
{
    [Serializable]
    public class ObstacleModel
    {
        [SerializeField] private float _lifeTime = 4f;
        public float LifeTime => _lifeTime;
    }
}

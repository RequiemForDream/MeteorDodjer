using System;
using UnityEngine;

namespace Obstacles
{
    [Serializable]
    public class ObstacleModel
    {
        [SerializeField] private float _lifeTime = 4f;
        [SerializeField] private float _perfectCollideTime = 0.25f;
        [SerializeField] private float _perfectCollideSize = 0.6f;
        [SerializeField] private AudioClip _perfectCollideSound;
        public float LifeTime => _lifeTime;
        public float PerfectCollideTime => _perfectCollideTime;
        public float PerfectCollideSize => _perfectCollideSize;
        public AudioClip PerfectCollideSound => _perfectCollideSound;
    }
}

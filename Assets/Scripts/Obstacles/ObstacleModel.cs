using System;
using UnityEngine;

namespace Obstacles
{
    [Serializable]
    public class ObstacleModel
    {
        [SerializeField] private float _lifeTime = 4f;
        [SerializeField] private float _perfectCollideTime = 0.25f;
        [SerializeField] private AudioClip _perfectCollideSound;
        [SerializeField] private int _multiplierPointsToAdd;
        public float LifeTime => _lifeTime;
        public float PerfectCollideTime => _perfectCollideTime;
        public AudioClip PerfectCollideSound => _perfectCollideSound;
        public int MultiplierPointsToAdd => _multiplierPointsToAdd;
    }
}

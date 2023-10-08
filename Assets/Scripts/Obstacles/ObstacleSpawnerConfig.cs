using UnityEngine;

namespace Obstacles
{
    [CreateAssetMenu(fileName = "ObstacleSpawnerConfig", menuName = "Obstacles / New Obstacle Spawner Config")]
    public class ObstacleSpawnerConfig : ScriptableObject
    {
        [Header("Spawn Stuff")]
        [SerializeField] private float _spawnDelay = 1f;

        [Header("Offset")]
        [SerializeField] private float MaxOffset = 4f;
        [SerializeField] private float MinOffset = 1f;

        [Header("Direction")]
        [SerializeField] private float MaxDirection = 1f;
        [SerializeField] private float MinDirection = 0f;

        [Header("Speed")]
        [SerializeField] private float _maxSpeed = 4f;
        [SerializeField] private float _minSpeed = 1f;

        [Header("Pool")]
        [SerializeField] private bool _autoExpand;
        [SerializeField] private int _count = 15;

        public float ObstacleOffset => Random.Range(MaxOffset, MinOffset);
        public float ObstacleDirection => Random.Range(MaxDirection, MinDirection);
        public float ObstacleSpeed => Random.Range(_minSpeed, _maxSpeed);
        public int Count => _count;
        public float SpawnDelay => _spawnDelay;
        public bool AutoExpand => _autoExpand;
    }
}

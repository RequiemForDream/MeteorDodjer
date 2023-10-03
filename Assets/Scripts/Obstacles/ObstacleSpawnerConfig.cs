using UnityEngine;

namespace Obstacles
{
    [CreateAssetMenu(fileName = "ObstacleSpawnerConfig", menuName = "Obstacles / New Obstacle Spawner Config")]
    public class ObstacleSpawnerConfig : ScriptableObject
    {
        public Vector2 _viewportFrom;
        public Vector2 _viewportTo;
        public Vector3 _offset;
        public int MaxAmount;
        public float SpawnDelay = 1f;
        public float AmountToSpawn;
    }
}

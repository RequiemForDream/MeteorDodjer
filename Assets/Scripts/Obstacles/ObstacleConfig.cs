using UnityEngine;

namespace Obstacles
{
    [CreateAssetMenu(fileName = "ObstacleConfig", menuName = "Obstacles / New Obstacle Config")]
    public class ObstacleConfig : ScriptableObject
    {
        public ObstacleView ObstaclePrefab;
        public ObstacleModel ObstacleModel;
    }
}

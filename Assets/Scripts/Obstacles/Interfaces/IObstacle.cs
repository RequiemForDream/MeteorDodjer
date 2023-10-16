using UnityEngine;

namespace Obstacles.Intefaces
{
    public interface IObstacle
    {
        ObstacleView ObstacleView { get; set; }
        void SetDirection(Vector2 direction);
        void SetPosition(Vector2 position);
        void SetParent(Transform parent);
    }
}

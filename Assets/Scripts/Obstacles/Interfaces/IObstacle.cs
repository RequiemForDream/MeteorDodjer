using Core;
using Core.Interfaces;
using UnityEngine;

namespace Obstacles.Intefaces
{
    public interface IObstacle : IFixedUpdateListener, IInitializable, IClearable
    {
        ObstacleView ObstacleView { get; set; }
        void SetDirection(Vector2 direction);
        void SetPosition(Vector2 position);
        void SetParent(Transform parent);
    }
}

using Core;

namespace Obstacles.Intefaces
{
    public interface IObstaclePool
    {
        void CreatePool();
        void Clear();
        IObstacle GetFreeElement();
    }
}

using Core;

namespace Obstacles.Intefaces
{
    public interface IObstaclePool
    {
        void Clear();
        IObstacle GetFreeElement();
    }
}

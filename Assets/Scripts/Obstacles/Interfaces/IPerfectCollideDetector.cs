using System;

namespace Obstacles.Intefaces
{
    public interface IPerfectCollideDetector
    {
        event Action OnPerfectCollideDetect;
        void SetObstacleModel(ObstacleModel obstacleModel);
    }
}

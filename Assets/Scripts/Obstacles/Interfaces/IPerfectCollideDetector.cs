using System;

namespace Obstacles.Intefaces
{
    public interface IPerfectCollideDetector
    {
        //ObstacleModel ObstacleModel { set; }
        event Action OnPerfectCollideDetect;
        void SetObstacleModel(ObstacleModel obstacleModel);
    }
}

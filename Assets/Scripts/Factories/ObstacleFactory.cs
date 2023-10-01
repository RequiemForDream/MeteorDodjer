using Factories.Interfaces;
using Obstacles;

namespace Factories 
{
    public class ObstacleFactory : IFactory<Obstacle>
    {
        public Obstacle Create()
        {
            throw new System.NotImplementedException();
        }
    }
}

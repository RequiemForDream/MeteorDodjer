using Character.Interfaces;
using Core;
using Core.Interfaces;

namespace Obstacles.Intefaces
{
    public interface IObstacleSpawner : IClearable, IInitializable, IUpdateListener
    {
        void SetCharacter(ICharacter character);
    }
}

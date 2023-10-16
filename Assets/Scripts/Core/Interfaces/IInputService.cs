using System;

namespace Core.Interfaces
{
    public interface IInputService : IInitializable, IClearable
    {
        event Action OnScreenTap;
    }
}

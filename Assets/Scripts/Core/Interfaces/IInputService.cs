using System;

namespace Core.Interfaces
{
    public interface IInputService : IInitializable, IClearable, IUpdateListener
    {
        event Action OnScreenTap;
    }
}

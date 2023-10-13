using System;

namespace Core.Interfaces
{
    public interface IInputService : IInitializable
    {
        event Action OnScreenTap;
    }
}

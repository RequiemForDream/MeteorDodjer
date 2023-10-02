using System;

namespace Core.Interfaces
{
    public interface IDestroyable
    {
        event Action OnDestroyHandler;
    }
}

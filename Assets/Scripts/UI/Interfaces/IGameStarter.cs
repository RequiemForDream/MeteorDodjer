using System;

namespace UI.Interfaces
{
    public interface IGameStarter
    {
        event Action OnGameStartPressed;
    }
}

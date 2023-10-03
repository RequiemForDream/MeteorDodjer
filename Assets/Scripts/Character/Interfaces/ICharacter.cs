using System;

namespace Character.Interfaces
{
    public interface ICharacter
    {
        CharacterView CharacterView { get; }
        CharacterModel CharacterModel { get; }

        bool IsMovingRight { get; set;  }
        event Action<bool> OnTurned;
    }
}

using System;
using UnityEngine;

namespace Character.Interfaces
{
    public interface ICharacter
    {
        event Action OnDied;
        Transform Transform {  get; } 
        bool IsMovingRight { get; set;  }
        float MovementSpeed { get; set; }
    }
}

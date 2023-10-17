using Core;
using Core.Interfaces;
using System;
using UnityEngine;

namespace Character.Interfaces
{
    public interface ICharacter : IInitializable, IClearable, IFixedUpdateListener
    {
        event Action OnDied;
        Transform Transform {  get; } 
        bool IsMovingRight { get; set;  }
        float MovementSpeed { get; }
    }
}

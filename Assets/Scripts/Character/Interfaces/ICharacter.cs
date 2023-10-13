using Core.Interfaces;
using System;
using UnityEngine;

namespace Character.Interfaces
{
    public interface ICharacter : IInitializable
    {
        event Action OnDied;
        Transform Transform {  get; } 
        bool IsMovingRight { get; set;  }
        float MovementSpeed { get; set; }
    }
}

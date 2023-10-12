using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public class CharacterModel
    {
        public float Speed;
        public Vector2 PauseVelocity => Vector2.zero;
    }
}

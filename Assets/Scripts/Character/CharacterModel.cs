using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public class CharacterModel
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _startPosition;
        public float Speed => _speed;
        public Vector2 StartPosition => _startPosition;
    }
}

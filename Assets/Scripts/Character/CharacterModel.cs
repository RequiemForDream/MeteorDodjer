using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public class CharacterModel
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private AudioClip _turnSound;
        [SerializeField] private float _scoreToAdd;
        public float Speed => _speed;
        public Vector2 StartPosition => _startPosition;
        public AudioClip TurnSound => _turnSound;
        public float ScoreToAdd => _scoreToAdd;
    }
}

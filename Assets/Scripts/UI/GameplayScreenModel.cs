using System;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class GameplayScreenModel
    {
        [SerializeField] private float _multiplierTimer;
        public float MultiplierTimer => _multiplierTimer;
    }
}

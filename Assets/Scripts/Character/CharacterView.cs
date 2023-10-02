using Core.Interfaces;
using System;
using UnityEngine;

namespace Character
{
    public class CharacterView : MonoBehaviour, IDestroyable
    { 
        public event Action OnDestroyHandler;
        public Rigidbody2D Rigidbody2D { get; private set; }

        public void Initialize()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}

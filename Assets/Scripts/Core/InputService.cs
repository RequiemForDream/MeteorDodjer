using Core.Interfaces;
using System;
using UnityEngine;

namespace Core
{
    public class InputService : IInputService, IUpdateListener
    {
        public event Action OnScreenTap;

        private readonly Updater _updater;

        public InputService(Updater updater)
        {
            _updater = updater;
        }

        public void Initialize()
        {
            _updater.AddUpdateListener(this);
        }

        public void Tick(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnScreenTap?.Invoke();
            }
        }
    }
}

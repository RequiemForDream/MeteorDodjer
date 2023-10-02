using Core.Interfaces;
using System;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleView : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroyHandler;

        public void OnBecameVisible()
        {
            
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}

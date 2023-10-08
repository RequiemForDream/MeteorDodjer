using Core.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Updater : MonoBehaviour
    {
        private List<IUpdateListener> _updateListeners = new List<IUpdateListener>();
        private List<IFixedUpdateListener> _fixedUpdateListeners = new List<IFixedUpdateListener>();

        private void Update()
        {
            for (int i = 0; i < _updateListeners.Count; i++)
            {
                _updateListeners[i].Tick(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                _fixedUpdateListeners[i].FixedTick(Time.fixedDeltaTime);
            }
        }

        public void AddUpdateListener(IUpdateListener listener)
        {
            _updateListeners.Add(listener);
        }

        public void AddFixedUpdateListener(IFixedUpdateListener listener)
        {
            _fixedUpdateListeners.Add(listener);
        }

        public void RemoveFixedUpdateListener(IFixedUpdateListener listener)
        {
            _fixedUpdateListeners.Remove(listener);
        }

        public void RemoveUpdateListener(IUpdateListener listener)
        {
            _updateListeners.Remove(listener);
        }
    }
}

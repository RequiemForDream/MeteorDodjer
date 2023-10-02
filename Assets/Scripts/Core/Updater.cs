using Core.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Updater : MonoBehaviour
    {
        private List<IUpdateListener> _updateListeners = new List<IUpdateListener>();

        private void Update()
        {
            foreach (IUpdateListener listener in _updateListeners)
            {
                //listener.Tick(Time.fixedDeltaTime);
            }

            for (int i = 0; i < _updateListeners.Count; i++)
            {
                _updateListeners[i].Tick(Time.fixedDeltaTime);
            }
        }

        public void AddListener(IUpdateListener listener)
        {
            _updateListeners.Add(listener);
        }

        public void RemoveListener(IUpdateListener listener)
        {
            _updateListeners.Remove(listener);
        }
    }
}

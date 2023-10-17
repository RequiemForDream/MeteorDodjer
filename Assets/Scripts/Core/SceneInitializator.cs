using Core.Interfaces;
using System.Collections.Generic;

namespace Core
{
    public class SceneInitializator : IListenersHandler<IInitializable>
    {
        private List<IInitializable> _initializables = new List<IInitializable>();

        public void InitializeListeners()
        {
            foreach (var initializable in _initializables)
            {
                initializable.Initialize();
            }

        }

        public void AddListener(IInitializable listener)
        {
            _initializables.Add(listener);
        }

        public void RemoveListener(IInitializable listener)
        {
            _initializables.Remove(listener);
        }
    }
}

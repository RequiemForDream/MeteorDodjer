using Core.Interfaces;
using System.Collections.Generic;

namespace Core
{
    public class Clearer : IListenersHandler<IClearable> 
    {
        private List<IClearable> _clearables = new List<IClearable>();

        public void Clear() 
        {
            foreach (IClearable clearable in _clearables)
            {
                clearable.Clear();
            }
        }

        public void AddListener(IClearable listener)
        {
            _clearables.Add(listener);
        }

        public void RemoveListener(IClearable listener)
        {
            _clearables.Remove(listener);
        }
    }
}

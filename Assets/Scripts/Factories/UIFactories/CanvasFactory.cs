using Factories.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories.UI
{
    public class CanvasFactory : IFactory<Canvas>
    {
        private readonly Canvas _canvas;

        public CanvasFactory(Canvas canvas)
        {
            _canvas = canvas;
        }

        public Canvas Create()
        {
            var canvas = Object.Instantiate(_canvas);

            return canvas;
        }
    }
}

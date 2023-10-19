using Factories.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories.UI
{
    public class CanvasFactory : IFactory<Canvas>
    {
        private readonly Canvas _canvas;
        private readonly Camera _camera;

        public CanvasFactory(Canvas canvas, Camera camera)
        {
            _canvas = canvas;
            _camera = camera;
        }

        public Canvas Create()
        {
            var canvas = Object.Instantiate(_canvas);
            canvas.worldCamera = _camera;

            return canvas;
        }
    }
}

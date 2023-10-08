using Core;
using Core.Interfaces;
using System.Collections;
using UnityEngine;
using Utils;

namespace Obstacles
{
    public class Obstacle : IFixedUpdateListener
    {
        public ObstacleView ObstacleView { get; set; }
        public ObstacleModel ObstacleModel { get; set; }

        private readonly Updater _updater;
        private Vector2 Direction;
        private Coroutine _coroutine;

        public Obstacle(ObstacleView obstacleView, ObstacleModel obstacleModel, Updater updater)
        {
            ObstacleView = obstacleView;
            ObstacleModel = obstacleModel;
            _updater = updater;

            ObstacleView.Initialize();
            ObstacleView.OnDestroyHandler += Destroy;
            ObstacleView.OnEnabledHandler += StartCoroutine;
            ObstacleView.OnDisabledHandler += StopCoroutine;
        }

        public void Initialize(Vector2 direction, Vector3 position)
        {
            ObstacleView.transform.position = position;
            _updater.AddFixedUpdateListener(this);
            Direction = direction;
        }

        public void FixedTick(float fixedDeltaTime)
        {
            ObstacleView.Rigidbody2D.velocity = Direction;
        }

        private void StartCoroutine()
        {
            _coroutine = CoroutineExtension.StartRoutine(LifeRoutine());
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(ObstacleModel.LifeTime);          
            ObstacleView.Deactivate();
        }

        private void StopCoroutine()
        {
            CoroutineExtension.StopRoutine(_coroutine);
        }

        private void Destroy()
        {
            _updater?.RemoveFixedUpdateListener(this);
            ObstacleView.OnDestroyHandler -= Destroy;
        }
    }
}

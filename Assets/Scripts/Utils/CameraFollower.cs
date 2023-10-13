using Core;
using Core.Interfaces;
using UnityEngine;

namespace Utils
{
    public class CameraFollower : MonoBehaviour, IUpdateListener
    {
        [SerializeField] private Vector3 _offset;
        private Transform _followTarget;
        private Updater _updater;

        public void Initialize(Transform followTarget)
        {
            _followTarget = followTarget;
        }

        public void Tick(float deltaTime)
        {
            
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }

        private void Move(float deltaTime)
        {
            var tm = deltaTime * 10;

            var focusPoint = Vector3.Lerp(transform.position, _followTarget.position + _offset, tm);
            transform.position = focusPoint;
        }
    }
}

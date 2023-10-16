using UnityEngine;

namespace Utils
{
    public class CameraFollower : MonoBehaviour
    {
        private Transform _followTarget;
        private CameraModel _cameraModel;

        public void Initialize(Transform followTarget, CameraModel cameraModel)
        {
            _followTarget = followTarget;
            _cameraModel = cameraModel;
        }

        private void FixedUpdate()
        {
            if (_followTarget != null)
            {
                Move(Time.fixedDeltaTime);
            }
        }

        private void Move(float deltaTime)
        {
            var tm = deltaTime * _cameraModel.Distance;

            var focusPoint = Vector3.Lerp(transform.position, _followTarget.position + _cameraModel.Offset, tm);
            transform.position = focusPoint;
        }
    }
}

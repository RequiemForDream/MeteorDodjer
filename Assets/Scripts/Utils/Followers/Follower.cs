using UnityEngine;

namespace Utils
{
    public abstract class Follower : MonoBehaviour
    {
        private FollowModel _followModel;
        private Transform _followTarget;

        public void Construct(FollowModel followModel, Transform followTarget)
        {
            _followModel = followModel;
            _followTarget = followTarget;
        }

        protected void Move(float deltaTime)
        {
            var tm = deltaTime * _followModel.Distance;
            var nextPosition = Vector3.Lerp(transform.position, _followTarget.position + _followModel.Offset, tm);

            transform.position = nextPosition;
        }
    }
}
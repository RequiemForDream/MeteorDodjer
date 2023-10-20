using UnityEngine;

namespace Utils
{
    public class CameraFollower : Follower
    {
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }
    }
}

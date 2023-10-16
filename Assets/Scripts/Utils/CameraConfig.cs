using UnityEngine;

namespace Utils
{
    [CreateAssetMenu(fileName = "Camera Config", menuName = "Camera / New Camera Config")]
    public class CameraConfig : ScriptableObject
    {
        public CameraModel CameraModel;
    }
}

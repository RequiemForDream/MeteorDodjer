using UnityEngine;

namespace Utils.Visual
{
    [CreateAssetMenu(fileName = "Background Config", menuName = "New Visual Config/ New Background Config")]
    public class BackgroundConfig : FollowConfig 
    {
        public Background BackgroundPrefab;
        public BackgroundModel BackgroundModel;
    }
}

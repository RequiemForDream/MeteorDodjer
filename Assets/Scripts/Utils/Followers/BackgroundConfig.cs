using UnityEngine;

namespace Utils
{
    [CreateAssetMenu(fileName = "Follow Config", menuName = "Follow / New Background Config")]
    public class BackgroundConfig : FollowConfig 
    {
        [SerializeField] private Sprite[] _backgrounds;

        public Sprite GetRandomSprite()
        {
            var sprite = _backgrounds[Random.Range(0, _backgrounds.Length)];
            return sprite;
        }
    }
}

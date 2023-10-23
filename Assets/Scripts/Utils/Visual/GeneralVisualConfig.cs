using UnityEngine;

namespace Utils.Visual
{
    [CreateAssetMenu]
    public class GeneralVisualConfig : ScriptableObject
    {
        [SerializeField] private BackgroundConfig _backgroundConfig;
        [SerializeField] private ParticleConfig _particleConfig;

        public BackgroundConfig BackgroundConfig => _backgroundConfig;
        public ParticleConfig ParticleConfig => _particleConfig;
    }
}

using UnityEngine;

namespace Utils.Visual
{
    [CreateAssetMenu(fileName = "Background Particle", menuName = "New Visual Config/ New Particle Config")]
    public class ParticleConfig : FollowConfig
    {
        public BackgroundParticle ParticlePrefab;
    }
}

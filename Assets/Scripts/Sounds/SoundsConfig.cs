using UnityEngine;

namespace Sounds
{
    [CreateAssetMenu(fileName = "Sounds Config", menuName = "Sounds / New Sounds Config")]
    public class SoundsConfig : ScriptableObject
    {
        [SerializeField] private AudioClip _turnSound;
        
        public AudioClip TurnSound => _turnSound;
    }
}

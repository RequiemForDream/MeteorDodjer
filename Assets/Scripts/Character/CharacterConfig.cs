using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "Character Config", menuName = "Character / New Character Config")]
    public class CharacterConfig : ScriptableObject
    {
        public CharacterView CharacterPrefab;
        public CharacterModel CharacterModel;
    }
}

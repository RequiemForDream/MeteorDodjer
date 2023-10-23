using System;
using UnityEngine;

namespace Utils.Visual
{
    [Serializable]
    public class BackgroundModel
    {
        [SerializeField] private Sprite[] _backgrounds;
        public Sprite[] Backgrounds => _backgrounds;
    }
}

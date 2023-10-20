using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class FollowModel
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _distance;
        public Vector3 Offset => _offset;
        public float Distance => _distance;
    }
}

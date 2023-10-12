using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct MovementEcsComponent
    {
        public Transform Transform;
        public float Speed;
        public float Amplitude;
        public float StartZ;
    }
}
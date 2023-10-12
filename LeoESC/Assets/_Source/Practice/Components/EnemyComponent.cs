using System;
using UnityEngine;

namespace Client {
    [Serializable]
    public struct EnemyComponent 
    {
        public float Speed;
        public float Health;
        public float ShootDelay;
        public float Timer;
        public Transform Transform;
        public GameObject Gun;
    }
}
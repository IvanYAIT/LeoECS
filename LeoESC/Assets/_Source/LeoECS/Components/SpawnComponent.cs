using System;
using UnityEngine;

namespace Client {

    [Serializable]
    public struct SpawnComponent {
        public GameObject Prefab;
        public int AmountOfObjects;
    }
}
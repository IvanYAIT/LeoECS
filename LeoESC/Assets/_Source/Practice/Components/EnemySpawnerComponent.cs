using System;
using UnityEngine;

namespace Client {

    [Serializable]
    public struct EnemySpawnerComponent
    {
        public int EnemiesPerRound;
        public float SpawnDelay;
        public GameObject EnemyPrefab;
        public TransformRange TransformRange;
        public float Timer;
    }
}
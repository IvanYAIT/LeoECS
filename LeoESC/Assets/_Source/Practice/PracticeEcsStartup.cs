using Leopotam.EcsLite;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace Client {
    sealed class PracticeEcsStartup : MonoBehaviour {
        EcsWorld _world;        
        IEcsSystems _systems;

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _systems
                .ConvertScene()
                .Add(new EnemySpawnerSystem())
                .Add(new EnemySystem())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
            }

            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}
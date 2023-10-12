using Leopotam.EcsLite;
using UnityEngine;
using Voody;
using Voody.UniLeo.Lite;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;        
        IEcsSystems _systems;

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _systems
                .ConvertScene()
                .Add(new NumberIncrimitationSystem())
                .Add(new MovementSystem())
                .Add(new SpawnSystem())
#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
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
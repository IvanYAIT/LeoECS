using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class MovementSystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _filter;
        private EcsPool<MovementEcsComponent> _entityPool;
        private int direction = 1;

        public void Init (IEcsSystems systems) 
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<MovementEcsComponent>().End();
            _entityPool = world.GetPool<MovementEcsComponent>();
            foreach (int entity in _filter)
            {
                ref MovementEcsComponent movementEcsComponent = ref _entityPool.Get(entity);
                ref var transform = ref movementEcsComponent.Transform;
                ref var startZ = ref movementEcsComponent.StartZ;
                startZ = transform.position.z;
            }
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref MovementEcsComponent movementEcsComponent = ref _entityPool.Get(entity);
                ref var transform = ref movementEcsComponent.Transform;
                ref var speed = ref movementEcsComponent.Speed;
                ref var amplitude = ref movementEcsComponent.Amplitude;
                ref var startZ = ref movementEcsComponent.StartZ;

                transform.position += new Vector3(speed * Time.deltaTime, 0, speed* direction * Time.deltaTime);

                if(startZ+amplitude <= transform.position.z && direction > 0)
                {
                    direction *= -1;
                    startZ = transform.position.z;
                } else if (startZ - amplitude >= transform.position.z && direction < 0)
                {
                    direction *= -1;
                    startZ = transform.position.z;
                }
            }
        }
    }
}
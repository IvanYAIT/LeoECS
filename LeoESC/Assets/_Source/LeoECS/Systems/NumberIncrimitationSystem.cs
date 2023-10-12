using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class NumberIncrimitationSystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _filter;
        private EcsPool<EcsComponent> _entityPool;
        
        public void Init (IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsComponent>().End();
            _entityPool = world.GetPool<EcsComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref EcsComponent testComponent = ref _entityPool.Get(entity);
                ref var counter = ref testComponent.Counter;
                counter++;
                Debug.Log(counter);
            }
        }
    }
}
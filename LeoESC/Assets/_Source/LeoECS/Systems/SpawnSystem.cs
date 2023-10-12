using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class SpawnSystem : IEcsInitSystem {

        private EcsFilter _filter;
        private EcsPool<SpawnComponent> _entityPool;

        public void Init (IEcsSystems systems) 
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<SpawnComponent>().End();
            _entityPool = world.GetPool<SpawnComponent>();
            foreach (int entity in _filter)
            {
                ref SpawnComponent spawnEcsComponent = ref _entityPool.Get(entity);
                ref var prefab = ref spawnEcsComponent.Prefab;
                ref var amount = ref spawnEcsComponent.AmountOfObjects;

                for(int i = 0; i < amount; i++)
                {
                    GameObject.Instantiate(prefab).transform.position = new Vector3(Random.Range(-100, 101), Random.Range(-100, 101), Random.Range(-100, 101));
                }
            }
        }
    }
}
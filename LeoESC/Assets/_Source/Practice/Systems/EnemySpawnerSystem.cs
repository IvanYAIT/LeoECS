using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class EnemySpawnerSystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _filter;
        private EcsPool<EnemySpawnerComponent> _entityPool;

        public void Init (IEcsSystems systems) 
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EnemySpawnerComponent>().End();
            _entityPool = world.GetPool<EnemySpawnerComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref EnemySpawnerComponent enemySpawnerComponent = ref _entityPool.Get(entity);
                ref var delay = ref enemySpawnerComponent.SpawnDelay;
                ref var timer = ref enemySpawnerComponent.Timer;
                ref var transformRange = ref enemySpawnerComponent.TransformRange;
                ref var enemiesPerRound = ref enemySpawnerComponent.EnemiesPerRound;
                ref var prefab = ref enemySpawnerComponent.EnemyPrefab;

                if (timer >= delay)
                {
                    for (int i = 0; i < enemiesPerRound; i++)
                    {
                        GameObject enemy = GameObject.Instantiate(prefab);
                        enemy.transform.position = transformRange.RandomInRange();
                    }
                    timer = 0;
                }
                else
                    timer += Time.deltaTime;
            }
        }
    }
}
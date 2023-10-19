using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class EnemySystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _enemyFilter;
        private EcsFilter _playerFilter;
        private EcsPool<EnemyComponent> _enemyEntityPool;
        private EcsPool<PlayerComponent> _playerEntityPool;

        private Transform target;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _enemyFilter = world.Filter<EnemyComponent>().End();
            _playerFilter = world.Filter<PlayerComponent>().End();
            _enemyEntityPool = world.GetPool<EnemyComponent>();
            _playerEntityPool = world.GetPool<PlayerComponent>();
            foreach (var entity in _playerFilter)
            {
                ref PlayerComponent playerComponent = ref _playerEntityPool.Get(entity);
                target = playerComponent.Transform;
            }
            
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _enemyFilter)
            {
                ref EnemyComponent enemyComponent = ref _enemyEntityPool.Get(entity);
                ref var speed = ref enemyComponent.Speed;
                ref var transform = ref enemyComponent.Transform;
                ref var delay = ref enemyComponent.ShootDelay;
                ref var gun = ref enemyComponent.Gun;
                ref var timer = ref enemyComponent.Timer;

                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
                gun.transform.LookAt(target.position);

                if (timer >= delay)
                {
                    gun.GetComponent<ParticleSystem>().Play();
                    timer = 0;
                }
                else
                    timer += Time.deltaTime;

            }
        }
    }
}
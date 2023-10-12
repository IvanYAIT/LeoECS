using Leopotam.EcsLite;
using Unity.VisualScripting;
using UnityEngine;

namespace Client {
    sealed class EnemySystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _enemyFilter;
        private EcsPool<EnemyComponent> _enemyEntityPool;
        private EcsPool<PlayerComponent> _playerEntityPool;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _enemyFilter = world.Filter<EnemyComponent>().End();
            _enemyEntityPool = world.GetPool<EnemyComponent>();
            _playerEntityPool = world.GetPool<PlayerComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _enemyFilter)
            {
                ref EnemyComponent enemyComponent = ref _enemyEntityPool.Get(entity);
                ref PlayerComponent playerComponent = ref _playerEntityPool.Get(0);
                ref var speed = ref enemyComponent.Speed;
                ref var transform = ref enemyComponent.Transform;
                ref var delay = ref enemyComponent.ShootDelay;
                ref var gun = ref enemyComponent.Gun;
                ref var timer = ref enemyComponent.Timer;
                ref var target = ref playerComponent.Transform;

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
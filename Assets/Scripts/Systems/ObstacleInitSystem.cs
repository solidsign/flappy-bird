using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class ObstacleInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private Configuration _config;
        public void Init()
        {
            for (int i = 0; i < _config.ObstaclePoolSize; i++)
            {
                var entity = _world.NewEntity();
                var obstacle = Object.Instantiate(_config.ObstaclePrefab);
                entity
                    .Replace(new Obstacle
                    {
                        WholeObstacle = obstacle.transform,
                        Rigidbody2D = obstacle.GetComponent<Rigidbody2D>(),
                        BottomPipe = obstacle.BottomPipe,
                        UpperPipe = obstacle.UpperPipe
                    })
                    .Replace(new Pooled());
                obstacle.gameObject.SetActive(false);
            }
        }
    }
}
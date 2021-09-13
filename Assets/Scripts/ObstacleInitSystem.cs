using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

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
                    BottomPipe = obstacle.BottomPipe,
                    UpperPipe = obstacle.UpperPipe
                })
                .Replace(new Pooled());
            obstacle.gameObject.SetActive(false);
        }
    }
}
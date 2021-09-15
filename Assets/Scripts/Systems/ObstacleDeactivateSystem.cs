﻿using Leopotam.Ecs;
using UnityComponents;
using Components;

namespace Systems
{
    public class ObstacleDeactivateSystem : IEcsRunSystem
    {
        private EcsFilter<Obstacle>.Exclude<Pooled> _filter;
        private EcsFilter<Dead> _deadPlayer;
        private Configuration _config;
        public void Run()
        {
            if (!_deadPlayer.IsEmpty()) return;
            foreach (var i in _filter)
            {
                var obstacle = _filter.Get1(i);
                if (obstacle.WholeObstacle.position.x < _config.MINObstaclePosX)
                {
                    obstacle.WholeObstacle.gameObject.SetActive(false);
                    _filter.GetEntity(i).Replace(new Pooled());
                }
            }
        }
    }
}
﻿using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class ObstacleMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Obstacle>.Exclude<Pooled> _filter;
        private Configuration _config;
        public void Run()
        {
            var currentSpeed = _config.DefaultObstacleSpeed *
                               _config.ObstacleSpeedAnimationCurve.Evaluate(Time.timeSinceLevelLoad / _config.DifficultyChangePeriodLength);
            var displacement = currentSpeed * Time.deltaTime * Vector3.left;
            foreach (var i in _filter)
            {
                var obstacle = _filter.Get1(i);
                obstacle.Rigidbody2D.MovePosition(obstacle.WholeObstacle.position + displacement);
            }
        }
    }
}
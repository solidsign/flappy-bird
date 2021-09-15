using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class ObstacleMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Obstacle>.Exclude<Pooled> _filter;
        private EcsFilter<Dead> _deadPlayer;
        private Configuration _config;
        private Timer _timer;
        public void Run()
        {
            if (!_deadPlayer.IsEmpty()) return;
            var currentSpeed = _config.DefaultObstacleSpeed *
                               _config.ObstacleSpeedAnimationCurve.Evaluate(_timer.TimeSinceLevelStart / _config.DifficultyChangePeriodLength);
            var displacement = currentSpeed * Time.deltaTime * Vector3.left;
            foreach (var i in _filter)
            {
                var obstacle = _filter.Get1(i);
                obstacle.Rigidbody2D.MovePosition(obstacle.WholeObstacle.position + displacement);
            }
        }
    }
}
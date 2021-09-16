using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class ObstacleSpawnSystem : IEcsRunSystem
    {
        private EcsFilter<Obstacle, Pooled> _filter;
        private EcsFilter<Dead> _deadPlayer;
        private Configuration _config;
        private Timer _timer;
        private float _distanceCounter = 0f;
        private float _neededDistance = 0f;
        public void Run()
        {
            if(!_deadPlayer.IsEmpty()) return;
            if (_distanceCounter >= _neededDistance)
            {
                SpawnObstacle();
                ResetDistanceCounter();
            }
            AddDistanceToCounter();
        }

        private void AddDistanceToCounter()
        {
            var currentSpeed = _config.DefaultObstacleSpeed *
                               _config.ObstacleSpeedAnimationCurve.Evaluate(_timer.TimeSinceLevelStart /
                                                                            _config.DifficultyChangePeriodLength);
            _distanceCounter += currentSpeed * Time.deltaTime;
        }

        private void ResetDistanceCounter()
        {
            _distanceCounter = 0f;
            _neededDistance =
                _config.DistanceBetweenObstaclesAnimationCurve.Evaluate(_timer.TimeSinceLevelStart /
                                                                        _config.DifficultyChangePeriodLength) +
                Random.Range(-_config.DistanceBetweenObstaclesSpreading, _config.DistanceBetweenObstaclesSpreading);
        }

        private void SpawnObstacle()
        {
            var obstacle = _filter.Get1(0);
            var gapSize = _config.GapSizeAnimationCurve.Evaluate(_timer.TimeSinceLevelStart / _config.DifficultyChangePeriodLength) +
                          Random.Range(-_config.GapSpreading, _config.GapSpreading);
            var gapY = Random.Range(_config.MINGapY + gapSize / 2, _config.MAXGapY - gapSize / 2);
        
            obstacle.WholeObstacle.position = new Vector3(_config.SpawnX, gapY, 0);
            obstacle.BottomPipe.localPosition = new Vector3(0, -gapSize / 2f, 0);
            obstacle.UpperPipe.localPosition = new Vector3(0, gapSize / 2f, 0);
            obstacle.WholeObstacle.gameObject.SetActive(true);
            var entity = _filter.GetEntity(0);
            entity.Del<Pooled>();
            entity.Del<Counted>();
        }
    }
}
using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class ObstacleSpawnSystem : IEcsRunSystem
    {
        private EcsFilter<Obstacle, Pooled> _filter;
        private Configuration _config;
        private float _timer = 0f;
        private float _spawnTime = 0f;
        public void Run()
        {
            if (_timer >= _spawnTime)
            {
                ResetTimer();
                SpawnObstacle();
            }
        
            _timer += Time.deltaTime;
        }

        private void SpawnObstacle()
        {
            var obstacle = _filter.Get1(0);
            var gapSize = _config.GapSizeAnimationCurve.Evaluate(Time.timeSinceLevelLoad / _config.DifficultyChangePeriodLength) +
                          Random.Range(-_config.GapSpreading, _config.GapSpreading);
            var gapY = Random.Range(_config.MINGapY + gapSize / 2, _config.MAXGapY - gapSize / 2);
        
            obstacle.WholeObstacle.position = new Vector3(_config.SpawnX, gapY, 0);
            obstacle.BottomPipe.localPosition = new Vector3(0, -gapSize / 2f, 0);
            obstacle.UpperPipe.localPosition = new Vector3(0, gapSize / 2f, 0);
            obstacle.WholeObstacle.gameObject.SetActive(true);
            _filter.GetEntity(0).Del<Pooled>();
        }

        private void ResetTimer()
        {
            _timer = 0f;
            _spawnTime = _config.TimeBetweenObstaclesAnimationCurve.Evaluate(Time.timeSinceLevelLoad / _config.DifficultyChangePeriodLength) +
                         Random.Range(-_config.TimeBetweenObstaclesSpreading, _config.TimeBetweenObstaclesSpreading);
        }
    }
}
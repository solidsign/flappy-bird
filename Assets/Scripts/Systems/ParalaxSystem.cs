using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class ParalaxSystem : IEcsRunSystem
    {
        private Timer _timer;
        private Configuration _config;
        private EcsFilter<ParalaxObject> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var paralax = ref _filter.Get1(i);
                var k = _config.ObstacleSpeedAnimationCurve.Evaluate(_timer.TimeSinceLevelStart /
                                                                     _config.DifficultyChangePeriodLength);
                var dX = paralax.Settings.StartSpeed * k * Time.deltaTime;
                var fullDeltaX = Mathf.Abs(paralax.Obj1.position.x - paralax.Settings.StartX1);
                fullDeltaX = (fullDeltaX + dX) % paralax.Settings.TranslationLength;
                var pos = paralax.Obj1.position;
                pos.x = paralax.Settings.StartX1 - fullDeltaX;
                paralax.Obj1.position = pos;
                pos.x = paralax.Settings.StartX2 - fullDeltaX;
                paralax.Obj2.position = pos;
            }
        }
    }
}
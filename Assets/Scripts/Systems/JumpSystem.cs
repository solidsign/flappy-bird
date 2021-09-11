using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class JumpSystem : IEcsRunSystem
    {
        private EcsFilter<Movable, JumpEvent> _filter;
        private Configuration _config;

        private float _timer;
        private float _lastHeight;
        private float _currentHeight;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var jumpEvent = ref _filter.Get2(i);
                if (jumpEvent.JustCalled)
                {
                    jumpEvent.JustCalled = false;
                    _timer = 0f;
                }

                ref var mov = ref _filter.Get1(i);

                _currentHeight = _config.JumpHeight * _config.JumpAnimationCurve.Evaluate(_timer / _config.JumpTime);
            
                mov.Displacement = new Vector3(0, _currentHeight - _lastHeight, 0);

                _lastHeight = _currentHeight;
                _timer += Time.deltaTime;
            
                if (_timer > _config.JumpTime)
                {
                    _filter.GetEntity(i).Del<JumpEvent>();
                }
            }
        }
    }
}
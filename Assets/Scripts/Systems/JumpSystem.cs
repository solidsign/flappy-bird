using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class JumpSystem : IEcsRunSystem
    {
        private EcsFilter<Movable, JumpEvent> _filter;
        private Configuration _config;

        private float _timer = 0f;
        private float _lastHeight = 0f;
        private float _currentHeight = 0f;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var jumpEvent = ref _filter.Get2(i);
                if (jumpEvent.JustCalled)
                {
                    _currentHeight = 0f;
                    _lastHeight = 0f;
                    _timer = 0f;
                    jumpEvent.JustCalled = false;
                }

                ref var mov = ref _filter.Get1(i);

                _currentHeight = _config.JumpHeight * _config.JumpAnimationCurve.Evaluate(_timer / _config.JumpTime);
            
                mov.Displacement = new Vector3(0, _currentHeight - _lastHeight, 0);

                _lastHeight = _currentHeight;
                _timer += Time.deltaTime;
            
                if (_timer > _config.JumpTime)
                {
                    _currentHeight = 0f;
                    _lastHeight = 0f;
                    _timer = 0f;
                    _filter.GetEntity(i).Del<JumpEvent>();
                }
            }
        }
    }
}
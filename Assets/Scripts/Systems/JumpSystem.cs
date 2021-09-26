using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class JumpSystem : IEcsRunSystem
    {
        private EcsFilter<Movable, Player>.Exclude<Dead> _filter;
        private EcsFilter<JumpInputEvent> _jump;
        private Configuration _config;
        private Animator _playerAnimator;

        private static readonly int Jump = Animator.StringToHash("_jump");
        private float _timer = 0f;
        private float _lastHeight = 0f;
        private float _currentHeight = 0f;
        public void Run()
        {
            foreach (var i in _filter)
            {
                if(!_jump.IsEmpty())
                {
                    _currentHeight = 0f;
                    _lastHeight = 0f;
                    _timer = 0f;
                    _filter.GetEntity(i).Replace(new Jumping()).Replace(new JumpSound());
                    _playerAnimator.SetTrigger(Jump);
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
                    _filter.GetEntity(i).Del<Jumping>();
                }
            }
        }
    }
}
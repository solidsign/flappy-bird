using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerJumpSystem : IEcsRunSystem
    {
        private EcsFilter<Player> _filter = null;
        private Configuration _config;
        
        private float _jumpTimer = 0f;
        private float _currentHeight = 0f;
        private float _lastHeight = 0f;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var player = ref _filter.Get1(i);
                if (player.PlayerState == PlayerState.Jumped)
                {
                    player.PlayerState = PlayerState.Jumping;
                    _jumpTimer = 0f;
                }

                if (player.PlayerState == PlayerState.Jumping)
                {
                    HandleJump(player);
                }

                if (_jumpTimer >= _config.JumpTime)
                {
                    player.PlayerState = PlayerState.Falling;
                }
            }
        }
        private void HandleJump(Player player)
        {
            _currentHeight = _config.JumpAnimationCurve.Evaluate(_jumpTimer / _config.JumpTime) * _config.JumpHeight;
            player.Rigidbody2D.MovePosition(player.Rigidbody2D.transform.position +
                                            Vector3.up * (_currentHeight - _lastHeight));
            _lastHeight = _currentHeight;
            _jumpTimer += Time.deltaTime;
        }
    }
}
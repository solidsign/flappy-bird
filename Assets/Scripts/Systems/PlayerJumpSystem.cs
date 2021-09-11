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
                CheckForNewJump(ref player);
                HandleJump(ref player);
                CheckJumpEnd(ref player);
            }

        }

        private void CheckForNewJump(ref Player player)
        {
            if (player.PlayerState != PlayerState.Jumped) return;
            player.PlayerState = PlayerState.Jumping;
            _jumpTimer = 0f;
        }

        private void CheckJumpEnd(ref Player player)
        {
            if (!(_jumpTimer >= _config.JumpTime)) return;
            player.PlayerState = PlayerState.Falling;
        }

        private void HandleJump(ref Player player)
        {
            if (player.PlayerState != PlayerState.Jumping) return;
            _currentHeight = _config.JumpAnimationCurve.Evaluate(_jumpTimer / _config.JumpTime) * _config.JumpHeight;
            player.Rigidbody2D.MovePosition(player.Transform.position + Vector3.up * (_currentHeight - _lastHeight));
            _lastHeight = _currentHeight;
            _jumpTimer += Time.deltaTime;
        }
    }
}
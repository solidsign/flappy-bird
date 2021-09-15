using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            _world.NewEntity().Replace(new JumpInputEvent());
        }
    }
}
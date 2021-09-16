using Components;
using Leopotam.Ecs;
using Services;

namespace Systems
{
    public class GameOverSystem : IEcsRunSystem
    {
        private EcsFilter<Dead> _dead;
        private EcsFilter<JumpInputEvent> _playerInput;
        private EcsWorld _world;
        private UI _ui;
        public void Run()
        {
            if (_dead.IsEmpty()) return;
        
            if (!_ui.UIDrawn)
            {
                _ui.ShowLoseScreen();
                _world.NewEntity().Replace(new LoseSound());
            }

            if (_playerInput.IsEmpty()) return;
            _world.NewEntity().Replace(new RestartEvent());
        }
    }
}
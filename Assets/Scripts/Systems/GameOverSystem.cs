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
            }

            if (_playerInput.IsEmpty()) return;
            
            var restart = _world.NewEntity();
            restart.Replace(new RestartEvent());
        }
    }
}
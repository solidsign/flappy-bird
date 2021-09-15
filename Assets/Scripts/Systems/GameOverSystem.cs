using Components;
using Leopotam.Ecs;
using Services;

namespace Systems
{
    public class GameOverSystem : IEcsRunSystem
    {
        private EcsFilter<Dead> _filter;
        private EcsFilter<JumpEvent> _playerInput;
        private EcsWorld _world;
        private UI _ui;
        public void Run()
        {
            if (_filter.IsEmpty()) return;
        
            if (!_ui.UIDrawn)
            {
                _ui.ShowLoseScreen();
            }

            foreach (var i in _playerInput)
            {
                ref var jumpEvent = ref _playerInput.Get1(i);
                if (jumpEvent.JustCalled)
                {
                    var restart = _world.NewEntity();
                    restart.Replace(new RestartEvent());
                    jumpEvent.JustCalled = false;
                }
            }
        }
    }
}
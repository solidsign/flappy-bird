using Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSystem : IEcsRunSystem
{
    private EcsFilter<Dead> _filter;
    private EcsFilter<JumpEvent> _playerInput;
    private UI _ui;
    private bool _uiDrawn = false;
    public void Run()
    {
        if (_filter.IsEmpty()) return;
        
        if (!_uiDrawn)
        {
            _ui.ShowLoseScreen();
            _uiDrawn = true;
        }

        foreach (var i in _playerInput)
        {
            if (_playerInput.Get1(i).JustCalled)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
        }
    }
}
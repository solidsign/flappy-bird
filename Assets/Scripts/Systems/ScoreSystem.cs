using Components;
using Leopotam.Ecs;
using Services;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class ScoreSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<Obstacle>.Exclude<Counted> _obstacles;
        private EcsFilter<RestartEvent> _restart;
        private Configuration _config;
        private ScoreUI _ui;
        
        private int _score = 0;
        private int _highscore;
        
        public void Run()
        {
            foreach (var i in _obstacles)
            {
                if (_obstacles.Get1(i).WholeObstacle.position.x < _config.StartPlayerPosition.x)
                {
                    bool newHighscore = AdjustScore();
                    var obstacle = _obstacles.GetEntity(i);
                    if (newHighscore)
                    {
                        obstacle
                            .Replace(new Counted())
                            .Replace(new HighscoreSound());
                    }
                    else
                    {
                        obstacle
                            .Replace(new Counted())
                            .Replace(new ScoreSound());
                    }
                }
            }

            if (!_restart.IsEmpty())
            {
                ResetScore();
            }
        }

        private bool AdjustScore()
        {
            ++_score;
            _ui.ScoreText = _score;
            if (_highscore >= _score) return false;
            _highscore = _score;
            _ui.HighscoreText = _score;
            return true;
        }

        private void ResetScore()
        {
            _score = 0;
            _ui.ScoreText = _score;
        }

        public void Init()
        {
            _highscore = PlayerPrefs.GetInt("_highscore", 0);
            _ui.HighscoreText = _highscore;
        }
    }

}
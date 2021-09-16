using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    [System.Serializable]
    public class ScoreUI
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text highscoreText;
        public int ScoreText
        {
            set => scoreText.text = value.ToString();
        }
        public int HighscoreText
        {
            set => highscoreText.text = value.ToString();
        }
    }
}
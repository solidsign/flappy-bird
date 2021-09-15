using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    [System.Serializable]
    public class UI
    {
        [SerializeField] private GameObject loseScreen;
        [SerializeField] private Text scoreText;
        public bool UIDrawn { get; private set; } = false;

        public int ScoreText
        {
            set => scoreText.text = value.ToString();
        }

        public void ShowLoseScreen()
        {
            loseScreen.SetActive(true);
            UIDrawn = true;
        }

        public void HideLoseScreen()
        {
            UIDrawn = false;
            loseScreen.SetActive(false);
        }
    }
}
using UnityEngine;

namespace Services
{
    [System.Serializable]
    public class UI
    {
        [SerializeField] private GameObject loseScreen;
        
        public bool UIDrawn { get; private set; } = false;

        

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
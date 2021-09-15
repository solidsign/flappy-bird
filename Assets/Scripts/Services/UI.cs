using UnityEngine;

[System.Serializable]
public class UI
{
    [SerializeField] private GameObject loseScreen;
    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
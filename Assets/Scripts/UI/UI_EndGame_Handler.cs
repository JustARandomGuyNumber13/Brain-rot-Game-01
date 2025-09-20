using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame_Handler : MonoBehaviour
{
    [SerializeField] TMP_Text resultText;
    [SerializeField] Button nextLevelButton;
    [SerializeField] Button resetLevelButton;

    [SerializeField] string[] gameWinTexts;
    [SerializeField] string[] gameLostTexts;

    Game_Manager manager;

    private void Start()
    {
        manager = Game_Manager.instance;

        manager.OnGameEnd.AddListener(WinResult);
        manager.OnGameLost.AddListener(LoseResult);

        nextLevelButton.onClick.AddListener(manager.NextLevel);
        resetLevelButton.onClick.AddListener(manager.ResetLevel);
    }
    void LoseResult()
    {
        resultText.SetText(GetLooseText());
        resultText.gameObject.SetActive(true);
        resetLevelButton.gameObject.SetActive(true);
    }
    string GetLooseText()
    {
        if (gameLostTexts.Length <= 0) return "Too bad :(";
        return gameLostTexts[Random.Range(0, gameLostTexts.Length)];
    }
    void WinResult()
    {
        resultText.SetText(GetWinText());
        resultText.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
    }
    string GetWinText()
    {
        if (gameWinTexts.Length <= 0) return "You got it!";
        return gameWinTexts[Random.Range(0, gameWinTexts.Length)];
    }
}

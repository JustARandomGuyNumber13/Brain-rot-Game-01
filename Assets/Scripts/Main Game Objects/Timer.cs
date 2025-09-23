using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private float levelDuration;
    private Game_Manager manager;

    private void Start()
    {
        manager = Game_Manager.instance;
        UpdateTimerText();
        enabled = false;
    }

    private void Update()
    {
        if (levelDuration <= 0)
        {
            levelDuration = 0;
            UpdateTimerText();
            manager.LooseGame();
            enabled = false;
            return;
        }

        levelDuration -= Time.deltaTime;
        UpdateTimerText();
    }

    public void UpdateTimerText()
    {
        int seconds = Mathf.FloorToInt(levelDuration);
        int milliseconds = Mathf.FloorToInt((levelDuration * 100) % 100);

        timer.text = string.Format("{0:D2}:{1:D2}", seconds, milliseconds);
    }
}
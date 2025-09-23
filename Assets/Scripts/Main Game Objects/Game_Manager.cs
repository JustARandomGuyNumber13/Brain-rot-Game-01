using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public Camera cam;
    public bool GameStart { get; set; }

    public UnityEvent OnGameStart;
    public UnityEvent OnGameEnd;
    public UnityEvent OnGameLost;

    public float Height { get; set; }
    public float Width { get; set; }

    private void Awake()
    {
        instance = this;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        Height = cam.orthographicSize * 2f;
        Width = cam.orthographicSize * 2f * cam.aspect;
    }

    private void Start()
    {
        enabled = false;
    }

    public void EndGame()
    {
        OnGameEnd?.Invoke();
        Time.timeScale = 0;
        Data_Manager.instance.NextLevel();
    }
    public void StartGame()
    {
        if (!GameStart)
        {
            GameStart = true;
            OnGameStart?.Invoke();
        }
    }
    public void LooseGame()
    { 
        OnGameLost?.Invoke();
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        Time.timeScale = 1.0f;
        int curScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = curScene + 1;        

        if (nextScene < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextScene);
        else
            SceneManager.LoadScene(0);
    }
    public void ResetLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

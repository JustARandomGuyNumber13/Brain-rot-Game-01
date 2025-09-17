using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    [SerializeField] ViewportHandler viewportHandler;

    public SO_GameInfo Info;
    public Camera cam;

    public UnityEvent OnGameEnd;

    public float Height { get; set; }
    public float Width { get; set; }

    private void Awake()
    {
        instance = this;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        Height = cam.orthographicSize * 2f;
        Width = cam.orthographicSize * 2f * cam.aspect;

        viewportHandler.UnitsSize = Info.LevelSize;
    }

    private void Start()
    {
        enabled = false;
    }
    public void ResetLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        OnGameEnd?.Invoke();
        Time.timeScale = 0;
    }

    void NextLevel()
    {
        Info.Level++;
        
        if(Info.LevelSize < Info.LevelMaxSize)
            Info.LevelSize += Info.LevelSizeIncrease;
    }
}

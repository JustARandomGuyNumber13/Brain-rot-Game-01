using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data_Manager : MonoBehaviour
{
    [SerializeField] ProjectileData[] projectiles;
    public static Data_Manager instance;
    
    GameData gameData;
    Dictionary<string, Projectile> projectileList = new();

    private void Awake()
    {
        SetUpManager();
        SetUpProjectileList();
        LoadScene();
    }
    public GameData GetGameData()
    { return gameData; }
    public Projectile GetCurrentProjectile() 
    { return projectileList[gameData.CurrentProjectile]; }
    public void NextLevel()
    { 
        gameData.CurrentLevel++;
        Data.SaveData(gameData);
    }

    void SetUpManager()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        gameData = Data.LoadData();

        if (gameData == null)
            gameData = new GameData(projectiles[0].ID);
    }
    void SetUpProjectileList()
    {
        foreach (var projectile in projectiles)
        {
            projectileList.Add(projectile.ID, projectile.Prefab);
        }
    }
    void LoadScene()
    {
        if (gameData == null) return;
        SceneManager.LoadScene(gameData.CurrentLevel);
    }
}

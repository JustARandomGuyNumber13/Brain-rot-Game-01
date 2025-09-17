using UnityEngine;

public class Goal_Spawner : MonoBehaviour
{
    Game_Manager manager;

    void Start()
    {
        manager = Game_Manager.instance;

        float yPercentage = Random.Range(0, 50);
        float xPercentage = Random.Range(-45, 45);

        float xPos = manager.Width * (xPercentage / 100);
        float yPos = manager.Height * (yPercentage / 100);

        transform.position = new Vector2 (xPos, yPos);

        Destroy(this);
    }
}

using UnityEngine;

public class Goal : MonoBehaviour
{

    private void Start()
    {
        enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Game_Manager.instance.EndGame();
    }
}

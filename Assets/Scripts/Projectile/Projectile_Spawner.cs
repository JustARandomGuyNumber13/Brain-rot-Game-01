using System.Collections.Generic;
using UnityEngine;

public class Projectile_Spawner : MonoBehaviour
{
    public static Projectile_Spawner instance;
    [SerializeField] Transform target;

    Queue<Projectile> pool = new Queue<Projectile>();
    Game_Manager manager;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        manager = Game_Manager.instance;
        enabled = false;
    }

    public void SpawnProjectile(Vector3 spawnPos)
    {
        Projectile projectile;

        if (pool.Count > 0)
            projectile = pool.Dequeue();
        else
            projectile = Instantiate(manager.Info.CurrentProjectile);

        projectile.target = target;
        projectile.transform.position = spawnPos;
        projectile.gameObject.SetActive(true);

    }
    public void DestroyProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        pool.Enqueue(projectile);
    }
}

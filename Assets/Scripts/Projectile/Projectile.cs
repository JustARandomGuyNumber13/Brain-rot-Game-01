using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    protected Projectile_Spawner spawner;
    public Transform target;
    protected Rigidbody2D rb;

    protected void Awake()
    {
        TryGetComponent(out rb);
    }
    protected virtual void Start()
    {
        spawner = Projectile_Spawner.instance;
    }
    protected virtual void OnEnable()
    {
        Launch();
    }

    public virtual void Launch() { }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
            spawner.DestroyProjectile(this);
    }
}

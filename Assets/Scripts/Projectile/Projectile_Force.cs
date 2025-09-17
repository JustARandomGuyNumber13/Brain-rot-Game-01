using UnityEngine;

public class Projectile_Force : Projectile
{
    public float launchForce;

    public override void Launch()
    {
        Vector2 launchDirection = (target.position - transform.position).normalized;
        rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
    }
}

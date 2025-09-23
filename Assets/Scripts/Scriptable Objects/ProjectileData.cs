using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Scriptable Objects/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public string ID;
    public int Cost;
    public bool Unlock;
    public Projectile Prefab;
}

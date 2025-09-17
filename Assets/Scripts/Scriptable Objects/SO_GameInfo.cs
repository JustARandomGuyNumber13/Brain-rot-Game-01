using UnityEngine;

[CreateAssetMenu(fileName = "SO_GameInfo", menuName = "Scriptable Objects/SO_GameInfo")]
public class SO_GameInfo : ScriptableObject
{
    public int Level;
    public Projectile CurrentProjectile;

    [Header("Level Size")]
    public float LevelMaxSize;
    public float LevelSizeIncrease;
    public float LevelSize;


    public float TapAreaPercentage;
    public Vector3 GoalPosition;

    private void OnEnable()
    {
           
    }
}

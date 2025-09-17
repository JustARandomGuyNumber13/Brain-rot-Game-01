using UnityEngine;

public class EnvironmentScaler : MonoBehaviour
{
    [SerializeField] ScaleItem[] scaleList;
    Game_Manager manager;

    private void Start()
    {
        manager = Game_Manager.instance;

        foreach (var item in scaleList)
        {
            Horizontal(item);
            Vertical(item);
        }

        Destroy(this.gameObject);
    }

    void Horizontal(ScaleItem item)
    {
        float spriteWorldWidth = item.sprite.sprite.bounds.size.x;
        float scaleFactor = (manager.Width / spriteWorldWidth);
        float percentage;
        Transform t = item.sprite.transform;

        if (item.hPercentage != 0)
        {
            percentage = item.hPercentage / 100;
            item.sprite.transform.localScale = new Vector3(scaleFactor * percentage, item.sprite.transform.localScale.y, 1f);
        }

        if (item.HorizontalPositionPercentage != 0)
        {
            percentage = item.HorizontalPositionPercentage / 100;
            t.position = new Vector3(scaleFactor * percentage, t.position.y, t.position.z);
        }
    }
    void Vertical(ScaleItem item)
    {
        float spriteWorldHeight = item.sprite.sprite.bounds.size.y;
        float scaleFactor = manager.Height / spriteWorldHeight;
        float percentage;
        Transform t = item.sprite.transform;

        if (item.vPercentage != 0)
        {
            percentage = (item.vPercentage / 100);
            t.localScale = new Vector3(item.sprite.transform.localScale.x, scaleFactor * percentage, 1f);
        }

        if (item.VerticalPositionPercentage != 0)
        {
            percentage = item.VerticalPositionPercentage / 100;
            t.position = new Vector3(t.position.x, scaleFactor * percentage, t.position.z);
        } 
    }


    [System.Serializable]
    public struct ScaleItem
    { 
        public SpriteRenderer sprite;
        [Range(0, 100)] public float hPercentage;
        [Range(0, 200)] public float vPercentage;
        [Range(-50, 50)] public float VerticalPositionPercentage;
        [Range(-50, 50)] public float HorizontalPositionPercentage;
    }
}

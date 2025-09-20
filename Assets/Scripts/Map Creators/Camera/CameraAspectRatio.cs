using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    [SerializeField] Vector2 AspectRatio;
    Camera cam;
    Rect rect;

    private void Start()
    {
        TryGetComponent(out cam);
        rect = cam.rect;
        Adjust();
    }
    void Update()
    {
        Adjust();
    }

    public void Adjust()
    {
        float targetaspect = AspectRatio.x / AspectRatio.y;

        float windowaspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = windowaspect / targetaspect;

        if (scaleheight < 1.0f)
        {

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            cam.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = cam.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;
        }

    }
}
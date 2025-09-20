using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScaleEnvironment : MonoBehaviour
{
    Camera cam;
    [SerializeField] GameObject InvisibleGround;

    [SerializeField] GameObject CornerTopLeft;
    [SerializeField] GameObject CornerTopRight;

    [SerializeField] GameObject LeftWall;
    [SerializeField] GameObject RightWall;
    [SerializeField] GameObject TopWall;
    [SerializeField] GameObject BotDestroyer;

    public void Scale()
    {
        cam = Camera.main;
        ScaleWall();
        ScaleCorner();
        ScaleGround();
    }

    void ScaleWall()
    {
        float cameraHeight = cam.orthographicSize * 2f;
        float cameraWidth = cameraHeight * cam.aspect;

        LeftWall.transform.position = new Vector2((-cameraWidth / 2f) - 0.5f, 0);
        RightWall.transform.position = new Vector2((cameraWidth / 2f) + 0.5f, 0);
        TopWall.transform.position = new Vector2(0, (cameraHeight / 2f) + 0.5f);
        BotDestroyer.transform.position = new Vector2(0, (-cameraHeight / 2f) - 1.5f);

        LeftWall.transform.localScale = new Vector2(LeftWall.transform.localScale.x, cameraHeight);
        RightWall.transform.localScale = new Vector2(RightWall.transform.localScale.x, cameraHeight);
        TopWall.transform.localScale = new Vector2(cameraWidth, TopWall.transform.localScale.y);
        BotDestroyer.transform.localScale = new Vector2(cameraWidth, BotDestroyer.transform.localScale.y);
    }

    void ScaleCorner()
    {
        float cameraHeight = cam.orthographicSize * 2f;
        float cameraWidth = cameraHeight * cam.aspect;

        CornerTopLeft.transform.position = new Vector2(-cameraWidth / 2f, cameraHeight / 2f);
        CornerTopRight.transform.position = new Vector2(cameraWidth / 2f, cameraHeight / 2f);
    }

    void ScaleGround()
    {
        float cameraHeight = cam.orthographicSize * 2f;
        float cameraWidth = cameraHeight * cam.aspect;

        InvisibleGround.transform.localScale = new Vector2(cameraWidth, InvisibleGround.transform.localScale.y);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ScaleEnvironment))]
public class ScaleEnvironmentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ScaleEnvironment myScript = (ScaleEnvironment)target;

        if (GUILayout.Button("Scale Environment"))
        {
            myScript.Scale();
        }
    }
}
#endif
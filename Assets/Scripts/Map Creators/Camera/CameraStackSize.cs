using UnityEngine;

public class CameraStackSize : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera[] stackCameras;

    private void Start()
    {
        if (stackCameras.Length == 0) return;

        foreach (var cam in stackCameras)
        {
            cam.orthographicSize = mainCamera.orthographicSize;
        }
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UITapToWorldSpace : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Camera mainCamera;
    public UnityEvent<Vector3> OnPlayAreaTap;


    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 tapPosition = eventData.position;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(tapPosition.x, tapPosition.y, mainCamera.nearClipPlane));
        OnPlayAreaTap.Invoke(worldPosition);
    }
}
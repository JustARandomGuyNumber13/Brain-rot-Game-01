using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UITapToWorldSpace : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Camera mainCamera;
    public UnityEvent<Vector3> OnPlayAreaTap;
    Game_Manager manager;

    private void Start()
    {
        manager = Game_Manager.instance;
        manager.OnGameEnd.AddListener(OnEndGame);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        manager.StartGame();
        Vector2 tapPosition = eventData.position;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(tapPosition.x, tapPosition.y, mainCamera.nearClipPlane));
        OnPlayAreaTap.Invoke(worldPosition);
    }

    void OnEndGame()
    {
        enabled = false;
    }
}
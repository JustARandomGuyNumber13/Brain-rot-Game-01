using UnityEngine;

public class UI_EnvironmentScaler : MonoBehaviour
{
    [SerializeField] SO_GameInfo gameInfo;
    [SerializeField] RectTransform background;
    [SerializeField] RectTransform tapArea;

    private void Start()
    {
        UpdateTapArea();
        enabled = false;
    }

    public void UpdateTapArea()
    {
        // Set tap area size
        tapArea.sizeDelta = new Vector2(tapArea.sizeDelta.x, background.sizeDelta.y * (gameInfo.TapAreaPercentage / 100));

        // Set tap area position
        tapArea.anchoredPosition = new Vector2(tapArea.position.x, tapArea.sizeDelta.y / 2);
    }
}

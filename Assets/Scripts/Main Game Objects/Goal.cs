using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] float RotateSpeed;
    [SerializeField] Color[] colorTransition;
    [SerializeField] float colorTransitionSpeed;
    SpriteRenderer spr;

    private int currentColorIndex = 0;
    private int nextColorIndex = 1;
    private float lerpTime = 0f;

    private void Awake()
    {
        TryGetComponent(out spr);
    }

    private void Start()
    {
        if (colorTransition.Length < 2)
        {
            enabled = false;
            return;
        }

        spr.color = colorTransition[currentColorIndex];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Game_Manager.instance.EndGame();
    }

    private void Update()
    {
        Spin();
        ShiftColor();
    }

    void Spin()
    {
        transform.Rotate(Vector3.forward, RotateSpeed * Time.unscaledDeltaTime);
    }

    void ShiftColor()
    {
        lerpTime += Time.unscaledDeltaTime * colorTransitionSpeed;
        spr.color = Color.Lerp(colorTransition[currentColorIndex], colorTransition[nextColorIndex], lerpTime);

        if (lerpTime >= 1.0f)
        {
            lerpTime = 0f;
            currentColorIndex = (currentColorIndex + 1) % colorTransition.Length;
            nextColorIndex = (nextColorIndex + 1) % colorTransition.Length;
        }
    }
}
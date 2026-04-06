using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class BackgroundScaler : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            AdjustBackgroundSize();
        }
    }

    void AdjustBackgroundSize()
    {
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}

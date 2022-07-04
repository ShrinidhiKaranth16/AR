using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform rectTransform;
    Rect safeArea;
    Vector2 minAnc, maxAnc;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;
        minAnc = safeArea.position;
        maxAnc = minAnc + safeArea.size;

        minAnc.x /= Screen.width;
        minAnc.y /= Screen.height;

        maxAnc.x /= Screen.width;
        maxAnc.y /= Screen.height;

        rectTransform.anchorMin = minAnc;
        rectTransform.anchorMax = maxAnc;
    }
}

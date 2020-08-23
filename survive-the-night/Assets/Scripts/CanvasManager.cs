using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private Rect m_canvasRect;
    public static CanvasManager Instance { get; private set; }

    void Start()
    {
        Instance = this;        
        m_canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>().rect;
    }

    public Vector2 WorldToCanvasPoint(Vector3 a_position)
    {

        Vector2 viewport = Camera.main.WorldToViewportPoint(a_position);
        return Vector2.right * (viewport.x - 0.5f) * m_canvasRect.width + Vector2.up * (viewport.y - 0.5f) * m_canvasRect.height;
    }
}

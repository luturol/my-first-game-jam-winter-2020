using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    private Transform m_objectToFollow;
    private RectTransform m_rect;

    void Start()
    {
        m_rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        this.m_rect.anchoredPosition = CanvasManager.Instance.WorldToCanvasPoint(m_objectToFollow.position);
    }

    public void SetFollowingObject(Transform toFollow)
    {
        this.m_objectToFollow = toFollow;
    }
}

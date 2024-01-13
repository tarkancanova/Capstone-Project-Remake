using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Vector3 _rectTransformValue;

    private void Awake()
    {
        _rectTransform = GetComponentInChildren<RectTransform>();
        _rectTransformValue = _rectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        _rectTransform.localPosition = _rectTransformValue;
    }
}

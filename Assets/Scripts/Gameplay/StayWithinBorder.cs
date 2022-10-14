using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithinBorder : MonoBehaviour
{
    private Camera _camera;
    private Vector3 viewportPosition;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void OnBecameInvisible()
    {
        viewportPosition = _camera.WorldToViewportPoint(transform.position);
        Vector3 newPosition = transform.position;

        if (viewportPosition.x > 1 || viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x;
        }

        if (viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y;
        }

        transform.position = newPosition;
    }
}

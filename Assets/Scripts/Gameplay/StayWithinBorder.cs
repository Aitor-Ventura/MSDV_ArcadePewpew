using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithinBorder : MonoBehaviour
{
    [SerializeField] private GameObject _trailRenderer;
    
    private Camera _camera;
    private Vector3 viewportPosition;

    private float cooldown;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        cooldown = 0;
    }

    private void Update()
    {
        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
            SetActiveTrailRenderer(_trailRenderer, false);
            return;
        }
        SetActiveTrailRenderer(_trailRenderer, true);
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

        if (_trailRenderer != null)
        {
            cooldown = _trailRenderer.GetComponentInChildren<TrailRenderer>().time;
        }
        transform.position = newPosition;
    }

    private void SetActiveTrailRenderer(GameObject trailRenderer, bool activate)
    {
        if (trailRenderer != null)
        {
            trailRenderer.SetActive(activate);
        }
    }
}

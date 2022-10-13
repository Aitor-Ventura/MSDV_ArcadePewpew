using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    private SpriteRenderer _spriteRenderer;
    private PolygonCollider2D _collider;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        UpdateText.health = healthPoints;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        healthPoints -= 1;
        _collider.enabled = false;
        _spriteRenderer.DOFade(0, 0.3f).SetLoops(4, LoopType.Yoyo).OnComplete(() => _collider.enabled = true);
    }
}

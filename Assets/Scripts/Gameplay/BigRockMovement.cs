using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BigRockMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float time;
    [SerializeField] private float impulseForce;
    [SerializeField] private float timeBetweenPush;
    private GameObject player;
    [SerializeField] private float maxSpeed;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        transform.up = player.transform.position - transform.position;
        _rigidbody.AddForce(transform.up * impulseForce, ForceMode2D.Force);
    }
    
    private void Update()
    {
        if (player == null) return;
        time += Time.deltaTime;
        transform.up = player.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (time >= timeBetweenPush && _rigidbody.velocity.sqrMagnitude <= maxSpeed)
        {
            time = 0f;
            _rigidbody.AddForce(transform.up * impulseForce);
        }
    }
}

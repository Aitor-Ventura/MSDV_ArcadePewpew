using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float turnValue;
    [SerializeField] private float force;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotation;
    
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        turnValue = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _rigidbody.rotation += rotation * -turnValue;
        if (!Input.GetKey(KeyCode.W)) return;
        if (_rigidbody.velocity.sqrMagnitude <= maxSpeed)
        {
            _rigidbody.AddForce(transform.up * this.force, ForceMode2D.Force);
        }
    }
}
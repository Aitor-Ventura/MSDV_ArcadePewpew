using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    [Tooltip("Force used for movement purposes.")]
    [SerializeField] private float force;
    [Tooltip("How fast can the player move.")]
    [SerializeField] private float maxSpeed;
    [Tooltip("How quick can the player turn.")]
    [SerializeField] private float rotation;
    
    private Rigidbody2D _rigidbody;
    private float turnValue;

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

    public void OnValidate()
    {
        if (force < 0)
        {
            force = 0;
            Debug.LogWarning("Force cannot be negative. Set to 0.", this);
        }

        if (maxSpeed < 0)
        {
            maxSpeed = 0;
            Debug.LogWarning("Speed cannot be negative. Set to 0.", this);
        }
        
        if (rotation < 0)
        {
            rotation = 0;
            Debug.LogWarning("Rotation speed cannot be negative. Set to 0.", this);
        }
    }
}
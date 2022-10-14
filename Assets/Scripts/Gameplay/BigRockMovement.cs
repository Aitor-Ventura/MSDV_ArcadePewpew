using UnityEngine;

public class BigRockMovement : MonoBehaviour
{
    [Header("Variables")]
    [Tooltip("The force used for the impulse of the rock. Used for following the player.")]
    [SerializeField] private float impulseForce;
    [Tooltip("The time, in seconds, to wait before the next impulse of the rock.")]
    [SerializeField] private float timeBetweenPush;
    [Tooltip("The maximum speed at which the rock can move.")]
    [SerializeField] private float maxSpeed;
    
    private Rigidbody2D _rigidbody;
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(ApplyForce), 0, timeBetweenPush);
    }
    
    private void Update()
    {
        if (player == null) return;
        transform.up = player.transform.position - transform.position;
    }

    private void ApplyForce()
    {
        if (_rigidbody.velocity.sqrMagnitude <= maxSpeed)
        { 
            _rigidbody.AddForce(transform.up * impulseForce);
        }
    }

    public void OnValidate()
    {
        if (impulseForce < 0)
        {
            impulseForce = 0;
            Debug.LogWarning("The impulse force cannot be negative. Set to 0.", this);
        }
        
        if (timeBetweenPush < 0)
        {
            timeBetweenPush = 0;
            Debug.LogWarning("Time cannot be negative. Set to 0.", this);
        }

        if (maxSpeed < 0)
        {
            maxSpeed = 0;
            Debug.LogWarning("Maximum speed cannot be negative. Set to 0.", this);
        }
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The speed at which the bullet moves.")]
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
    
    public void OnValidate()
    {
        if (speed < 0)
        {
            speed = 0;
            Debug.LogWarning("The minimum speed cannot be negative. Set to 0.", this);
        }
    }
}

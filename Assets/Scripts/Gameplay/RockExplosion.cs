using UnityEngine;
using Random = UnityEngine.Random;

public class RockExplosion : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Array with the possible prefabs to spawn.")]
    [SerializeField] private GameObject[] _spawnRocks;
    
    [Header("Variables")]
    private ParticleSystem _particleSystem;
    
    private void Start()
    {
        _particleSystem = FindObjectOfType<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet")) return;
        
        _particleSystem.transform.position = transform.position;
        _particleSystem.Play();
        
        if (CompareTag("BigRock"))
        {
            Instantiate(
                _spawnRocks[Random.Range(0, _spawnRocks.Length)], 
                new Vector3(
                    Random.Range(transform.position.x - 1, transform.position.x + 1), 
                    Random.Range(transform.position.y - 1, transform.position.y + 1),
                    -10), 
                Quaternion.identity);
        }

        UpdateText.score += 100;
        Destroy(gameObject);
    }
}

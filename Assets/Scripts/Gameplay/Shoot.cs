using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Prefab to use for the bullet.")]
    [SerializeField] private GameObject bullet;
    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        Instantiate(bullet, transform);
    }
}

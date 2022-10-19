using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Prefab to use for the bullet.")]
    [SerializeField] private GameObject bullet;
    
    [Tooltip("Audio clip to play once you shoot.")] 
    public AudioClip _audioClip;


    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        Instantiate(bullet, transform);
        AudioManager.Instance.PlayOneShot(_audioClip);
    }
}

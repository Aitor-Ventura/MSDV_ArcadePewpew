using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockExplosion : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    [SerializeField] private GameObject[] _spawnRocks;

    private void Start()
    {
        _particleSystem = FindObjectOfType<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Bullet")) return;
        _particleSystem.transform.position = transform.position;
        _particleSystem.Play();
        if (gameObject.CompareTag("BigRock"))
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

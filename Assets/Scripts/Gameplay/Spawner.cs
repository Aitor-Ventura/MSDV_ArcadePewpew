using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Array of prefabs to use for spawning purposes.")]
    [SerializeField] private GameObject[] _spawnableRocks;
    
    [Header("Variables")]
    [Tooltip("Time, in seconds, for the next batch of spawning.")]
    [SerializeField] private float timeBetweenSpawnings;
    
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= timeBetweenSpawnings)
        {
            SpawnRock();
            time = 0f;
        }
    }

    private void SpawnRock()
    {
        Instantiate(_spawnableRocks[Random.Range(0, _spawnableRocks.Length)], transform.position, quaternion.identity);
    }

    public void OnValidate()
    {
        if (timeBetweenSpawnings < 0)
        {
            timeBetweenSpawnings = 0;
            Debug.LogWarning("The time between the spawnings cannot be negative. Set to 0.", this);
        }
    }
}

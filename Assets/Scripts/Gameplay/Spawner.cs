using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private float time;
    [SerializeField] private GameObject[] _spawnableRocks;
    [SerializeField] private float timeBetweenSpawnings;
    
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
}

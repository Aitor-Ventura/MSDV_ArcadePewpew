using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        Instantiate(bullet, transform);
    }
}

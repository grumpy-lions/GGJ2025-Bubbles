using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int MaxConcurrentObjectsSpawned;

    [SerializeField] GameObject SpawnableObject;

    [Range(0.1f, 60f)]
    public float SpawnDelay;

    public void Awake()
    {
        Instantiate(SpawnableObject, new Vector3(Random.Range(2.25f, 7.25f), Random.Range(2, 4), 12), Quaternion.identity);
        Spawned = 1;
    }

    float SpawnCounter = 0;
    public static int Spawned = 0;

    public void Update()
    {
        if (!Buttons.DEAD) {
            SpawnCounter += Time.deltaTime;
            if (SpawnCounter > SpawnDelay && Spawned < MaxConcurrentObjectsSpawned)
            {
                Instantiate(SpawnableObject, new Vector3(Random.Range(2.25f, 7.25f), Random.Range(2, 4f), 12), Quaternion.identity);
                SpawnCounter = 0;
                Spawned++;
            }
        }
    }

}

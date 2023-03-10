using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float nextSpawnTime = 0.0f, spawnRate = 5.0f;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Transform[] spawnPositions;

    private TimeManager timeManager;
    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }
    private void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime && !timeManager.gameOver && !timeManager.gameFinished)
        {
            nextSpawnTime += spawnRate;
            SpawnObejct(objects[RandomObjectNumber()], spawnPositions[RandomSpawnNumber()]);
        }
    }

    private void SpawnObejct(GameObject objectToSpawn, Transform newTransform)
    {
        Instantiate(objectToSpawn, newTransform.position, newTransform.rotation);
    }

    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }

    private int RandomObjectNumber()
    {
        return Random.Range(0, objects.Length);
    }
}

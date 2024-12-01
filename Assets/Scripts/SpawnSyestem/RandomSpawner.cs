using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnCenter;
    public float spawnRadius = 3f;
    private float Timer;
    public float StartTimer = 2;
    public int SpawnNumber;

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0 && SpawnNumber > 0)
        {
            Debug.Log($"Spawning {SpawnNumber} objects...");
            for (int i = 0; i < SpawnNumber; i++)
            {
                SpawnObjects();
            }

            Timer = StartTimer;
        }
    }

    void SpawnObjects()
    {
        Vector3 randomPosition = RandomPositionInCircle();
        Debug.Log($"Spawning at position: {randomPosition}");
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }

    Vector3 RandomPositionInCircle()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float distance = Random.Range(0f, spawnRadius);
        float x = Mathf.Cos(angle) * distance;
        float z = Mathf.Sin(angle) * distance;

        return spawnCenter.position + new Vector3(x, 0, z);
    }
}

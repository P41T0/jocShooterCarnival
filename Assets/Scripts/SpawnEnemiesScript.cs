using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] movingPrefabs; 
    public GameObject[] staticPrefabs; 
    public Transform[] movingSpawnPoints; 
    public Transform[] staticSpawnPoints; 
    public float movingSpawnInterval = 3f; 
    public float staticSpawnInterval = 5f;
    public float CartSpawnInterval = 20f;
    public float StaticprefabLifetime = 10f;
    public float MovprefabLifetime = 20f;

    private int lastMovingSpawnIndex = -1; 
    private int lastStaticSpawnIndex = -1; 

    private void Start()
    {
        InvokeRepeating("SpawnMovingPrefab", 0f, movingSpawnInterval);
        InvokeRepeating("SpawnStaticPrefab", 0f, staticSpawnInterval);
        InvokeRepeating("SpawnCart", 0f, CartSpawnInterval);
    }

    void SpawnMovingPrefab()
    {
        if (movingPrefabs.Length == 0 || movingSpawnPoints.Length == 0)
        {
            Debug.LogWarning("No hay prefabs m�viles o puntos de spawn m�viles asignados.");
            return;
        }

   
        int randomSpawnIndex;
        do
        {
            randomSpawnIndex = Random.Range(0, movingSpawnPoints.Length-1);
        } while (randomSpawnIndex == lastMovingSpawnIndex);

        Transform spawnPoint = movingSpawnPoints[randomSpawnIndex];
        if (spawnPoint.childCount > 0)
        {
            Debug.Log("El punto de spawn m�vil ya est� ocupado.");
            return;
        }


        lastMovingSpawnIndex = randomSpawnIndex;

        GameObject spawnedPrefab = Instantiate(movingPrefabs[0], spawnPoint.position, spawnPoint.rotation);
        spawnedPrefab.transform.parent = spawnPoint; 
        Destroy(spawnedPrefab, MovprefabLifetime);
    }

    void SpawnCart() {
        GameObject spawnedPrefab = Instantiate(movingPrefabs[1], movingSpawnPoints[2].position, movingSpawnPoints[2].rotation);
        spawnedPrefab.transform.parent = movingSpawnPoints[2];
        Destroy(spawnedPrefab, MovprefabLifetime);
    }

    void SpawnStaticPrefab()
    {
        if (staticPrefabs.Length == 0 || staticSpawnPoints.Length == 0)
        {
            Debug.LogWarning("No hay prefabs est�ticos o puntos de spawn est�ticos asignados.");
            return;
        }

        int randomSpawnIndex;
        do
        {
            randomSpawnIndex = Random.Range(0, staticSpawnPoints.Length);
        } while (randomSpawnIndex == lastStaticSpawnIndex);

        Transform spawnPoint = staticSpawnPoints[randomSpawnIndex];
        if (spawnPoint.childCount > 0)
        {
            Debug.Log("El punto de spawn est�tico ya est� ocupado.");
            return;
        }

        lastStaticSpawnIndex = randomSpawnIndex;

        int randomPrefabIndex = Random.Range(0, staticPrefabs.Length);
        GameObject prefabToSpawn = staticPrefabs[randomPrefabIndex];

        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        spawnedPrefab.transform.parent = spawnPoint; 
        Destroy(spawnedPrefab, StaticprefabLifetime);
    }
}




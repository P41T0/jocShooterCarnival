using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] movingPrefabs; // Prefabs que se mueven
    public GameObject[] staticPrefabs; // Prefabs que no se mueven
    public Transform[] movingSpawnPoints; // Puntos de spawn para prefabs m�viles
    public Transform[] staticSpawnPoints; // Puntos de spawn para prefabs est�ticos
    public float movingSpawnInterval = 3f; // Intervalo para spawns de objetos m�viles
    public float staticSpawnInterval = 5f; // Intervalo para spawns de objetos est�ticos
    public float prefabLifetime = 10f; // Tiempo de vida de los prefabs en segundos

    private int lastMovingSpawnIndex = -1; // �ltimo �ndice de spawn m�vil utilizado
    private int lastStaticSpawnIndex = -1; // �ltimo �ndice de spawn est�tico utilizado

    private void Start()
    {
        // Invocar funciones para spawnear cada tipo de prefab
        InvokeRepeating("SpawnMovingPrefab", 0f, movingSpawnInterval);
        InvokeRepeating("SpawnStaticPrefab", 0f, staticSpawnInterval);
    }

    void SpawnMovingPrefab()
    {
        if (movingPrefabs.Length == 0 || movingSpawnPoints.Length == 0)
        {
            Debug.LogWarning("No hay prefabs m�viles o puntos de spawn m�viles asignados.");
            return;
        }

        // Escoger un punto de spawn m�vil aleatorio que no sea el mismo que el �ltimo
        int randomSpawnIndex;
        do
        {
            randomSpawnIndex = Random.Range(0, movingSpawnPoints.Length);
        } while (randomSpawnIndex == lastMovingSpawnIndex);

        // Verificar si el punto de spawn est� ocupado
        Transform spawnPoint = movingSpawnPoints[randomSpawnIndex];
        if (spawnPoint.childCount > 0)
        {
            Debug.Log("El punto de spawn m�vil ya est� ocupado.");
            return;
        }

        // Actualizar el �ltimo �ndice de spawn utilizado
        lastMovingSpawnIndex = randomSpawnIndex;

        // Escoger un prefab m�vil aleatorio
        int randomPrefabIndex = Random.Range(0, movingPrefabs.Length);
        GameObject prefabToSpawn = movingPrefabs[randomPrefabIndex];

        // Generar el prefab
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        spawnedPrefab.transform.parent = spawnPoint; // Asignar el prefab como hijo del spawn point
        Destroy(spawnedPrefab, prefabLifetime);
    }

    void SpawnStaticPrefab()
    {
        if (staticPrefabs.Length == 0 || staticSpawnPoints.Length == 0)
        {
            Debug.LogWarning("No hay prefabs est�ticos o puntos de spawn est�ticos asignados.");
            return;
        }

        // Escoger un punto de spawn est�tico aleatorio que no sea el mismo que el �ltimo
        int randomSpawnIndex;
        do
        {
            randomSpawnIndex = Random.Range(0, staticSpawnPoints.Length);
        } while (randomSpawnIndex == lastStaticSpawnIndex);

        // Verificar si el punto de spawn est� ocupado
        Transform spawnPoint = staticSpawnPoints[randomSpawnIndex];
        if (spawnPoint.childCount > 0)
        {
            Debug.Log("El punto de spawn est�tico ya est� ocupado.");
            return;
        }

        // Actualizar el �ltimo �ndice de spawn utilizado
        lastStaticSpawnIndex = randomSpawnIndex;

        // Escoger un prefab est�tico aleatorio
        int randomPrefabIndex = Random.Range(0, staticPrefabs.Length);
        GameObject prefabToSpawn = staticPrefabs[randomPrefabIndex];

        // Generar el prefab
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        spawnedPrefab.transform.parent = spawnPoint; // Asignar el prefab como hijo del spawn point
        Destroy(spawnedPrefab, prefabLifetime);
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] movingPrefabs; // Prefabs que se mueven
    public GameObject[] staticPrefabs; // Prefabs que no se mueven
    public Transform[] movingSpawnPoints; // Puntos de spawn para prefabs móviles
    public Transform[] staticSpawnPoints; // Puntos de spawn para prefabs estáticos
    public float movingSpawnInterval = 3f; // Intervalo para spawns de objetos móviles
    public float staticSpawnInterval = 5f; // Intervalo para spawns de objetos estáticos
    public float prefabLifetime = 10f; // Tiempo de vida de los prefabs en segundos

    private int lastMovingSpawnIndex = -1; // Último índice de spawn móvil utilizado
    private int lastStaticSpawnIndex = -1; // Último índice de spawn estático utilizado

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
            Debug.LogWarning("No hay prefabs móviles o puntos de spawn móviles asignados.");
            return;
        }

        // Escoger un punto de spawn móvil aleatorio que no sea el mismo que el último
        int randomSpawnIndex;
        do
        {
            randomSpawnIndex = Random.Range(0, movingSpawnPoints.Length);
        } while (randomSpawnIndex == lastMovingSpawnIndex);

        // Verificar si el punto de spawn está ocupado
        Transform spawnPoint = movingSpawnPoints[randomSpawnIndex];
        if (spawnPoint.childCount > 0)
        {
            Debug.Log("El punto de spawn móvil ya está ocupado.");
            return;
        }

        // Actualizar el último índice de spawn utilizado
        lastMovingSpawnIndex = randomSpawnIndex;

        // Escoger un prefab móvil aleatorio
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
            Debug.LogWarning("No hay prefabs estáticos o puntos de spawn estáticos asignados.");
            return;
        }

        // Escoger un punto de spawn estático aleatorio que no sea el mismo que el último
        int randomSpawnIndex;
        do
        {
            randomSpawnIndex = Random.Range(0, staticSpawnPoints.Length);
        } while (randomSpawnIndex == lastStaticSpawnIndex);

        // Verificar si el punto de spawn está ocupado
        Transform spawnPoint = staticSpawnPoints[randomSpawnIndex];
        if (spawnPoint.childCount > 0)
        {
            Debug.Log("El punto de spawn estático ya está ocupado.");
            return;
        }

        // Actualizar el último índice de spawn utilizado
        lastStaticSpawnIndex = randomSpawnIndex;

        // Escoger un prefab estático aleatorio
        int randomPrefabIndex = Random.Range(0, staticPrefabs.Length);
        GameObject prefabToSpawn = staticPrefabs[randomPrefabIndex];

        // Generar el prefab
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        spawnedPrefab.transform.parent = spawnPoint; // Asignar el prefab como hijo del spawn point
        Destroy(spawnedPrefab, prefabLifetime);
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public float spawnRate = 4; // Rate at which zombies spawn
    public Vector3 spawnArea = new Vector3(2f, 0f, 2f); // Area where zombies can spawn
    public int spawnCount = 2; // Number of zombies to spawn initially
    public GameObject[] _zombieType; // Array of zombie prefabs

    public Vector3 spawnPosition; // Position where a zombie will spawn
    private GameObject player; // Reference to the player GameObject

    void Start()
    {
        player = GameObject.Find("Player"); // Find the player GameObject in the scene
        SpawnZombies(); // Spawn initial zombies
    }

    void Update()
    {
        // Update method is currently empty
    }

    void SpawnZombies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = ValidSpawnPosition(); // Get a valid spawn position
            Instantiate(_zombieType[Random.Range(0, _zombieType.Length)], spawnPosition, Quaternion.identity); // Instantiate a random zombie prefab at the spawn position
        }

        StartCoroutine(SpawnObject()); // Start coroutine to spawn additional zombies
    }

    Vector3 ValidSpawnPosition()
    {
        bool validPosition = false;
        float playerRadius = 4f; // Radius around the player where zombies should not spawn

        while (!validPosition)
        {
            spawnPosition = transform.position + new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));

            // Check if the spawn position is far enough from the player
            if (Vector3.Distance(spawnPosition, player.transform.position) > playerRadius)
            {
                validPosition = true;
            }
        }

        return spawnPosition;
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(10f); // Wait for a specified duration
        spawnCount += 4; // Increase the number of zombies to spawn
        SpawnZombies(); // Spawn additional zombies
    }
}
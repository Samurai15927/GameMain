using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public float spawnRate = 4; // Rate at which zombies spawn
    Vector3 spawnArea = new Vector3(9f, -0.9f, 9f); // Area where zombies can spawn
    public int spawnCount = 2; // Number of zombies to spawn initially
    public GameObject[] _zombieType; // Array of zombie prefabs

    public Vector3 spawnPosition; // Position where a zombie will spawn
    private GameObject player; // Reference to the player GameObject

    void Start()
    {
        player = GameObject.Find("Player"); // Find the player GameObject in the scene
        SpawnZombies(); // Spawn initial zombies
    }
    //Spawning Zombies Method Spawns the zombies every 10 seconds and adds more zombies everytime.
    void SpawnZombies()
    {
        //for Loop to spawn multiple zombies at once
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = ValidSpawnPosition(); // Gets a valid spawn position far enough away from player
            Instantiate(_zombieType[Random.Range(0, _zombieType.Length)], spawnPosition, Quaternion.identity); // Instantiate a random zombie prefab from _zombietype array at the spawn position
        }

        StartCoroutine(SpawnObject()); // Start coroutine to spawn additional zombies
    }
    //Method that gets a valid spawn position that is away from the player.
    Vector3 ValidSpawnPosition()
    {
        bool validPosition = false; //Sets valid position to false until a valid position is found
        float playerRadius = 4f; // Radius around the player where zombies should not spawn

        while (!validPosition)
        {
            spawnPosition = transform.position + new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));

            // Check if the spawn position is far enough from the player
            if (Vector3.Distance(spawnPosition, player.transform.position) > playerRadius)
            {
                //sets valid position to true once a valid position is found
                validPosition = true;
            }
        }

        return spawnPosition;
    }
    //Corutine that waits 10 seconds between zombie spawn cycles and adds zombies to each round
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(10f); // Wait for a specified duration
        spawnCount += 3; // Increase the number of zombies to spawn
        SpawnZombies(); // Spawn additional zombies
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public float spawnRate = 4;
    public Vector3 spawnArea = new Vector3(9f, 0f, 9f);
    public int spawnCount = 2;
    public GameObject[] _zombieType;
    

    public Vector3 spawnPosition;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player"); // Adjust the game object name if needed
        SpawnZombies();
    }

    void Update()
    {

    }

    void SpawnZombies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = ValidSpawnPosition();
            Instantiate(_zombieType[Random.Range(0, _zombieType.Length)], spawnPosition, Quaternion.identity);
        }
        StartCoroutine(SpawnObject());
    }

    Vector3 ValidSpawnPosition()
    {
        bool validPosition = false;
        float playerRadius = 4f; // Adjust this value based on the size of your player's collider or model

        while (!validPosition)
        {
            spawnPosition = transform.position + new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));

            if (Vector3.Distance(spawnPosition, player.transform.position) > playerRadius)
            {
                validPosition = true;
            }
        }

        Debug.Log(spawnPosition); // Output the spawn position for debugging
        return spawnPosition;
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(20f);
        spawnCount += 2;
        SpawnZombies();
    }
   
}

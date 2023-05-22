using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public float spawnRate = 4;
    public Vector3 spawnArea = new Vector3(5f, 5f, 5f);
    public int spawnCount = 2;
    public int roundCount = 1;
    public GameObject[] _zombieType;
  
    // Start is called before the first frame update

    void Start()
    {
           SpawnZombies();
    }
        
    // Update is called once per frame
    void Update()
    {

    }
    void SpawnZombies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));
            Instantiate(_zombieType[Random.Range(0, _zombieType.Length)], spawnPosition, Quaternion.identity);

        }
        StartCoroutine(SpawnObject());
    }
    IEnumerator SpawnObject()
    { 
        yield return new WaitForSeconds(20f);
        roundCount++;
        spawnCount += 2;
        SpawnZombies();
    }
}

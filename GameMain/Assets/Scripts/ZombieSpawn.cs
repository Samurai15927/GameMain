using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public float spawnRate = 4;
    public Vector3 spawnArea = new Vector3(5f, 5f, 5f);
    public int spawnCount = 5;
    public int roundCount = 1;
    GameObject ZombieRed;
    // Start is called before the first frame update
    void Start()
    {
        ZombieRed = GameObject.Find("ZombieRed");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), Random.Range(-spawnArea.z, spawnArea.z));
            Instantiate(ZombieRed, spawnPosition, Quaternion.identity);
            StartCoroutine(SpawnObject());
        }
        
    }

    IEnumerator SpawnObject()
    { 
        yield return new WaitForSeconds(5f);
    }
}

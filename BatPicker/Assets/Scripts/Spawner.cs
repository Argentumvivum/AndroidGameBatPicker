using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnTime = 3f;
    public Transform[] spawners;
    
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawners.Length);

        if(spawners[spawnPointIndex].GetComponent<SpawnerControl>().isEmpty)
            Instantiate(enemyPrefab, spawners[spawnPointIndex].position, spawners[spawnPointIndex].rotation);
    }
}

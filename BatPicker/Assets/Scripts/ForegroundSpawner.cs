using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundSpawner : MonoBehaviour {

    public float spawnTime;
    public Transform[] spawners;

    private void Start()
    {
        InvokeRepeating("SpawnForeground", 5.0f, spawnTime);
    }

    void SpawnForeground()
    {
        int index = Random.Range(0, spawners.Length);
        spawners[index].GetComponent<ForegroundHolder>().PickForeground();
        Instantiate(spawners[index].GetComponent<ForegroundHolder>().foreground, spawners[index].position, spawners[index].rotation);
    }
}

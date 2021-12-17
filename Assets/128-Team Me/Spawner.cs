using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnInterval;
    public GameObject spawnObject;

    private int lastIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(spawnInterval);

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        while (spawnIndex == lastIndex)
        {
            spawnIndex = Random.Range(0, spawnPoints.Length);
        }
        Instantiate(spawnObject, spawnPoints[spawnIndex]);

        StartCoroutine(SpawnObject());
    }
}

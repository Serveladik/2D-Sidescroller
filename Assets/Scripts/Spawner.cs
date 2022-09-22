using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float minSpawnTime = 0.2f;
    public float maxSpawnTime = 0.5f;
    public float timeToDestroy = 2f;
    private float timer = 0.0f;
    private float nextTime;
         
    void Start () 
    {
        nextTime = Random.Range(minSpawnTime, maxSpawnTime);    
    }
     
    void Update () 
    {
        timer += Time.deltaTime;
        if (timer > nextTime) 
        {
            Vector3 pos = new Vector3(Random.value, Random.value, 10);
            pos = Camera.main.ViewportToWorldPoint(pos);

            GameObject spawnedObj = Instantiate(spawnObject, pos, Quaternion.identity);
            
            Debug.Log("Object created");
            
            timer = 0.0f;
            nextTime = Random.Range(minSpawnTime, maxSpawnTime);
            Destroy(spawnedObj, timeToDestroy);
        }
    }
}

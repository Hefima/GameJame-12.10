using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HefimaLibrary;

public class IslandManager : MonoBehaviour
{
    public List<GameObject> spawnObj;
    public List<GameObject> enemyObj;

    public Transform basePos;
    public float spawnRadius;

    public float spawnMinCD;
    public float spawnMaxCD;

    float nextSpawn;
    float nextEnemy;

    private void Start()
    {
        nextSpawn = Time.time + Random.Range(spawnMinCD, spawnMaxCD);
        nextEnemy = Time.time + Random.Range(spawnMinCD *2, spawnMaxCD *2);        
    }


    private void Update()
    {
        if(Time.time >= nextSpawn)
        {
            SpawnObj();
        }

        if(Time.time >= nextEnemy)
        {
            SpawnEnemy();
        }
    }

    void SpawnObj()
    {
        nextSpawn = Time.time + Random.Range(spawnMinCD, spawnMaxCD);

        GameObject newObj = spawnObj[Random.Range(0, spawnObj.Count)];
        Instantiate(newObj, HefiMath.RandomVector3_Plane(spawnRadius, basePos.position), newObj.transform.rotation);
    }

    void SpawnEnemy()
    {
        nextEnemy = Time.time + Random.Range(spawnMinCD * 2, spawnMaxCD * 2);

        GameObject newEnemy = enemyObj[Random.Range(0, spawnObj.Count)];
        Instantiate(newEnemy, HefiMath.RandomVector3_Plane(spawnRadius, basePos.position), newEnemy.transform.rotation);
    }
}

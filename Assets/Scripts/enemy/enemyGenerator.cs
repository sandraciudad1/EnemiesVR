using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    [SerializeField] enemyPool enemyPool;
    public float spawnInterval = 10f; 

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition;
        do
        {
            spawnPosition = new Vector3(Random.Range(50f, 310f), 5.5f, Random.Range(-190f, 50f));
        }
        while (!checkSafetyZone(spawnPosition));

        GameObject newEnemy = enemyPool.getObject();
        newEnemy.transform.position = spawnPosition;
    }

    bool checkSafetyZone(Vector3 position)
    {
        return !(position.x < 250f && position.z > -170f && position.z < -90f);
    }
}

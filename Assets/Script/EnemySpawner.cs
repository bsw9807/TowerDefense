using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private int enemyCount = 10;
    [SerializeField]
    private GameObject testGo;

    [Header("Fixed Delay")]
    [SerializeField]
    private float delayBtwSpawns;

    private float spawnTimer;
    private int enemiesSpawned;

    private ObjectPooler pooler;

    private void Start()
    {
        pooler = GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = delayBtwSpawns;
            if (enemiesSpawned < enemyCount)
            {
                enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject newInst = pooler.GetInstFromPool();
        newInst.SetActive(true);
    }
}

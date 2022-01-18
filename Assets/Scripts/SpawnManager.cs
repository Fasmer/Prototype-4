using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerUp;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        int enemyIndex;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemyIndex = EnemyClass();
            Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition(), enemyPrefab[enemyIndex].transform.rotation);
        }
    }

    void SpawnPowerUp()
    {
        Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.1f, spawnPosZ);
        return randomPos;
    }

    private int EnemyClass()
    {
       return Random.Range(0, enemyPrefab.Length);
    }
}

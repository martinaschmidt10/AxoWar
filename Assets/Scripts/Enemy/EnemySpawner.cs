using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyKillerPrefab;
    public Transform[] spawnPoints;
    private bool EnemiesSpawned = false;

    void Update()
    {
        CheckPoints();
    }

    private void CheckPoints()
    {
        if ((GameManager.instance.player1Points >= 5 || GameManager.instance.player2Points >= 5) && !EnemiesSpawned)
        {
            SpawnEnemies();
            EnemiesSpawned = true;
        }
    }

    private void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(enemyKillerPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}

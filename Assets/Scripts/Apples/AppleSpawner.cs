using UnityEngine;
using System.Collections;
using System;


public class AppleSpawner : MonoBehaviour
{ 
    public GameObject applePrefab;
    public GameObject goldenAppel;
    public event Action<bool> OnGoldenAppleSpawned;


    [SerializeField] private bool goldenAppleSpawned = false;
    public bool isApple = false;
    private bool firstApple = true;


    private void Update()
    {
        if (!isApple)
        {
            SpawnApple();
        }
        CheckForGoldenAppleSpawn();
    }


    void SpawnApple()
    {
        Vector2 SpawnPosition;
        if (firstApple)
        {
            SpawnPosition = new Vector2(0, 0);
            firstApple = false;
        }
        else 
        { 
            
            SpawnPosition = new Vector2(UnityEngine.Random.Range(-7f, 7f), UnityEngine.Random.Range(4f, -4.2f));
        }

        Instantiate(applePrefab, SpawnPosition, Quaternion.identity);

        isApple = true;
    }


    private void CheckForGoldenAppleSpawn()
    {
        if ((GameManager.instance.player1Points >= 6 || GameManager.instance.player2Points >= 6) && !goldenAppleSpawned)
        {
            Debug.Log("apple");
            SpawnGoldenApple();
            goldenAppleSpawned = true;
            InvokeEvent(true);
        }
    }
    private void SpawnGoldenApple()
    {
        Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-5f, 5f));
        Instantiate(goldenAppel, spawnPosition, Quaternion.identity);
    }
    public void InvokeEvent(bool state)
    {
        OnGoldenAppleSpawned.Invoke(state);

    }
}




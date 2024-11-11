using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ShurikenPrefab;
    [SerializeField] private Transform[] SpanwPoints;

    private int shurikenCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnShurikens());
    }

    private IEnumerator SpawnShurikens()
    {
        for (int i = 0; i < shurikenCount; i++)
        {
            SpawnShuriken();
            yield return new WaitForSeconds(6f); // Espera 6 segundos antes de crear el siguiente
        }
    }
    

    private void SpawnShuriken()
    {
        Transform spawnPoint = SpanwPoints[Random.Range(0, SpanwPoints.Length)];//hacemos q spawnee random en la pantalla 
        Instantiate(ShurikenPrefab, spawnPoint.position, Quaternion.identity);
    }
}

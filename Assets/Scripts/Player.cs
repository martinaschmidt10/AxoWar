using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 3; // Vida del jugador
    public bool isStunned = false;
    public GameObject enemyAtackWarning;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("daniooo");
        enemyAtackWarning.SetActive(true);
        StartCoroutine(DisableWarning());

        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator DisableWarning()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAtackWarning.SetActive(false);
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto");
        GameManager.instance.RestartValues();
        GameManager.instance.ChangeScene(11);

        Destroy(gameObject);
    }
}

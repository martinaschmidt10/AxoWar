using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleColector : MonoBehaviour
{
    [SerializeField] private int Player;
    public AppleSpawner appleSpawner;

    void UpdatePoints(int player)
    {
        if(player == 1)
        GameManager.instance.player1Points ++;

        if(player == 2)
        GameManager.instance.player2Points++;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            appleSpawner.isApple = false;
            Destroy(other.gameObject);
            UpdatePoints(Player);
        }
        if (other.CompareTag("GoldenApple"))
        {
            GoldenApple(Player);
            Destroy(other.gameObject);
        }
    }

    private void GoldenApple(int Player)
    {
        if (Player == 1)
            GameManager.instance.player1Points += 2;

        if (Player == 2)
            GameManager.instance.player2Points += 2;

        appleSpawner.InvokeEvent(false);

    }
}

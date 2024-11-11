using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] public int Player;

    void UpdatePoints(int player)
    {
        if (player == 1)
            GameManager.instance.player1Points = 0;

        if (player == 2)
            GameManager.instance.player2Points = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            UpdatePoints(Player);
        }

    }
}
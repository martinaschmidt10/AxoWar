using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1; 
    public float killHeightOffset = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player)
            {
                if (collision.transform.position.y > transform.position.y + killHeightOffset)
                {
                    Destroy(gameObject); 
                }
                else
                {
                    player.TakeDamage(damage);
                }
            }
        }
    }
}

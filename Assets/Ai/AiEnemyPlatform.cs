using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemyPlatform : MonoBehaviour
{
    public Transform player1;          
    public Transform player2;         
    public float speed = 2.0f;         
    public float detectionRange = 5.0f; 
    public float groundCheckDistance = 1.0f; 

    private bool isFacingRight = true; 

    private void Update()
    {
        if(player1 != null && player2 != null)
        {
            FollowClosestPlayer();
        }
    }

    private void FollowClosestPlayer()
    {
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        Transform targetPlayer = (distanceToPlayer1 <= distanceToPlayer2) ? player1 : player2;

        if (Vector2.Distance(transform.position, targetPlayer.position) <= detectionRange)
        {
            Vector2 direction = (targetPlayer.position - transform.position).normalized;

            if (IsGroundInFront())
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime;

                if (direction.x > 0 && !isFacingRight)
                {
                    Flip();
                }
                else if (direction.x < 0 && isFacingRight)
                {
                    Flip();
                }
            }
        }
    }

    private bool IsGroundInFront()
    {
        // Posici�n de inicio del raycast en funci�n de la direcci�n en la que el enemigo est� mirando
        Vector2 rayStart = transform.position + (isFacingRight ? Vector3.right : Vector3.left) * 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, groundCheckDistance);

        // Visualizaci�n del raycast en la vista de escena para depuraci�n
        Debug.DrawRay(rayStart, Vector2.down * groundCheckDistance, Color.red);

        // Retorna verdadero si el raycast detecta el suelo
        return hit.collider != null && hit.collider.CompareTag("Ground");
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

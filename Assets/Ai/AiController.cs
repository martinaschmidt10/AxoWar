using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float shootRange = 5f;
    public float shootCooldown = 2f; 

    private float lastShootTime; 
    private PlayerShooting playerShooting;
    //agrego el stado 
    private PlayerState playerState;

    private void Start()
    {
        playerShooting = GetComponent<PlayerShooting>();
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        // Verificar si el enemigo está aturdido antes de moverse o disparar
        if (playerState != null && playerState.isStunned)
        {
            // Si el enemigo está aturdido, no hacer nada
            return;
        }


        MoveTo();
        Shoot();


    }

    private void MoveTo()
    {
        Transform nearestApple = FindNearestApple();


        if (nearestApple != null)
        {
            MoveTowards(nearestApple.position);
        }
    }

    private void Shoot()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= shootRange && Time.time >= lastShootTime + shootCooldown)
        {
            playerShooting.Shoot();
            lastShootTime = Time.time;
        }
    }
    private Transform FindNearestApple()
    {
        Transform nearestApple = null;
        float closestDistance = Mathf.Infinity;

       
        GameObject goldenApple = GameObject.FindWithTag("GoldenApple");
        if (goldenApple != null)
        {
           
            return goldenApple.transform;
        }

        
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject apple in apples)
        {
            float distance = Vector2.Distance(transform.position, apple.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestApple = apple.transform;
            }
        }

        return nearestApple;
    }

    private void MoveTowards(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
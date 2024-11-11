using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShuriken : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;


    private float XLimit = 8.5f;
    private float YLimit = 5f;


    void Start()
    {
        SetRandomDirection();    
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        

        if (transform.position.x >= XLimit || transform.position.x <= -XLimit)
        {
            direction.x = -direction.x;
        }
        if (transform.position.y >= YLimit || transform.position.y <= -YLimit)
            direction.y = -direction.y;
       
    }

    private void SetRandomDirection()
    {
        //generamos una direccion random 
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerState playerState = other.GetComponent<PlayerState>();

            if (playerState != null)
            {
                // Cambia el estado del jugador a StunState
                playerState.ChangeState(new StunState());
            }

           
        }
    }
}


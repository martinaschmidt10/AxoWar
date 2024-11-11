using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //platformer 
    public float jumpForce = 3f;
    public float speed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void MoveUp()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void MoveDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    //platformer
    public void MoveLeftPlatformer()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void MoveRightPlatformer()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f) // Solo saltar si est  en el suelo
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}

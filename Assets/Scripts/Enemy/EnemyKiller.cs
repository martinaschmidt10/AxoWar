using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{

    public float speed = 3f;
    private float TopLimit = 5f;
    private float BottomLimit = -5f;
    private bool MovingUp = true;
    void Start()
    {

    }

    void Update()
    {
        Movement();
    }

    

    private void Movement()
    {
        if (MovingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y >= TopLimit)
                MovingUp = false;
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y <= BottomLimit)
                MovingUp = true;
        }
    }
}

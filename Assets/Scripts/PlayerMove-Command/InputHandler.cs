using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public enum GameMode { Default, Platformer }
    public GameMode currentGameMode = GameMode.Default;


    public PlayerMovement player1;
    //Player Shoot
    public PlayerShooting playerShooting1;

    private ICommand moveLeftP1, moveRightP1, moveUpP1, moveDownP1, shootP1;
    //Platformer
    private ICommand moveLeftPlatformerP1, moveRightPlatformerP1, jumpPlatformerP1;

    private float xLimit = 8.8f; // Ajusta estos valores a tu pantalla
    private float yLimit = 4.8f;

    [SerializeField] private KeyCode KeyUp;
    [SerializeField] private KeyCode KeyDown;
    [SerializeField] private KeyCode KeyLeft;
    [SerializeField] private KeyCode KeyRight;
    [SerializeField] private KeyCode KeyShoot;

    //teclas para el modo Platformer
    [SerializeField] private KeyCode KeyPlatformerLeft;
    [SerializeField] private KeyCode KeyPlatformerRight;
    [SerializeField] private KeyCode KeyPlatformerJump;


    private void Start()
    {
        // Inicializar comandos para Player 1
        moveLeftP1 = new MoveLeftCommand(player1);
        moveRightP1 = new MoveRightCommand(player1);
        moveUpP1 = new MoveUpCommand(player1);
        moveDownP1 = new MoveDownCommand(player1);
        shootP1 = new ShootCommand(playerShooting1);

        // Inicializar comandos para el modo Platformer
        moveLeftPlatformerP1 = new MovePlatformerLeftCommand(player1);
        moveRightPlatformerP1 = new MovePlatformerRightCommand(player1);
        jumpPlatformerP1 = new JumpPlatformerCommand(player1);

    }

    private void Update()
    {
        if (currentGameMode == GameMode.Default)
        {
            PlayerMovement();
        }
        else if (currentGameMode == GameMode.Platformer)
        {
            PlatformerMovement();
        }

    }




    private void PlayerMovement()
    {
        // Verifica si el jugador 1 est  aturdido
        if (player1 != null)
        {
            if (!player1.GetComponent<PlayerState>().isStunned)
            {
                // Movimiento restringido dentro de los l mites
                if (Input.GetKey(KeyLeft) && player1.transform.position.x > -xLimit)
                {
                    moveLeftP1.Execute();
                }
                if (Input.GetKey(KeyRight) && player1.transform.position.x < xLimit)
                {
                    moveRightP1.Execute();
                }
                if (Input.GetKey(KeyUp) && player1.transform.position.y < yLimit)
                {
                    moveUpP1.Execute();
                }
                if (Input.GetKey(KeyDown) && player1.transform.position.y > -yLimit)
                {
                    moveDownP1.Execute();
                }
                if (Input.GetKeyDown(KeyShoot))
                {
                    shootP1.Execute();
                }
            }
        }


    }

    private void PlatformerMovement()
    {
        if (player1 != null)
        {
            if (!player1.GetComponent<PlayerState>().isStunned)
            {
                // Controles para el Jugador 1 en el modo plataforma
                if (Input.GetKey(KeyPlatformerLeft))
                {
                    moveLeftPlatformerP1.Execute();
                }
                if (Input.GetKey(KeyPlatformerRight))
                {
                    moveRightPlatformerP1.Execute();
                }
                if (Input.GetKeyDown(KeyPlatformerJump))
                {
                    jumpPlatformerP1.Execute();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformerLeftCommand : ICommand
{
    private PlayerMovement player;
    public MovePlatformerLeftCommand(PlayerMovement player) { this.player = player; }

    public void Execute()
    {
        player.MoveLeftPlatformer(); // M�todo para mover a la izquierda en el modo plataforma
    }
}
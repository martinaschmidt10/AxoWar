using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformerRightCommand : ICommand
{
    private PlayerMovement player;
    public MovePlatformerRightCommand(PlayerMovement player) { this.player = player; }

    public void Execute()
    {
        player.MoveRightPlatformer(); // Método para mover a la derecha en el modo plataforma
    }
}
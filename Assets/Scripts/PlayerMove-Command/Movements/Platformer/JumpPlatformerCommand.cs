using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatformerCommand : ICommand
{
    private PlayerMovement player;
    public JumpPlatformerCommand(PlayerMovement player) { this.player = player; }

    public void Execute()
    {
        player.Jump(); // Método específico de salto en PlayerMovement
    }
}

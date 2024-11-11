using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatformerCommand : ICommand
{
    private PlayerMovement player;
    public JumpPlatformerCommand(PlayerMovement player) { this.player = player; }

    public void Execute()
    {
        player.Jump(); // M�todo espec�fico de salto en PlayerMovement
    }
}

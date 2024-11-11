using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : ICommand
{
    private PlayerMovement _player;

    public MoveLeftCommand(PlayerMovement player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.MoveLeft();
    }
}

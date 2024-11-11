using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : ICommand
{
    private PlayerMovement _player;

    public MoveRightCommand (PlayerMovement player)
    {
        _player = player;
    }
    public void Execute()
    {
        _player.MoveRight();
    }
}

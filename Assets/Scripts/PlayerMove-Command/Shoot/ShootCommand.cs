using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : ICommand
{
    public PlayerShooting _playerShooting;

    public ShootCommand(PlayerShooting playerShooting)
    {
        _playerShooting = playerShooting;
    }

    public void Execute()
    {
        _playerShooting.Shoot();
    }
}
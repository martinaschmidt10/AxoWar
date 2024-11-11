using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter(PlayerState player);
    void Exit(PlayerState player);
    void StateUpdate(PlayerState player);
}

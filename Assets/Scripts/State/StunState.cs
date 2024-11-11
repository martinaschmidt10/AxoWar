using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : IState
{
    private PlayerState player;
    private float stunDuration = 3f; 
    private float stunEndTime;

    public void Enter(PlayerState player)
    {
        this.player = player;
        stunEndTime = Time.time + stunDuration;
        player.isStunned = true; 
        player.animator.SetBool("Stun", true);
    }

    public void Exit(PlayerState player)
    {
        player.animator.SetBool("Stun", false);
        player.isStunned = false; 
    }

    public void StateUpdate(PlayerState player)
    {
        if (Time.time >= stunEndTime)
        {
            player.ChangeState(new NormalState());
        }
    }
}

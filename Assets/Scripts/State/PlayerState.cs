using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private IState currentState;
    public bool isStunned;
    public Animator animator;

    void Start()
    {
        ChangeState(new NormalState());
    }

    public void ChangeState(IState newState)
    {
        if (newState == null)
        {
            Debug.LogError("El nuevo estado es nulo");
            return;
        }

        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState?.StateUpdate(this);
        }
    }
}


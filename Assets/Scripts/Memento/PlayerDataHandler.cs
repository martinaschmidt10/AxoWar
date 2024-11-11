using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDataHandler : MonoBehaviour
{
    private Vector3 initialPosition;
    private int initialPoints;

    [SerializeField] private int playerId;

    private void Start()
    {
        initialPosition = transform.position;
        initialPoints = 0;
    }

    public PlayerMemento CreateMemento()
    {
        int currentPoints = (playerId == 1) ? GameManager.instance.player1Points : GameManager.instance.player2Points;
        return new PlayerMemento(transform.position, currentPoints);
    }

    public void RestoreMemento(PlayerMemento memento)
    {
        transform.position = memento.Position;
        if (playerId == 1)
            GameManager.instance.player1Points = memento.Score;
        else if (playerId == 2)
            GameManager.instance.player2Points = memento.Score;
    }

    public void ResetToInitialState()
    {
        transform.position = initialPosition;
        if (playerId == 1)
            GameManager.instance.player1Points = initialPoints;
        else if (playerId == 2)
            GameManager.instance.player2Points = initialPoints;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMemento
{
    public Vector3 Position { get; }
    public int Score { get; }

    public PlayerMemento(Vector3 position, int score)
    {
        Position = position;
        Score = score;
    }
}


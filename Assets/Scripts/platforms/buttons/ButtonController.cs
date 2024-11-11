using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Sprite unpressedSprite;
    public Sprite pressedSprite;
    public bool isPressedPermanently = false;
    private SpriteRenderer spriteRenderer;
    private bool playerOnButton = false;

    private List<IButtonObserver> observers = new List<IButtonObserver>();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unpressedSprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnButton = true;
            if (!isPressedPermanently)
            {
                spriteRenderer.sprite = pressedSprite;
            }
            NotifyObservers();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnButton = false;
            if (!isPressedPermanently)
            {
                spriteRenderer.sprite = unpressedSprite;
            }
            NotifyObservers();
        }
    }

    public void SetPermanentlyPressed()
    {
        isPressedPermanently = true;
        spriteRenderer.sprite = pressedSprite;
    }

    public bool IsPlayerOnButton()
    {
        return playerOnButton;
    }

    public void AddObserver(IButtonObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnButtonStateChange();
        }
    }
}


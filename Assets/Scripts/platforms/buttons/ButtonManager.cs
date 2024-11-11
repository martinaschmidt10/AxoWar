using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour, IButtonObserver
{
    public ButtonController[] buttons;
    public GameObject doorClosed;
    public GameObject doorOpen;

    private bool doorUnlocked = false;

    void Start()
    {
        doorClosed.SetActive(true);
        doorOpen.SetActive(false);  

        foreach (ButtonController button in buttons)
        {
            button.AddObserver(this);
        }
    }

    public void OnButtonStateChange()
    {
        if (doorUnlocked) return;

        bool bothPressed = true;
        foreach (ButtonController button in buttons)
        {
            if (!button.IsPlayerOnButton())
            {
                bothPressed = false;
                break;
            }
        }

        if (bothPressed)
        {
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        doorUnlocked = true;
        doorClosed.SetActive(false);
        doorOpen.SetActive(true);

        foreach (ButtonController button in buttons)
        {
            button.SetPermanentlyPressed();
        }
    }
}


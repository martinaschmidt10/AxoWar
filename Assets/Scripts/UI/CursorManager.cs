using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private bool isMenuOpen = false;

   
    void Start()
    {
        HideCursor();
    }


    void Update()
    {
        if (isMenuOpen)
        {
            ShowCursor();
        }
        else
        {
            HideCursor();
        }

    }
   
   
    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    // Método para mostrar el cursor
    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

  
    public void SetMenuOpen(bool menuOpen)
    {
        isMenuOpen = menuOpen;
    }
}


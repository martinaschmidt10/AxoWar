using System.Collections;
using UnityEngine;


public class ShowControllers : MonoBehaviour
{
    public GameObject controllersUI; 
    public float displayTime = 2f; 

    private void Start()
    {
       
        Time.timeScale = 0f;
        controllersUI.SetActive(true);
        StartCoroutine(HideControllersAfterDelay());
    }

    private IEnumerator HideControllersAfterDelay()
    {
        // Esperar el tiempo de visualización
        yield return new WaitForSecondsRealtime(displayTime);

        // Desactivar la UI y restaurar el tiempo de juego
        controllersUI.SetActive(false);
        Time.timeScale = 1f;
    }
}


using System.Collections;
using UnityEngine;

public class IsOut : MonoBehaviour
{
    private DoorOpen doorOpen;

    private void Start()
    {
        doorOpen = FindObjectOfType<DoorOpen>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

            if (doorOpen != null) 
            doorOpen.ValueRestart(11);

            else
            {
                GameManager.instance.RestartValues();
                GameManager.instance.ChangeScene(11);
            }
            //StartCoroutine(HandleExitAndTransition());
        }

    }

    //private IEnumerator HandleExitAndTransition()
    //{
    //    // Espera un cuadro para asegurarse de que el objeto se haya destruido
    //    yield return null;

    //    // Reinicia el valor de playersAtDoor y llama a Victory
    //    if (doorOpen != null)
    //    {
    //        doorOpen.playersAtDoor = 0;
    //    }

    //    // Reinicia los valores del GameManager y carga la siguiente escena
    //    doorOpen.ValueRestart(11);
    //}
}

using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public int playersAtDoor = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersAtDoor++;
            Destroy(other.gameObject); // Elimina al jugador al tocar la puerta abierta.

            if (playersAtDoor == 2)
            {
                // Cambia a la pantalla de victoria cuando ambos jugadores han pasado por la puerta.
                ValueRestart(10);
            }
        }
    }

    public void ValueRestart(int scenNumber)
    {
        playersAtDoor = 0;
        GameManager.instance.RestartValues();
        GameManager.instance.ChangeScene(scenNumber);
    }
}


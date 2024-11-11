using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ProjectilePool pool;

    public void SetParentPool(ProjectilePool ParentPool)
    {
        pool = ParentPool;
            
    }

    //hacemos una ref al pool q este en el axolote correcto 
    private void OnBecameInvisible()
    {
        if (pool != null)
        {
            
        // Devolver el proyectil al pool cuando salga de pantalla
        pool.ReturnProjectile(gameObject);

        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
{
        // Verifica si el objeto con el que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Tocado");
            // Obtén el componente PlayerState del jugador impactado
            PlayerState playerState = other.GetComponent<PlayerState>();

            if (playerState != null)
            {
                // Cambia el estado del jugador a StunState
                playerState.ChangeState(new StunState());
            }

            // Devuelve el proyectil al pool
            if (pool != null)
            {
                pool.ReturnProjectile(gameObject);
            }
        }
    }
}


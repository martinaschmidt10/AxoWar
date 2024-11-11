using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public bool axoloteLeft;
    public string projectileType ; // Tipo de proyectil a disparar
    public ProjectilePool pool;//aca saque el static para q no siga pasando el bug de las balas 

    public void Shoot()
    {
        // Obtener el proyectil del pool
        GameObject projectile = pool.GetProjectile(projectileType);
        projectile.transform.position = firePoint.position;
        projectile.transform.rotation = firePoint.rotation;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Mover el proyectil en una dirección según el axolote
        if (axoloteLeft)
        {
            rb.velocity = firePoint.right * projectileSpeed; // Hacia la derecha
        }
        else
        {
            rb.velocity = -firePoint.right * projectileSpeed; // Hacia la izquierda (dirección contraria)
        }
    }
}

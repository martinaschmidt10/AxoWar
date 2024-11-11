using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public GameObject projectilePrefab;
    private List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();
    }

    // Obtener un proyectil del pool
    public GameObject GetProjectile(string type)
    {
        foreach (GameObject projectile in pool)
        {
            if (!projectile.activeInHierarchy && projectile.name.Contains(type))
            {
                projectile.SetActive(true);
                projectile.GetComponent<Projectile>().SetParentPool(this);//aca asigno el pool 
                return projectile;
            }
        }

        // Si no hay proyectiles disponibles, crear uno nuevo usando el Factory
        GameObject newProjectile = ProjectileFactory.Instance.CreateProjectile(type);
        newProjectile.GetComponent<Projectile>().SetParentPool(this);
        pool.Add(newProjectile);
        return newProjectile;
    }

    // Devolver el proyectil al pool
    public void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}

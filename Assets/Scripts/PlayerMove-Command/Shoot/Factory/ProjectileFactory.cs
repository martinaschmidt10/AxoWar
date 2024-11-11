using UnityEngine;

public class ProjectileFactory : MonoBehaviour 
{
    public static ProjectileFactory _instance;

    public static ProjectileFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProjectileFactory();
            }
            return _instance;
        }
    }

    // Método para crear diferentes tipos de proyectiles
    public GameObject CreateProjectile(string type)
    {
        switch (type)
        {
            case "Projectile1":
                return Object.Instantiate(Resources.Load("Projectile 1")) as GameObject;
            case "Projectile":
            default:
                return Object.Instantiate(Resources.Load("Projectile")) as GameObject;
        }
    }
}

using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] private ProjectileBehaviour _projectile;
    [SerializeField] private Transform _projectileSpawn;

    [SerializeField] private float _projectileMaxLifetime;

    private void Update()
    {
        if (!_projectile || !_projectileSpawn) 
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Destroy(Instantiate<ProjectileBehaviour>(_projectile, _projectileSpawn.transform.position, _projectileSpawn.transform.rotation), _projectileMaxLifetime);
        }
    }
}

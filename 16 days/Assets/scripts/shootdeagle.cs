using UnityEngine;

public class RevolverController : MonoBehaviour
{
    // --- Shooting Config ---
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 100f;
    public float fireRate = 0.01f; // Cooldown time between shots
    public int maxAmmo = 6; // Standard revolver capacity
    private int currentAmmo;
    private float nextFireTime = 0f;

    // --- Audio (Optional) ---
    public AudioSource gunshotSound;

    private void Start()
    {
        currentAmmo = maxAmmo; // Set ammo count
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click to fire
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (currentAmmo > 0)
        {
            nextFireTime = Time.time + fireRate; 
            currentAmmo--; 

            // Spawn bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = firePoint.forward * bulletSpeed;
            }

          
            if (gunshotSound != null)
            {
                gunshotSound.Play();
            }

            Debug.Log("Shot fired! Ammo left: " + currentAmmo);
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
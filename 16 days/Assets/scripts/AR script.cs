using UnityEngine;
using System.Collections;

public class AssaultRifle : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Animator gunAnimator;
    public int magazineSize = 30;
    public float bulletSpeed = 50f;
    public float fireRate = 0.1f; // Time between shots
    public float reloadTime = 2.5f;
    private int currentAmmo;
    private bool canShoot = true;

    void Start()
    {
        currentAmmo = magazineSize;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot && currentAmmo > 0)
        {
            StartCoroutine(FireBullet());
        }
    }

    IEnumerator FireBullet()
    {
        canShoot = false;

        // Play fire animation
        gunAnimator.SetTrigger("Fire");

        // Instantiate bullet at firePoint position, facing directly forward
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = firePoint.forward * bulletSpeed;

        currentAmmo--;
        Debug.Log($"Bullet fired! Ammo left: {currentAmmo}");

        // Wait for fire rate cooldown
        yield return new WaitForSeconds(fireRate);

        // Reload when ammo reaches 0
        if (currentAmmo <= 0)
        {
            StartCoroutine(ReloadWeapon());
        }
        else
        {
            canShoot = true;
        }
    }

    IEnumerator ReloadWeapon()
    {
        Debug.Log("Reloading...");
        gunAnimator.SetTrigger("Reload");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magazineSize;
        canShoot = true;

        Debug.Log("Reload complete! Ammo refilled.");
    }
}
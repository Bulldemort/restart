using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour
{
    public GameObject pelletPrefab;
    public Transform firePoint;
    public Animator gunAnimator;
    public int pelletsPerShot = 8;
    public float spreadAngle = 10f;
    public float bulletSpeed = 25f;
    public float fireCooldown = 2f;
    public float reloadTime = 3.3f;
    public int magazineSize = 6;
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
            StartCoroutine(FireShotgun());
        }
    }

    IEnumerator FireShotgun()
    {
        canShoot = false;

        // Set "Fire" animation trigger
        gunAnimator.SetTrigger("Fire");

        // Fire pellets towards the center of the screen
        for (int i = 0; i < pelletsPerShot; i++)
        {
            float randomSpread = Random.Range(-spreadAngle, spreadAngle);
            Quaternion spreadRotation = Quaternion.Euler(0, randomSpread, 0);
            GameObject pellet = Instantiate(pelletPrefab, firePoint.position, firePoint.rotation * spreadRotation);
            Rigidbody pelletRb = pellet.GetComponent<Rigidbody>();
            pelletRb.velocity = pellet.transform.forward * bulletSpeed;
        }

        currentAmmo--;
        Debug.Log($"Shotgun fired! Ammo left: {currentAmmo}");

        // Wait for cooldown before next shot
        yield return new WaitForSeconds(fireCooldown);

        // Check if ammo is depleted, then reload
        if (currentAmmo <= 0)
        {
            StartCoroutine(ReloadShotgun());
        }
        else
        {
            canShoot = true;
        }
    }

    IEnumerator ReloadShotgun()
    {
        Debug.Log("Reloading...");
        gunAnimator.SetTrigger("Reload");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magazineSize;
        canShoot = true;

        Debug.Log("Reload complete! Ammo refilled.");
    }
}

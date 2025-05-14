using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab; // The object to shoot
    public float projectileSpeed = 10f; // Speed of the projectile
    public Camera mainCamera; // Reference to the main camera
    public Transform shootPoint; // The point from which the projectile is fired
    public int ammo;
    public int wait;
    public Animator anim;

    void Start()
    {
        // If no camera is assigned, use the main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (mainCamera == null)
        {
            Debug.LogError("No camera found! Please assign a camera.");
        }
        ammo = 8;
        wait = 0;
    }

    void Update()
    {
        // **Rotate the object to always point toward the center of the screen**
        RotateTowardCenter();

        // Fire when the player presses the left mouse button
        if ((Input.GetMouseButtonDown(0)) && (ammo > 0) && (wait <= 0))
        {
            ShootProjectile();
            ammo = ammo - 1;
        }

        if (ammo <= 0)
        {
            wait = 150;
            ammo = 8;
        }
       

        if (wait > 0)
        {
            wait = wait - 1;
        }
    }

    void RotateTowardCenter()
    {

        if (mainCamera == null || shootPoint == null) return;

        // Get the center of the screen as a world point
        Ray ray = mainCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
         else
        {
        targetPoint = ray.GetPoint(100);
        }

        // Calculate direction from shootPoint to targetPoint
        Vector3 direction = (targetPoint - shootPoint.position).normalized;

        // Get the correct rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        // **Modify only the Y rotation**
        float correctedYRotation = lookRotation.eulerAngles.y + 180f;

        // Apply only the Y rotation change, keeping X and Z unchanged
        shootPoint.rotation = Quaternion.Euler(shootPoint.rotation.eulerAngles.x, correctedYRotation, shootPoint.rotation.eulerAngles.z);
    }

    void ShootProjectile()
    {
        if (projectilePrefab == null || shootPoint == null || mainCamera == null) return;

        // Get the center of the screen as a world point
        Ray ray = mainCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = (targetPoint - shootPoint.position).normalized;

        // Instantiate the projectile and set its velocity
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }
}
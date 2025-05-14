using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunlook : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Vector3 rotationOffset = Vector3.zero; // Optional rotation offset

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
    }

    void LateUpdate()
    {
        if (mainCamera == null) return;

        // Match the object's rotation to the camera's rotation with an optional offset
        transform.rotation = mainCamera.transform.rotation * Quaternion.Euler(rotationOffset);
    }
}

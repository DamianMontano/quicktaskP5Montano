using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Smoothly follows a target with optional rotation follow.
/// Attach this script to your Camera in Unity.
/// </summary>
public class MainCamera : MonoBehaviour
{
    [Header("Target Settings")]
    [Tooltip("The Transform the camera will follow (e.g., Player).")]
    public Transform target;

    [Header("Position Settings")]
    [Tooltip("Offset from the target's position.")]
    public Vector3 offset = new Vector3(0f, 1f, -10f);

    [Tooltip("How quickly the camera moves to the target position.")]
    [Range(0.01f, 1f)]
    public float smoothSpeed = 0.125f;

    [Header("Rotation Settings")]
    [Tooltip("Follow the target's rotation?")]
    public bool followRotation = false;

    [Tooltip("How quickly the camera rotates to match the target.")]
    [Range(0.01f, 1f)]
    public float rotationSmoothSpeed = 0.125f;

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("MainCamera: No target assigned.");
            return;
        }

        // Smooth position follow
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Optional smooth rotation follow
        if (followRotation)
        {
            Quaternion desiredRotation = target.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed);
        }
    }
}
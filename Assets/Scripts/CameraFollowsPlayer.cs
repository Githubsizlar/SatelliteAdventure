using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public Transform target;           // The player's transform to follow
    public Vector3 offset = new Vector3(0, 0, -10); // Offset from the player's position

    [Range(0, 1)]
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public Transform target;        // The character's transform to follow
    public Vector3 offset = new Vector3(0f, 3f);  // Camera offset from the character in 2D;
    public float followSpeed = 5f;  // Speed factor for camera movement

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired camera position by adding the offset to the target's position
        Vector3 desiredPosition = new Vector3(target.localPosition.x + offset.x, target.localPosition.y + offset.y, transform.localPosition.z);

        // Calculate the new position by moving the camera directly towards the desired position with a constant speed
        Vector3 newPosition = Vector3.MoveTowards(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Set the camera's position directly to the new position
        transform.position = newPosition;
    }
}

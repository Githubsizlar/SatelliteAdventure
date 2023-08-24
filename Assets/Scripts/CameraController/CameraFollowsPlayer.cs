using UnityEngine;

namespace CameraController
{
    public class CameraFollowsPlayer : MonoBehaviour
    {
        public Transform target;           
        public Vector3 offset = new(0, 0, -10); 

        [Range(0, 1)]
        public float smoothSpeed = 0.125f;

        private bool _istargetNull;

        private void Start()
        {
            _istargetNull = target == null;
        }

        private void LateUpdate()
        {
            if (_istargetNull)
                return;

            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

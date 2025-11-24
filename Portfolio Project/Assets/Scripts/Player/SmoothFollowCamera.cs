using UnityEngine;

public class SmoothFollowCamera : MonoBehaviour
{  
    [SerializeField] private float Damping;
    [SerializeField] private Vector3 Offset;

    public Transform CameraTarget;

    private Vector3 Velocity= Vector3.zero;

    private Camera camera;

    private BoxCollider2D CamCollider;

    private void FixedUpdate()
    {
        var targetPosition = CameraTarget.position + Offset;
        transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
    }

    private void Start()
    {
  
    }


}

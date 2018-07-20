
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target, target2;
    public Vector3 offset;
    public float smoothspeed = 0.125f;
    public bool now = false;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothspeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
        if (now == true)
        {
            transform.LookAt(target2);

        }
        else
        {
            transform.LookAt(target);
        }
    } 
}

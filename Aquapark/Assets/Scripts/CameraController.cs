
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothness;
    public Vector3 offset;
    Vector3 velocity = Vector3.zero;
    public bool lookAt = true;


    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothness);
        transform.position = smoothedPosition;
        //if (lookAt)
        //{
        //    transform.LookAt(player);
        //}
        //else
        //{
        //    transform.rotation = player.rotation;
        //}

    }


}

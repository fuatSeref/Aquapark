using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
   public ForceMode force;
    public float speed;
    public float moveSpeed;

    Vector3 targetPosition;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
      //  
    }

    private void Update()
    {
        rb.AddForce(transform.position - targetPosition * speed, force);
        targetPosition = transform.position;
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, rb.velocity.z);
    }


}

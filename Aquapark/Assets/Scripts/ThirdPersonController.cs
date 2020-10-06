using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;

    public float speed;

    public float turnSmoothTime;
    float turnSmoothVelocity;
    Rigidbody rb;
    public ForceMode force;
    public float ForceSpeed;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * ForceSpeed, force);
    }
    void Update()
    {
        float horizantal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizantal, 0f, vertical).normalized;

        if(direction.magnitude >0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}

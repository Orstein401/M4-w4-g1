using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;

    private Rigidbody rb;

    private float h;
    private float v;

    private Vector3 direction;
    Quaternion angleRotation;

    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
      
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        direction = new Vector3(h, 0f, v).normalized;
       
    }
    private void FixedUpdate()
    {
        angleRotation = Quaternion.Euler(Vector3.up * (h * speedRotation * Time.fixedDeltaTime));
        rb.MoveRotation(rb.rotation * angleRotation);
        rb.MovePosition(rb.position + transform.forward * (v * speed * Time.fixedDeltaTime));
    }
}

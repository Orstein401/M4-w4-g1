using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;

    private Rigidbody rb;
    private Camera cam;

    private float h;
    private float v;
    private float mouseX;


    private Vector3 direction;
    Quaternion angleRotation;

    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        cam = Camera.main;
      
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //direction = new Vector3(h, 0f, v).normalized;
        direction = cam.transform.forward*v+cam.transform.right*h;
        direction.y = 0;
        direction.Normalize();
        //rotazione
      

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+direction*(speed*Time.fixedDeltaTime));
        //rotazione
        Vector3 camForward = cam.transform.forward;
        camForward.y = 0f;
        camForward.Normalize();
        Quaternion targetRot = Quaternion.LookRotation(camForward);
        //Quaternion targetRot = Quaternion.LookRotation(cam.transform.forward);

        rb.rotation=  Quaternion.Slerp(rb.rotation, targetRot, speedRotation*Time.fixedDeltaTime);

        //angleRotation = Quaternion.Slerp(transform.rotation, cam.transform.rotation, speedRotation * Time.fixedDeltaTime);
        //transform.rotation=angleRotation;
        //angleRotation = Quaternion.Euler(Vector3.up * (h * speedRotation * Time.fixedDeltaTime));
        ////transform.Rotate(Vector3.up * (mouseX * speedRotation));
        //rb.MoveRotation(angleRotation);
        //rb.MovePosition(rb.position + transform.forward * (v * speed * Time.fixedDeltaTime));
    }
}

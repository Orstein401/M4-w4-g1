using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOrbit : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private Vector3 offSet;

    [SerializeField] private float speedMouse;
    [SerializeField] private float bottomClamp;
    [SerializeField] private float upClamp;
    [SerializeField] private float magicValue;

    private Quaternion rotation;

    private float yaw;
    private float pitch;

    private Vector3 velocity = new Vector3(0, 0, 2);
    [SerializeField] private float timeForChase;

    Vector3 desirePos;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        yaw += Input.GetAxis("Mouse X")*speedMouse;
        pitch -= Input.GetAxis("Mouse Y")*speedMouse;

        pitch= Mathf.Clamp(pitch,bottomClamp,upClamp);
        rotation = Quaternion.Euler(pitch,yaw,0f);

        desirePos = target.transform.position + rotation * offSet;


        //transform.position = target.transform.position + rotation*offSet;
        //transform.position = Vector3.SmoothDamp(transform.position, desirePos, ref velocity, timeForChase);


    }
    private void LateUpdate()
    {
       // transform.LookAt(target.transform.position+Vector3.up*magicValue);
        transform.SetPositionAndRotation(desirePos,rotation);
    }
}

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

    private void Update()
    {
        yaw += Input.GetAxis("Mouse X")*speedMouse;
        pitch -= Input.GetAxis("Mouse Y")*speedMouse;

        pitch= Mathf.Clamp(pitch,bottomClamp,upClamp);
        Debug.Log(yaw+" "+pitch);
        rotation = Quaternion.Euler(pitch,yaw,0f);
        


        transform.position = target.transform.position + rotation*offSet;

    }
    private void LateUpdate()
    {
        transform.LookAt(target.transform.position+Vector3.up*magicValue);
    }
}

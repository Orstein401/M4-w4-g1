using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] Vector3 dest;
    [SerializeField] float speed;
    private void Awake()
    {
        body=GetComponent<Rigidbody>();
    }
    void Update()
    {
        body.MovePosition(body.position+transform.forward*speed*Time.deltaTime);
    }
}

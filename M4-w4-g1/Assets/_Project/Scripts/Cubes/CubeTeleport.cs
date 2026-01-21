using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTeleport : MonoBehaviour,IHit
{
    [SerializeField] Vector3[] teleportPoint;
    public void GetHit()
    {
        int numteleport=Random.Range(0, teleportPoint.Length);
        transform.position=teleportPoint[numteleport];
        Debug.Log("mi teleporto");
    }
}

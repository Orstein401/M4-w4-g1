using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHit
{
    [SerializeField] private int Health;
    public void GetHit()
    {
        Health -= 1;
        if (Health < 0)
        {
            Debug.Log("Nemico morto");
            Destroy(gameObject);
        }
        Debug.Log("sono un nemico");
    }
}

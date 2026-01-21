using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class CubeRainbow : MonoBehaviour, IHit
{
    private MeshRenderer mR;
    private void Awake()
    {
        mR = GetComponent<MeshRenderer>();
    }
    public void GetHit()
    {
        float red = Random.Range(0, 256);
        float green = Random.Range(0, 256);
        float blue = Random.Range(0, 256);

        //Color newColor = new Color(red, green, blue);
        Color newColor = new Color(red/255f,green/255f,blue/255f);
        mR.material.color = newColor;
        Debug.Log("sono un cubo arcobaleno");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColorChanger : MonoBehaviour
{
    Color[] colors = { Color.gray, Color.red, Color.blue, Color.green, Color.yellow };

    // Start is called before the first frame update
    void Start()
    {
        //Color col = this.GetComponent<MeshRenderer>().material.color;

        Color col = colors[Random.Range(0, colors.Length)];

        this.GetComponent<MeshRenderer>().material.color = col;
    }
}

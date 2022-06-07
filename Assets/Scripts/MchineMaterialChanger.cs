using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MchineMaterialChanger : MonoBehaviour
{
    public Material[] machineMat;

    // Start is called before the first frame update
    void Start()
    {
        Material mat = this.GetComponent<MeshRenderer>().material;

        mat = machineMat[Random.Range(0, 10)];

        this.GetComponent<MeshRenderer>().material = mat;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosaic : MonoBehaviour
{
    public Transform staff;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        staff = GameObject.Find("Staff/Staff_" + name.Substring(7, 4)).transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(staff.position);
    }
}

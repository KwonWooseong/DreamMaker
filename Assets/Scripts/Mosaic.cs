using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mosaic : MonoBehaviour
{
    Image img;

    public Transform staff;
    public Sprite[] sprites = new Sprite[6];

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = sprites[Random.Range(0, 6)];
        staff = GameObject.Find("Staff/Staff_" + name.Substring(7, 4)).transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(staff.position);
    }
}

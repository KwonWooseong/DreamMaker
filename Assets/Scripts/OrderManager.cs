using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    bool activated = false;

    public bool isLockedOn;

    public GameObject order;

    public static OrderManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(activated == false)
            {
                activated = true;
                order.SetActive(true);
            }
            else
            {
                activated = false;
                order.SetActive(false);
            }
        }
    }
}

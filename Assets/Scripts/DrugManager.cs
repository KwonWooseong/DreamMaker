using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugManager : MonoBehaviour
{
    public bool isLockedOn;

    public GameObject Red;
    public GameObject Blue;

    public static DrugManager instance;

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
        Dose();
    }

    void Dose()
    {
        if (isLockedOn)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Debug.Log("Dose Blue!");
                GameObject drugObject = Instantiate(Blue);
                drugObject.transform.position = GameManager.instance.hit.transform.position;
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //Debug.Log("Dose Red!");
                GameObject drugObject = Instantiate(Red);
                drugObject.transform.position = GameManager.instance.hit.transform.position;
            }
        }
    }
}

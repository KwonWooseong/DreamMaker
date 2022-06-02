using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugManager : MonoBehaviour
{
    public bool isLockedOn;

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
        
    }
}

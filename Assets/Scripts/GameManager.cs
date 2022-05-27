using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int xLimit = 3;  //min 1, max 9
    public int zLimit = 2;


    public GameObject factory;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FactoryGen();
        StaffManager.instance.StaffGen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FactoryGen()
    {
        for(int j = 0; j < zLimit; j++) 
        {
            for(int i = 0; i < xLimit; i++)
            {
                //Debug.Log("factory spawn!");

                GameObject factoryObj = Instantiate(factory);
                
                factoryObj.transform.position = new Vector3(i*100, 0, j*100);

                if (j == 0)
                {
                    factoryObj.name = "Factory_0" + (i + 1);
                }
                else
                {
                    factoryObj.name = "Factory_" + (j * 10 + i + 1);
                }
            }
        }
    }
}

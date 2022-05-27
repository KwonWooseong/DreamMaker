using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffManager : MonoBehaviour
{



    public GameObject staff;

    public static StaffManager instance;

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

    public void StaffGen()
    {
        for(int j=0; j<GameManager.instance.zLimit; j++)
        {
            for(int i=0; i<GameManager.instance.xLimit; i++)
            {
                for(int k=1; k<=4; k++)
                {
                    string factoryName;
                    if (j == 0)
                    {
                        factoryName = "Factory_0" + (i + 1);
                    }
                    else
                    {
                        factoryName = "Factory_" + (j * 10 + i + 1);
                    }

                    GameObject staffObj = Instantiate(staff);

                    staffObj.transform.position = GameObject.Find(factoryName + "/Bed/Bed_" + k).transform.position;
                }
            }
        }
    }
}

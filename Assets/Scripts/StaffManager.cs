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
    {   //실행시 공장의 모든 방에 직원 4명씩 생성
        for(int j=0; j<GameManager.instance.zLimit; j++)
        {
            for(int i=1; i<=GameManager.instance.xLimit; i++)
            {
                for(int k=1; k<=4; k++)
                {
                    string factoryName;
                    if (j == 0)
                    {
                        factoryName = "Factory_0" + i;
                    }
                    else
                    {
                        factoryName = "Factory_" + (j * 10 + i);
                    }
                    GameObject staffObj = Instantiate(staff);
                    staffObj.transform.position = GameObject.Find(factoryName + "/Bed/Bed_" + k).transform.position;
                    // 스태프 이름 변경
                    if (j == 0)
                    {
                        staffObj.name = "Staff_0" + i + "_" + k;
                    }
                    else
                    {
                        staffObj.name = "Staff_" + (j * 10 + i) + "_" + k;
                    }
                }
            }
        }
    }
}

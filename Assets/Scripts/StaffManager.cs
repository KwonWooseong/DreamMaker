using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffManager : MonoBehaviour
{
    public GameObject staff;
    public GameObject mosaic;

    public static StaffManager instance;

    private void Awake()
    {
        instance = this;
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
                    staffObj.transform.SetParent(GameObject.Find("Staff").transform);
                    Vector3 spawnPos = GameObject.Find("Factory/" + factoryName + "/Bed/Bed_" + k).transform.position;
                    staffObj.transform.position = new Vector3(spawnPos.x, spawnPos.y + 1, spawnPos.z);
                    // 스태프 이름 변경
                    if (j == 0)
                    {
                        staffObj.name = "Staff_0" + i + "_" + k;
                    }
                    else
                    {
                        staffObj.name = "Staff_" + (j * 10 + i) + "_" + k;
                    }

                    GameObject mosaicObj = Instantiate(mosaic);
                    mosaicObj.transform.SetParent(GameObject.Find("Canvas/MainUICanvas/Mosaic").transform);
                    // 모자이크 이름 변경
                    if (j == 0)
                    {
                        mosaicObj.name = "Mosaic_0" + i + "_" + k;
                    }
                    else
                    {
                        mosaicObj.name = "Mosaic_" + (j * 10 + i) + "_" + k;
                    }
                }
            }
        }
    }
}

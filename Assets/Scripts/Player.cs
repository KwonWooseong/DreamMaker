using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int x, z, tempX, tempZ, tempCameraNum;

    public int cameraNum;
    public string cameraName;
    public bool isMoved = false;

    public Text cameraTxt;
    public Text wTxt;
    public Text sTxt;
    public Text aTxt;
    public Text dTxt;

    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        z = 0;
        cameraNum = 1;
        cameraName = "CAMERA_01";
        cameraTxt.text = cameraName;
    }

    // Update is called once per frame
    void Update()
    {   // 이동 불가능 지역의 경우 이동UI 비활성화
        if (z == (GameManager.instance.zLimit - 1) * 100) wTxt.color = Color.gray;
        else wTxt.color = Color.white;

        if (z == 0) sTxt.color = Color.gray;
        else sTxt.color = Color.white;

        if (x == 0) aTxt.color = Color.gray;
        else aTxt.color = Color.white;

        if (x == (GameManager.instance.xLimit - 1) * 100) dTxt.color = Color.gray;
        else dTxt.color = Color.white;

        Move();
    }
    void Move()
    {   // 목표지역이 이동불가능 지역이 아니라면 이동
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(wTxt.color == Color.white)
            {
                z += 100;
                cameraNum += 10;
                if (cameraNum < 10) cameraName = "CAMERA_0" + cameraNum;
                else cameraName = "CAMERA_" + cameraNum;

                gameObject.transform.position = new Vector3(x, 20.7f, z);
                cameraTxt.text = cameraName;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (sTxt.color == Color.white)
            {
                z -= 100;
                cameraNum -= 10;
                if (cameraNum < 10) cameraName = "CAMERA_0" + cameraNum;
                else cameraName = "CAMERA_" + cameraNum;

                gameObject.transform.position = new Vector3(x, 20.7f, z);
                cameraTxt.text = cameraName;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (aTxt.color == Color.white)
            {
                x -= 100;
                cameraNum -= 1;
                if (cameraNum < 10) cameraName = "CAMERA_0" + cameraNum;
                else cameraName = "CAMERA_" + cameraNum;

                gameObject.transform.position = new Vector3(x, 20.7f, z);
                cameraTxt.text = cameraName;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (dTxt.color == Color.white)
            {
                x += 100;
                cameraNum += 1;
                if (cameraNum < 10) cameraName = "CAMERA_0" + cameraNum;
                else cameraName = "CAMERA_" + cameraNum;

                gameObject.transform.position = new Vector3(x, 20.7f, z);
                cameraTxt.text = cameraName;
            }
        }
    }
}

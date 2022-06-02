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
        cameraTxt.text = "CAMERA_01";
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //StartCoroutine(CameraMove());
    }


    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            tempZ = z + 100;
            tempCameraNum = cameraNum + 10;

            if ((tempCameraNum < GameManager.instance.zLimit * 10) && (tempCameraNum >= 0))
            {
                z = tempZ;
                cameraNum = tempCameraNum;
                if (cameraNum < 10) cameraName = "CAMERA_0" + cameraNum;
                else cameraName = "CAMERA_" + cameraNum;

                isMoved = true;
                gameObject.transform.position = new Vector3(x, 20, z);
                cameraTxt.text = cameraName;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            tempZ = z - 100;
            tempCameraNum = cameraNum - 10;

            if ((tempCameraNum < GameManager.instance.zLimit * 10) && (tempCameraNum >= 0))
            {
                z = tempZ;
                cameraNum = tempCameraNum;
                if (cameraNum < 10) cameraName = "CAMERA_0" + cameraNum;
                else cameraName = "CAMERA_" + cameraNum;

                isMoved = true;
                gameObject.transform.position = new Vector3(x, 20, z);
                cameraTxt.text = cameraName;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            tempX = x - 100;
            tempCameraNum = cameraNum - 1;

            if (((tempCameraNum % 10) <= GameManager.instance.xLimit) && ((tempCameraNum % 10) > 0))
            {
                x = tempX;
                cameraNum = tempCameraNum;
                if (cameraNum < 10) cameraName = "CAMERA_0" + cameraNum;
                else cameraName = "CAMERA_" + cameraNum;

                isMoved = true;
                gameObject.transform.position = new Vector3(x, 20, z);
                cameraTxt.text = cameraName;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            tempX = x + 100;
            tempCameraNum = cameraNum + 1;

            if (((tempCameraNum % 10) <= GameManager.instance.xLimit) && ((tempCameraNum % 10) > 0))
            {
                x = tempX;
                cameraNum = tempCameraNum;
                if (cameraNum < 10) cameraName = "CAMERA_0" + cameraNum;
                else cameraName = "CAMERA_" + cameraNum;

                isMoved = true;
                gameObject.transform.position = new Vector3(x, 20, z);
                cameraTxt.text = cameraName;
            }
        }
    }
}

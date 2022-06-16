using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugManager : MonoBehaviour
{
    bool canBlueDose;
    bool canRedDose;
    bool rReloading;
    bool lReloading;

    public bool isLockedOn;

    public GameObject Red;
    public GameObject Blue;
    public Image rBtn;
    public Image lBtn;
    public Image[] blueDrug;
    public Image[] redDrug;
    public Text rReload;
    public Text lReload;


    public static DrugManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        canBlueDose = true;
        canRedDose = true;
        rReloading = false;
        lReloading = false;
        rReload.text = "";
        lReload.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Dose();
        StartCoroutine(Reload());
    }

    void Dose()
    {
        if (isLockedOn)
        {   //약 수가 남아있고 버튼을 누르면 약을 투여
            if (Input.GetKeyDown(KeyCode.Mouse0) && canBlueDose)
            {
                for(int i=0; i < blueDrug.Length; i++)
                {
                    if (i == blueDrug.Length-1)
                    {
                        canBlueDose = false;
                        lBtn.color = Color.gray;
                        lReload.text = "R";
                    }
                    if (blueDrug[i].color == Color.white)
                    {
                        //Debug.Log("Dose Blue!");
                        GameObject drugObject = Instantiate(Blue);
                        drugObject.transform.position = GameManager.instance.hit.transform.position;
                        blueDrug[i].color = Color.gray;
                        break;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1) && canRedDose)
            {
                for (int i = 0; i < redDrug.Length; i++)
                {
                    if (i == redDrug.Length - 1)
                    {
                        canRedDose = false;
                        rBtn.color = Color.gray;
                        rReload.text = "F";
                    }
                    if (redDrug[i].color == Color.white)
                    {
                        //Debug.Log("Dose Blue!");
                        GameObject drugObject = Instantiate(Red);
                        drugObject.transform.position = GameManager.instance.hit.transform.position;
                        redDrug[i].color = Color.gray;
                        break;
                    }
                }
            }
        }
    }

    IEnumerator Reload()
    {   //약 수가 없고, 재입고중이 아니며 R키가 눌린경우 재입고
        if (!canBlueDose && !lReloading && Input.GetKeyDown(KeyCode.R))
        {
            lReloading = true;
            lReload.text = "3";
            yield return new WaitForSeconds(1);
            lReload.text = "2";
            yield return new WaitForSeconds(1);
            lReload.text = "1";
            yield return new WaitForSeconds(1);
            for(int i=0; i<blueDrug.Length; i++)
            {
                blueDrug[i].color = Color.white;
            }
            lBtn.color = Color.white;
            lReload.text = "";
            canBlueDose = true;
            lReloading = false;
        }

        if (!canRedDose && !rReloading && Input.GetKeyDown(KeyCode.F))
        {
            rReloading = true;
            rReload.text = "3";
            yield return new WaitForSeconds(1);
            rReload.text = "2";
            yield return new WaitForSeconds(1);
            rReload.text = "1";
            yield return new WaitForSeconds(1);
            for (int i = 0; i < redDrug.Length; i++)
            {
                redDrug[i].color = Color.white;
            }
            rBtn.color = Color.white;
            rReload.text = "";
            canRedDose = true;
            rReloading = false;
        }
    }
}

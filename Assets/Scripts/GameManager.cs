using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        MENU,
        START,
        PLAY,
        END
    }

    public string[] keyword = new string[25]
    {   // 키워드를 string으로 사용할때 GameManager 참조
        "개", "고양이", "벌", "뱀", "거미",
        "민트초코", "두리안", "오이", "땅콩", "우유",
        "인형", "라이터", "열쇠", "방망이", "사다리",
        "요리사", "의사", "변호사", "경찰", "광대",
        "카페", "공원", "바다", "산", "광장"
    };

    bool started, onPlay;
    int time;

    public int xLimit = 2;  //min 1, max 9
    public int zLimit = 2;
    public int success = 0;
    public int fail = 0;
    public int emotionMin = 100;
    public int emotionMax = 150;
    public int dreamKeywordMax = 10;
    public int keywordMax = 10;
    public int deltaEmotionMin = 5;
    public int deltaEmotionMax = 10;
    public int deltaEmotionbyDrug = 20;
    public int gold = 500;
    public float makeTime = 4.0f;
    public float restTime = 5.0f;

    public GameState state;
    public RaycastHit hit;
    public GameObject factory, info, loading, openingCheck, rotatingCheck, cencoringCheck,playButton, doorObj;
    public Text timeTxt, goldTxt;
    public Image timeImg, blue, red;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.MENU;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.MENU)
        {
            started = false;
            onPlay = false;

        }
        else if(state == GameState.START)
        {
            StartCoroutine(GameStart());

        }
        else if(state == GameState.PLAY)
        {
            StartCoroutine(Playing());

            ViewInfo();
            goldTxt.text = "" + gold;

            if (time <= 5)
            {
                timeTxt.color = Color.red;
            }
            else
            {
                timeTxt.color = Color.white;
            }

            if(time <= 0)
            {
                state = GameState.END;
            }
        }
        else if(state == GameState.END)
        {

        }
    }

    IEnumerator GameStart()
    {
        if (!started)
        {
            started = true;
            playButton.SetActive(false);
            loading.SetActive(true);

            FactoryGen();
            yield return new WaitForSeconds(1);
            openingCheck.SetActive(true);

            StaffManager.instance.StaffGen();
            yield return new WaitForSeconds(0.8f);
            rotatingCheck.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            cencoringCheck.SetActive(true);

            yield return new WaitForSeconds(0.3f);
            doorObj.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 45000f);
            Destroy(doorObj.gameObject, 1f);

            state = GameState.PLAY;
        }
    }

    IEnumerator Playing()
    {
        if (!onPlay)
        {
            onPlay = true;

            time = 100;
            timeTxt.text = "" + time;

            while (time > 0)
            {
                yield return new WaitForSeconds(1);
                time--;
                timeTxt.text = "" + time;
            }
        }
    }

    void ViewInfo()
    {
        //메인카메라에서 마우스포인터 위치로 레이를 발사
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if(Physics.Raycast(ray, out hit))
        {   //레이어가 Staff인 오브젝트에 적중시 Staff Info 활성화, DrugManager와 OrderManager의 변수를 활성화
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Staff"))
            {
                //Debug.Log("Staff Find!");
                info.SetActive(true);
                hit.transform.SendMessage("SetInfo", SendMessageOptions.DontRequireReceiver);

                DrugManager.instance.isLockedOn = true;
                OrderManager.instance.isLockedOn = true;
                blue.color = Color.white;
                red.color = Color.white;
            }
            else
            {   //미적중시 비활성화
                info.SetActive(false);
                DrugManager.instance.isLockedOn = false;
                OrderManager.instance.isLockedOn = false;
                blue.color = Color.gray;
                red.color = Color.gray;
            }
        }
    }

    void FactoryGen()
    {   //최대 방 수에 맞춰서 방 생성
        for(int j = 0; j < zLimit; j++) 
        {
            for(int i = 0; i < xLimit; i++)
            {
                //Debug.Log("factory spawn!");

                GameObject factoryObj = Instantiate(factory);
                factoryObj.transform.SetParent(GameObject.Find("Factory").transform);
                
                factoryObj.transform.position = new Vector3(i*100, 0, j*100);

                //번호에 맞춰 공장 이름 변경
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

    public void PlayeStart()
    {
        state = GameState.START;
    }

    public void PlusDream(int dreams)
    {
        success += dreams;
    }

    public void MinusDream(int dreams)
    {
        fail += dreams;
    }
}

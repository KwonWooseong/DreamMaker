using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    bool isOrdered = false;
    bool activated = false;
    bool isAccepted = true;
    bool isCounting = false;
    int count, orderMax, orderNum, reward;
    string cameraPos;
    int[] sequence = { 1, 2, 3, 4 };

    public bool isLockedOn;

    public List<int> orderList;
    public List<string> staff;

    public Text countTxt;
    public Text rewardTxt;
    public Text[] keywords;
    public Image orderUI;
    public Image qBtn;
    public GameObject openedOrderUI;
    public GameObject orderPrefab;

    public static OrderManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        orderMax = (int)(GameManager.instance.dreamKeywordMax * 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.state == GameManager.GameState.PLAY)
        {
            if (orderList.Count == 0)
            {
                orderUI.color = Color.gray;
                qBtn.color = Color.gray;
            }
            else
            {
                orderUI.color = Color.white;
                qBtn.color = Color.white;
            }

            for (int i = 0; i < keywords.Length; i++)
            {
                if (i < orderList.Count)
                {
                    keywords[i].text = GameManager.instance.keyword[orderList[i]];
                }
                else
                {
                    keywords[i].text = "";
                }
            }

            rewardTxt.text = "" + reward;

            OpenAndCloseOrder();
            AcceptOrder();
            StartCoroutine(GetOrder());
            StartCoroutine(AcceptCount());
        }
    }

    void OpenAndCloseOrder()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (activated == false)
            {
                activated = true;
                openedOrderUI.SetActive(true);
            }
            else
            {
                activated = false;
                openedOrderUI.SetActive(false);
            }
        }
    }

    void AcceptOrder()
    {   //주문이 들어온상태에서 E를 누르면 주문 수락을 시도
        if (isOrdered && Input.GetKeyDown(KeyCode.E))
        {
            RandomSequence();
            //미구현
            for (int i = 0; i < 4; i++)
            {
                GameObject orderObj = Instantiate(orderPrefab);
                orderObj.transform.position = GameObject.Find("Staff/Staff_" + Player.instance.cameraName.Substring(7, 2) + "_" + sequence[i]).transform.position;
            }
        }
    }

    IEnumerator GetOrder()
    {   //비주문상태인 경우 주문상태로 전환 후 몇초후 주문이 들어옴
        if (!isOrdered)
        {
            isOrdered = true;
            yield return new WaitForSeconds(Random.Range(5,10));

            orderNum = Random.Range(orderMax / 2, orderMax);
            reward = Random.Range(orderNum, orderNum * 2) * 50;

            for (int i = 0; i < orderNum; i++)
            {
                orderList.Add(Random.Range(0, GameManager.instance.keyword.Length));
            }

            isAccepted = false;
        }
    }

    IEnumerator AcceptCount()
    {
        if(!isAccepted && !isCounting)
        {   // 주문이 들어오고 미수락상태일시 카운트다운 진행
            isCounting = true;
            count = 31;
            countTxt.text = "new";

            while (isCounting)
            {   //주문이 수락된 상태가 되면 
                if (orderList.Count == 0)
                {
                    countTxt.text = "";
                    GameManager.instance.gold += reward;
                    isAccepted = true;
                    isOrdered = false;
                    isCounting = false;
                    reward = 0;
                    break;
                }

                yield return new WaitForSeconds(1);
                count--;
                countTxt.text = "" + count;

                if(count == 0)
                {   //카운트다운 종료시까지 미수락시 주문리스트를 초기화하고 패널티 부여
                    for(int i=0; i<orderList.Count;)
                    {
                        orderList.Remove(orderList[i]);
                    }

                    countTxt.text = "";

                    GameManager.instance.gold -= 100;
                    isAccepted = true;
                    isOrdered = false;
                    isCounting = false;
                    reward = 0;
                }
            }
        }
    }

    void RandomSequence()
    {
        for(int i=0; i<4; i++)
        {
            int temp = sequence[i];
            int rand = Random.Range(0, 4);
            sequence[i] = sequence[rand];
            sequence[rand] = temp;
        }
    }
}

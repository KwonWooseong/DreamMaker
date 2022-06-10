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
    int count;
    int orderMax;

    public bool isLockedOn;
    public Text countTxt;

    public List<int> orderList;
    public List<string> staff;

    public GameObject order;

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
        OpenAndCloseOrder();
        AcceptOrder();
        StartCoroutine(GetOrder()); 
        StartCoroutine(AcceptCount());
    }

    void OpenAndCloseOrder()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (activated == false)
            {
                activated = true;
                order.SetActive(true);
            }
            else
            {
                activated = false;
                order.SetActive(false);
            }
        }
    }

    void AcceptOrder()
    {   //주문이 들어온상태에서 E를 누르면 주문을 수락
        if (isOrdered && Input.GetKeyDown(KeyCode.E))
        {
            //미구현
            for (int i = 0; i < 4; i++)
            {
                //if(GameObject.Find("Staff/Staff_" + Player.instance.cameraName.Substring(7,2) + "_" + i).)
            }

            //개선필요
            for (int i = 0; i < orderList.Count;)
            {
                orderList.Remove(orderList[i]);
            }


            countTxt.text = "";
            //메리트 부여 미구현
            isCounting = false;
            isOrdered = false;
            isAccepted = true;
        }
    }

    IEnumerator GetOrder()
    {   //비주문상태인 경우 주문상태로 전환 후 몇초후 주문이 들어옴
        if (!isOrdered)
        {
            isOrdered = true;
            yield return new WaitForSeconds(Random.Range(5,10));

            int orderNum = Random.Range(orderMax / 2, orderMax);

            for(int i = 0; i < orderNum; i++)
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
            count = 21;
            countTxt.text = "new";

            while (isCounting)
            {
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

                    //패널티 부여 미구현
                    isAccepted = true;
                    isOrdered = false;
                    isCounting = false;
                }
            }
        }
    }
}

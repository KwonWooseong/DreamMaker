using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[] keyword = new string[25]
    {   // 키워드를 string으로 사용할때 GameManager 참조
        "개", "고양이", "벌", "뱀", "거미",
        "민트초코", "두리안", "오이", "땅콩", "우유",
        "인형", "라이터", "열쇠", "야구방망이", "사다리",
        "요리사", "의사", "변호사", "경찰", "광대",
        "카페", "공원", "바다", "산", "광장"
    };

    public int xLimit = 3;  //min 1, max 9
    public int zLimit = 2;
    public int success = 0;
    public int fail = 0;
    public int emotionMin = 100;
    public int emotionMax = 150;
    public int dreamKeywordMax = 10;
    public int keywordMax = 10;
    public int deltaEmotionMin = 5;
    public int deltaEmotionMax = 10;

    public float makeTime = 5.0f;
    public float restTime = 5.0f;


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
    {   //최대 방 수에 맞춰서 방 생성
        for(int j = 0; j < zLimit; j++) 
        {
            for(int i = 0; i < xLimit; i++)
            {
                //Debug.Log("factory spawn!");

                GameObject factoryObj = Instantiate(factory);
                
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

    public void PlusDream(int dreams)
    {
        success += dreams;
    }

    public void MinusDream(int dreams)
    {
        fail += dreams;
    }
}

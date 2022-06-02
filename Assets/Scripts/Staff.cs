using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    int emotion, emotionMax, deltaEmotionMin, deltaEmotionMax,
        keywordMax, tempkeywordMax, dreamKeywords, dreamKeywordMax;
    float makeTime, restTime;

    public bool canSleep = false;

    public List<int> keywordLike = new List<int>();
    public List<int> keywordHate = new List<int>();
    public List<int> dreamKeyword = new List<int>();

    // Start is called before the first frame update
    void Start()
    {   //GameManager의 변수로 Staff초기화, RandomKeyword() 실행
        emotionMax = Random.Range(GameManager.instance.emotionMin, GameManager.instance.emotionMax);
        emotion = Random.Range((int)(emotionMax * 0.3), (int)(emotionMax * 0.7));

        deltaEmotionMin = GameManager.instance.deltaEmotionMin;
        deltaEmotionMax = GameManager.instance.deltaEmotionMax;

        makeTime = GameManager.instance.makeTime;
        restTime = GameManager.instance.restTime;
        dreamKeywordMax = GameManager.instance.dreamKeywordMax;

        RandomKeyword();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MakeDream());
    }

    void RandomKeyword()
    {   //먼저 최대 키워드의 수, 선호 키워드의 수를 결정
        keywordMax = Random.Range(GameManager.instance.keywordMax / 2, GameManager.instance.keywordMax);
        int likes = Random.Range(2, keywordMax);
        tempkeywordMax = keywordMax;

        for (int i = 0; i < keywordMax; i++)
        {   //무작위로 i번째 임시 키워드를 생성
            int tempkeyword = Random.Range(0, GameManager.instance.keyword.Length);

            //만약 i가 선호 키워드수보다 작다면
            if (i < likes)
            {   //이미 선호키워드리스트에 있으면 중복을 제거후 임시 최대 키워드수를 감소
                //아니면 선호키워드리스트에 추가
                if (!keywordLike.Contains(tempkeyword)) keywordLike.Add(tempkeyword);
                else tempkeywordMax--;
            }
            else
            {
                if (keywordLike.Contains(tempkeyword))
                {   //이미 선호키워드리스트에 있으면 양쪽 제거후 임시 최대 키워드수를 2감소
                    //이미 불호키워드리스트에 있으면 중복을 제거후 임시 최대 키워드수를 감소
                    //아니면 불호키워드리스트에 추가
                    tempkeywordMax -= 2;
                    keywordLike.Remove(tempkeyword);
                }
                else if (!keywordHate.Contains(tempkeyword)) keywordHate.Add(tempkeyword);
                else tempkeywordMax--;
            }
            keywordMax = tempkeywordMax;
        }
    }
    IEnumerator MakeDream()
    {   //수면가능상태일때 
        if (canSleep)
        {   //꿈키워드가 없다면 꿈키워드를 생성
            if (dreamKeyword.Count == 0)
            {

            }
            //만약 꿈키워드가 있다면 바로 꿈 제작
            yield return new WaitForSeconds(dreamKeyword.Count * makeTime);
            int dreams = 0;

            //
            for (int i = 0; i < dreamKeyword.Count; i++)
            {   //만약 꿈의 키워드가 선호, 불호 키워드에 있다면 감정 변화
                //꿈 생산량을 증가시키고 리스트에서 제거
                if (keywordLike.Contains(dreamKeyword[0])) emotion += Random.Range(deltaEmotionMin, deltaEmotionMax);
                else if (keywordHate.Contains(dreamKeyword[0])) emotion -= Random.Range(deltaEmotionMin, deltaEmotionMax);
                dreams++;
                dreamKeyword.Remove(dreamKeyword[0]);
            }

            //변화된 최종 감정의 비율에 따라서 생산량을 배분
            // 0%~20%, 80%~100% 전부 실패
            // 20%~40%, 60%~80% 반 성공 반 실패
            // 40%~60% 전부 성공
            float emotionRate = (float)emotion / (float)emotionMax;
            if (emotionRate < 0.2 || emotionRate > 0.8) GameManager.instance.MinusDream(dreams);
            else if (emotionRate >= 0.4 && emotionRate <= 0.6) GameManager.instance.PlusDream(dreams);
            else
            {
                GameManager.instance.PlusDream(dreams / 2);
                GameManager.instance.MinusDream(dreams / 2);
            }
        }

        //휴식시간 경과후 수면가능상태로 전환
        yield return new WaitForSeconds(restTime);
        canSleep = true;
    }

    public void Info()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "blue")
        {

        }

        if(other.tag == "red")
        {

        }
    }
}

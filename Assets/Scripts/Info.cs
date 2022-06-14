using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    float emotionRate;

    public int emotion = 1;
    public int emotionMax = 1;
    public string[] like = new string[7];
    public string[] hate = new string[7];

    public Text[] likeTxt = new Text[7];
    public Text[] hateTxt = new Text[7];
    public Slider emotionBar;
    public Image fill;

    public static Info instance;

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
        emotionRate = (float)emotion / (float)emotionMax;
        emotionBar.minValue = 0;
        emotionBar.maxValue = emotionMax;
        emotionBar.value = emotion;

        if(emotionRate < 0.2)
        {
            fill.color = Color.red;
        }
        else if(emotionRate > 0.8)
        {
            fill.color = Color.green;
        }
        else if(emotionRate >= 0.2 && emotionRate < 0.4)
        {
            fill.color = new Color(127, 255, 0);
        }
        else if (emotionRate > 0.6 && emotionRate <= 0.8)
        { 
            fill.color = new Color(255, 127, 0);
        }
        else
        {
            fill.color = Color.yellow;
        }

        for (int i = 0; i < 7; i++)
        {
            likeTxt[i].text = like[i];
            hateTxt[i].text = hate[i];
        }
    }
}

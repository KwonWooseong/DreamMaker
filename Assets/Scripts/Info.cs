using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public int emotion, emotionMax;
    float emotionRate;
    public string[] like = new string[7];
    public string[] hate = new string[7];

    public Text[] likeTxt = new Text[7];
    public Text[] hateTxt = new Text[7];

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
        for (int i = 0; i < 7; i++)
        {
            //likeTxt[i].text = like[i];
            //hateTxt[i].text = hate[i];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float  countDownLifeTime;
    public Text countDownText;
    // Start is called before the first frame update
    void Start()
    {
        countDownLifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countDownLifeTime -= Time.unscaledDeltaTime;
        /*
        if(countDownLifeTime >= 3 && countDownLifeTime < 4)
        {
            countDownText.text = "3";
        }
        if(countDownLifeTime >= 2 && countDownLifeTime < 3)
        {
            countDownText.text = "2";
        }
        if(countDownLifeTime >= 1 && countDownLifeTime < 2)
        {
            countDownText.text = "1";
        }
        
        if(countDownLifeTime >= 0 && countDownLifeTime < 1)
        {
            countDownText.text = "はじめ！";
        }
        */
        if(countDownLifeTime >= 0.5 && countDownLifeTime < 1)
        {
            countDownText.text = "よーい";
        }
        if(countDownLifeTime >= 0 && countDownLifeTime < 0.5)
        {
            countDownText.text = "はじめ！";
        }
        if(countDownLifeTime < 0)
        {
            GameSystemTrick.instance.StartGame();
            gameObject.SetActive(false);
        }
    }
}

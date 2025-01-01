using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StaminaManager : MonoBehaviour
{
    /*
    public int stamina;
    public TimeSpan recoverySpan;
    public TimeSpan lastRecoverySpan;
    public DateTime recoveryStartTime;
    // Start is called before the first frame update
    void Start()
    {
        stamina = PlayerPrefs.GetInt("Stamina", 10);
        recoverySpan =  TimeSpan.Parse(PlayerPrefs.GetString("recoverySpan", new TimeSpan(0, 0, 0).ToString()));
    }

    // Update is called once per frame
    void Update()
    {   
        recoverySpan -= 
        // Debug.Log(stamina);
        Debug.Log(DateTime.Now);
    }

    public void ConsumeStamina(int cost)
    {
        stamina -= cost;
        PlayerPrefs.SetInt("Stamina", stamina);
        recoverySpan = cost * new TimeSpan(0, 10, 0);
        lastRecoverySpan = TimeSpan.Parse(PlayerPrefs.GetString("recoverySpan", new TimeSpan(0, 0, 0).ToString()));
        recoverySpan += lastRecoverySpan; 
        PlayerPrefs.SetString("RecoverSpan", recoverySpan);
    }
    */

    /*
    // スタミナは5
    public int maxStamina;
    public int currentStamina;
    // 今まで守った自然が多いほどスタミナが多くなる
    public int naturePoint;
    public Text naturePointText;
    public GameObject naturePointGage;
    public int needNaturePoint;
    public int level;
    public TimeSpan recoverSpan;
    public DateTime recoverStartTime;
    public float pastTime; 
    public bool recoverFlg;

    void Start()
    {
        // test
        recoverSpan = new TimeSpan(0, 10, 0);
        recoverStartTime = DateTime.Now - new TimeSpan(0, 9, 50);
        PlayerPrefs.SetString("RecoverSpan", recoverSpan.ToString());
        PlayerPrefs.SetString("RecoverStartTime", recoverStartTime.ToString());
        PlayerPrefs.SetInt("CurrentStamina", 0);
        StartRecoverStamina();
        //--test
        CheckLevelUp();
        LoginCheckStamina();
        UpdateStaminaUI();
        
    }

    void Update()
    {
        if(recoverFlg)
        {
            CheckStamina();
        }
        
    }

    public void CheckLevelUp()
    {
        maxStamina = PlayerPrefs.GetInt("MaxStamina", 1);
        naturePoint = PlayerPrefs.GetInt("NaturePoint", 0);
        level = PlayerPrefs.GetInt("Level", 1);
        needNaturePoint = PlayerPrefs.GetInt("NeedNaturePoint", 100);
        if(needNaturePoint > naturePoint)
        {
            return;
        }
        level++;
        needNaturePoint += level * 100;
        maxStamina++;
        PlayerPrefs.SetInt("MaxStamina", maxStamina);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("NeedNaturePoint", needNaturePoint);
        CheckLevelUp();
    }

    // 一度走りにいくと1スタミナがへる
    public void ToRun()
    {
        currentStamina--;
        StartRecoverStamina();
        
    }

    // ログイン時にチェック
    public void LoginCheckStamina()
    {
        currentStamina = PlayerPrefs.GetInt("CurrentStamina", currentStamina);
        recoverSpan = TimeSpan.Parse(PlayerPrefs.GetString("RecoverSpan", (new TimeSpan(0, 0, 0)).ToString()));
        recoverStartTime = DateTime.Parse(PlayerPrefs.GetString("RecoverStartTime", DateTime.Now.ToString()));
        recoverSpan -= DateTime.Now - recoverStartTime;
        while(recoverSpan > new TimeSpan(0, 10, 0))
        {
            recoverSpan -= new TimeSpan(0, 10, 0);
            currentStamina++;
        }
        PlayerPrefs.SetInt("CurrentStamina", currentStamina);
        PlayerPrefs.SetString("RecoverSpan", recoverSpan.ToString());
        PlayerPrefs.SetString("RecoverStartTime", DateTime.Now.ToString());
    }

    public void CheckStamina()
    {

        currentStamina = PlayerPrefs.GetInt("CurrentStamina", currentStamina);
        recoverSpan = TimeSpan.Parse(PlayerPrefs.GetString("RecoverSpan", (new TimeSpan(0, 0, 0)).ToString()));
        recoverStartTime = DateTime.Parse(PlayerPrefs.GetString("RecoverStartTime", DateTime.Now.ToString()));
        if(currentStamina >= maxStamina)
        {
            return;
        }
        pastTime += Time.deltaTime;
        if(pastTime > 1)
        {
            recoverSpan -= new TimeSpan(0, 0, 1);//DateTime.Now - recoverStartTime;
            pastTime = 0;
        }
        int differenceStamina = maxStamina - currentStamina;
        if(recoverSpan < new TimeSpan(0, 10 * differenceStamina, 0) && recoverSpan > new TimeSpan(0, 10, 0) )
        {
            currentStamina++;
            Debug.Log("aaa");
        }
        if(recoverSpan <= new TimeSpan(0, 0, 0))
        {
            currentStamina++;
            Debug.Log("bbb");
            EndRecoverStamina();
        }
        PlayerPrefs.SetInt("CurrentStamina", currentStamina);
        PlayerPrefs.SetString("RecoverSpan", recoverSpan.ToString());
        PlayerPrefs.SetString("RecoverStartTime", DateTime.Now.ToString());
        
    }

    // スタミナが減ったらそこから10分おきに1回復する
    public void RecoverStamina()
    {

        currentStamina++;
    }

    public void StartRecoverStamina()
    {
        recoverSpan = TimeSpan.Parse(PlayerPrefs.GetString("RecoverSpan", (new TimeSpan(0, 0, 0)).ToString()));
        recoverSpan += new TimeSpan(0, 10, 0);
        PlayerPrefs.SetString("RecoverSpan", recoverSpan.ToString());
        PlayerPrefs.SetString("RecoverStartTime", DateTime.Now.ToString());
        PlayerPrefs.SetInt("CurrentStamina", currentStamina);
        pastTime = 0;
        recoverFlg = true;

    }

    public void EndRecoverStamina()
    {
        pastTime = 0;
        recoverFlg = false;
    }
    // 途中でまた減るとその分追加されるう


    // 動画を見ると全回復する
    public void FullRecoverStamina()
    {
        AdsManager.instance.PlayAd();
        currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    // UIを更新する
    public void UpdateStaminaUI()
    {
        currentStamina = PlayerPrefs.GetInt("CurrentStamina", 5);
    }
    */


}

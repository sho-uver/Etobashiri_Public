using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class UpbringingSystem : MonoBehaviour
{
    public GameObject statusCanvas;
    public int levelPoint;
    public int levelSpeedUp;
    public int levelSpeedDown;
    public int sweetSpotRange;
    public int enemyLifeTime;
    public int life;
    public int chototsuLevelPoint;
    public Text levelPointText;
    public Text levelSpeedUpText;
    public Text levelSpeedDownText;
    public Text sweetSpotRangeText;
    public Text enemyLifeTimeText;
    public Text lifeText;
    public Text chototsuLevelPointText;
    public float upDownTimeLong;
    public float upDownTimeShort;
    public bool upFlg;

    public GameObject chototsuCanvas;
    


    // Start is called before the first frame update
    void Start()
    {
        levelPoint = PlayerPrefs.GetInt("levelPoint", 0);
        levelSpeedUp = PlayerPrefs.GetInt("UpSpeed", 0);
        levelSpeedDown = PlayerPrefs.GetInt("DownSpeed", 0);
        sweetSpotRange = PlayerPrefs.GetInt("SweetSpotRange", 0);
        enemyLifeTime = PlayerPrefs.GetInt("BlowLifeTime",0);
        life = PlayerPrefs.GetInt("RestLife",0);
        chototsuLevelPoint = PlayerPrefs.GetInt("ChototsuLevelPoint",0);
        levelPointText.text = levelPoint.ToString();
        // levelSpeedUpText.text = levelSpeedUp.ToString();
        levelSpeedDownText.text = levelSpeedDown.ToString();
        sweetSpotRangeText.text = sweetSpotRange.ToString();
        enemyLifeTimeText.text = enemyLifeTime.ToString();
        lifeText.text = life.ToString();
        chototsuLevelPointText.text = chototsuLevelPoint.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!upFlg)
        {
            return;
        }
        upDownTimeLong += Time.deltaTime;
        if(upDownTimeLong < 1)
        {
            return;
        }
        upDownTimeShort += Time.deltaTime;
        if(upDownTimeShort < 0.05f)
        {
            return;
        }
        
        switch(name)
        {
            case "LevelPointUp":
                LevelPointUp();
                break;
            case "LevelPointDown":
                LevelPointDown();
                break;
            case "LevelSpeedDownUp":
                LevelSpeedDownUp();
                break;
            case "LevelSpeedDownDown":
                LevelSpeedDownDown();
                break;
            case "SweetSpotRangeUp":
                SweetSpotRangeUp();
                break;
            case "SweetSpotRangeDown":
                SweetSpotRangeDown();
                break;
            case "EnemyLifeTimeUp":
                EnemyLifeTimeUp();
                break;
            case "EnemyLifeTimeDown":
                EnemyLifeTimeDown();
                break;

            case "LifeUp":
                LifeUp();
                break;
            case "LifeDown":
                LifeDown();
                break;
            case "ChototsuLevelPointUp":
                ChototsuLevelPointUp();
                break;
            case "ChototsuLevelPointDown":
                ChototsuLevelPointDown();
                break;

                
                
            
        }
        upDownTimeShort = 0;
    }

    public void ResetPoint()
    {
        levelPoint = 0;
        levelSpeedUp = 0;
        levelSpeedDown = 0;
        sweetSpotRange = 0;
        enemyLifeTime = 0;
        life = 0;
        chototsuLevelPoint = 0;
        levelPointText.text = levelPoint.ToString();
        // levelSpeedUpText.text = levelSpeedUp.ToString();
        levelSpeedDownText.text = levelSpeedDown.ToString();
        sweetSpotRangeText.text = sweetSpotRange.ToString();
        enemyLifeTimeText.text = enemyLifeTime.ToString();
        lifeText.text = life.ToString();
        chototsuLevelPointText.text = chototsuLevelPoint.ToString();
        PlayerPrefs.SetInt("levelPoint", levelPoint);
        PlayerPrefs.SetInt("UpSpeed", levelSpeedUp);
        PlayerPrefs.SetInt("DownSpeed", levelSpeedDown);
        PlayerPrefs.SetInt("SweetSpotRange", sweetSpotRange);
        PlayerPrefs.SetInt("BlowLifeTime",enemyLifeTime);
        PlayerPrefs.SetInt("RestLife",life);
        PlayerPrefs.SetInt("ChototsuLevelPoint",chototsuLevelPoint);
    }

    public void StatusCanvas()
    {
        statusCanvas.SetActive(true);
        chototsuCanvas.SetActive(false);
    }

    public void ChotosuCanvas()
    {
        statusCanvas.SetActive(false);
        chototsuCanvas.SetActive(true);
        
    }

    public void ChangeStatus()
    {
        /*
        public int levelPoint;
        public int levelSpeedUp;
        public int levelSpeedDown;
        public int sweetSpotRange;
        public int enemyLifeTime;
        public int life;
        public int chototsuLevelPoint;

        levelSpeedUp = PlayerPrefs.GetFloat("UpSpeed",0f) * 0.03f;
        levelSpeedDown = 1 - PlayerPrefs.GetFloat("DownSpeed",0f) * 0.1f * 0.01f;
        levelPoint = Mathf.FloorToInt(PlayerPrefs.GetFloat("levelPoint", 0f));
        lifeTime = PlayerPrefs.GetInt("BlowLifeTime",0) * 0.1f;
        restLife = Mathf.FloorToInt(PlayerPrefs.GetInt("RestLife",0) / 50);
        liberationPatten = PlayerPrefs.GetString("Skill", "Chototsumoshin");
        chototsuLevelPoint = PlayerPrefs.GetInt("ChototsuLevelPoint",0);
        */
        PlayerPrefs.SetInt("levelPoint", levelPoint);
        PlayerPrefs.SetInt("UpSpeed", levelSpeedUp);
        PlayerPrefs.SetInt("DownSpeed", levelSpeedDown);
        PlayerPrefs.SetInt("SweetSpotRange", sweetSpotRange);
        PlayerPrefs.SetInt("BlowLifeTime",enemyLifeTime);
        PlayerPrefs.SetInt("RestLife",life);
        PlayerPrefs.SetInt("ChototsuLevelPoint",chototsuLevelPoint);

    }

    public void UpFlgFalse()
    {
        upFlg = false;
        upDownTimeLong = 0;
        upDownTimeShort = 0;
    }

    public void LevelPointUp()
    {
        levelPoint++;
        levelSpeedUp++;
        levelPointText.text = levelPoint.ToString();
        // levelSpeedUpText.text = levelSpeedUp.ToString();
        PlayerPrefs.SetInt("levelPoint", levelPoint);
        PlayerPrefs.SetInt("UpSpeed", levelSpeedUp);
        upFlg = true;
        name = "LevelPointUp";
    }

    public void LevelPointDown()
    {
        levelPoint--;
        levelSpeedUp--;
        levelPointText.text = levelPoint.ToString();
        // levelSpeedUpText.text = levelSpeedUp.ToString();
        PlayerPrefs.SetInt("levelPoint", levelPoint);
        PlayerPrefs.SetInt("UpSpeed", levelSpeedUp);
        upFlg = true;
        name = "LevelPointDown";
    }

    public void LevelSpeedDownUp()
    {
        levelSpeedDown++;
        levelSpeedDownText.text = levelSpeedDown.ToString();
        PlayerPrefs.SetInt("DownSpeed", levelSpeedDown);
        upFlg = true;
        name = "LevelSpeedDownUp";
    }
    public void LevelSpeedDownDown()
    {
        levelSpeedDown--;
        levelSpeedDownText.text = levelSpeedDown.ToString();
        PlayerPrefs.SetInt("DownSpeed", levelSpeedDown);
        upFlg = true;
        name = "LevelSpeedDownDown";
    }

    public void SweetSpotRangeUp()
    {
        sweetSpotRange++;
        sweetSpotRangeText.text = sweetSpotRange.ToString();
        PlayerPrefs.SetInt("SweetSpotRange", sweetSpotRange);
        upFlg = true;
        name = "SweetSpotRangeUp";
    }

    public void SweetSpotRangeDown()
    {
        sweetSpotRange--;
        sweetSpotRangeText.text = sweetSpotRange.ToString();
        PlayerPrefs.SetInt("SweetSpotRange", sweetSpotRange);
        upFlg = true;
        name = "SweetSpotRangeDown";
    }

    public void EnemyLifeTimeUp()
    {
        enemyLifeTime++;
        enemyLifeTimeText.text = enemyLifeTime.ToString();
        PlayerPrefs.SetInt("BlowLifeTime",enemyLifeTime);
        upFlg = true;
        name = "EnemyLifeTimeUp";
    }

    public void EnemyLifeTimeDown()
    {
        enemyLifeTime--;
        enemyLifeTimeText.text = enemyLifeTime.ToString();
        PlayerPrefs.SetInt("BlowLifeTime",enemyLifeTime);
        upFlg = true;
        name = "EnemyLifeTimeDown";
    }

    public void LifeUp()
    {
        life++;
        lifeText.text = life.ToString();
        PlayerPrefs.SetInt("RestLife",life);
        upFlg = true;
        name = "LifeUp";
    }

    public void LifeDown()
    {
        life--;
        lifeText.text = life.ToString();
        PlayerPrefs.SetInt("RestLife",life);
        upFlg = true;
        name = "LifeDown";
    }

    public void ChototsuLevelPointUp()
    {
        chototsuLevelPoint++;
        chototsuLevelPointText.text = chototsuLevelPoint.ToString();
        PlayerPrefs.SetInt("ChototsuLevelPoint",chototsuLevelPoint);
        upFlg = true;
        name = "ChototsuLevelPointUp";
    }

    public void ChototsuLevelPointDown()
    {
        chototsuLevelPoint--;
        chototsuLevelPointText.text = chototsuLevelPoint.ToString();
        PlayerPrefs.SetInt("ChototsuLevelPoint",chototsuLevelPoint);
        upFlg = true;
        name = "ChototsuLevelPointDown";
    }

    

    

    public void Deka()
    {
        PlayerPrefs.SetString("Skill", "Deka");
    }

    public void Mure()
    {
        PlayerPrefs.SetString("Skill", "Mure");
    }

}

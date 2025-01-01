using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float enemyPeriodTime;
    public float enemyElapsedTime;
    public Text meter;
    public Text speed;
    public GameObject gate;
    public float gatePeriodTime;
    public float gateElapsedTime;
    public static GameSystem instance;
    public float gearUpMeter;
    public GameObject road1;
    public GameObject road2;
    public GameObject road3;
    public float num;
    public Text restLifeText;
    public int restLife;
    public Image chototsuGageImage;
    public float fillChototsuGage;
    public float maxChototsuGage;
    public GameObject cleaner;
    public GameObject mainCamera;
        // アイテム出現タイムの変数を作成する。UpdateでTime.deltaTimeを追加していく。
    [SerializeField]
    private float itemAppearTime;
    [SerializeField]
    private float itemChargeTime;

    private int highScore;
    private int currentScore;
    public GameObject resultCanvas;
    public Text highScoreText;
    public Text currentScoreText;
    public GameObject runCanvas;
    public GameObject adsCanvas;
    public bool chototsuFlg;
    public GameObject liberationPower;
    public string liberationPatten;
    public GameObject mure;
    public GameObject drawLine;
    public DrawLine drawlineComponent;
    public int bokujuCount;
    public Text bokujuCountText;



    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // AWSの処理
        // UnityInitializer.AttachToGameObject(this.gameObject);
        Application.targetFrameRate = 60; 
        ReStart();
        restLifeText.text = "×" + restLife;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        // AdsManager.instance.HideBanner();
        // adsCanvas.GetComponent<AdsManager>().HideBanner();
        // liberationPatten = "Chototsumoshin";
        drawlineComponent = drawLine.GetComponent<DrawLine>();
        liberationPatten = PlayerPrefs.GetString("Skill", "Chototsumoshin");
        bokujuCountText.text = "✖︎" + bokujuCount;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        num += Time.deltaTime;
        player.SetActive(false);
        if(num > 10)
        {
            // player.enabled = true;
            player.SetActive(true);
            // player.GetComponent<Player>().Update();
            if(num > 20)
            {
                player.SetActive(false);
                num = 0;
            }
        }
        */
        
        /*
        // 敵を出す処理
        if (enemyPeriodTime < enemyElapsedTime)
        {
            Instantiate(enemy, new Vector2(Random.Range(-2.0f,2.0f), player.transform.position.y + 19.2f), Quaternion.identity);
            enemyPeriodTime = Random.Range(1f, 2.0f);
            enemyElapsedTime = 0;
        }
        enemyElapsedTime += Time.deltaTime;

        // 鳥居を出す処理
        if (gatePeriodTime < gateElapsedTime)
        {
            Instantiate(gate, new Vector2(Random.Range(-2.0f,2.0f), player.transform.position.y + 19.2f), Quaternion.identity);
            gatePeriodTime = Random.Range(10f, 15.0f);
            gateElapsedTime = 0;
        }
        gateElapsedTime += Time.deltaTime;
        */

        // 距離を表示する処理
        meter.text = Mathf.RoundToInt(player.transform.position.y) + "間";
        speed.text = Player.instance.gear.ToString();
        if(player.transform.position.y > gearUpMeter)
        {
            GearUp();
        }
        itemChargeTime += Time.deltaTime;
        if(itemChargeTime > itemAppearTime)
        {
            ActiveItemAppearFlg();
        }

        if(Input.GetKeyDown("t"))
        {
            Muteki();
        }
    }

    public void ActiveItemAppearFlg()
    {
        road1.GetComponent<Road>().ActiveItemAppearFlg();
        road2.GetComponent<Road>().ActiveItemAppearFlg();
        road3.GetComponent<Road>().ActiveItemAppearFlg();
        itemChargeTime = 0;
    }

    public void InActiveItemAppearFlg()
    {
        road1.GetComponent<Road>().InActiveItemAppearFlg();
        road2.GetComponent<Road>().InActiveItemAppearFlg();
        road3.GetComponent<Road>().InActiveItemAppearFlg();
    }

    public void GearUp()
    {
        Player.instance.gear++;
        road1.GetComponent<Road>().GearUp();
        road2.GetComponent<Road>().GearUp();
        road3.GetComponent<Road>().GearUp();
        if(gearUpMeter == 100)
        {
            gearUpMeter = 500;
        }
        else if(gearUpMeter == 500)
        {
            gearUpMeter = 1000;
        }
        else if(gearUpMeter == 1000)
        {
            gearUpMeter = 2000;
        }
        else if(gearUpMeter == 2000)
        {
            gearUpMeter = 3000;
        }
        else if(gearUpMeter == 3000)
        {
            gearUpMeter = 4000;
        }
        else if(gearUpMeter == 4000)
        {
            gearUpMeter = 5000;
        }
        else if(gearUpMeter == 5000)
        {
            gearUpMeter = 10000;
        }
        else if(gearUpMeter == 10000)
        {
            gearUpMeter = 25000;
        }
        else if(gearUpMeter == 25000)
        {
            gearUpMeter = 40075;
        }
        else if(gearUpMeter == 40075)
        {
            gearUpMeter = 999999;
            GameClear();
        }
    }

    public void ReStart()
    {
        // SceneManager.LoadScene("Main");
        // SceneChanger.instance.ChangeMain();
        Time.timeScale = 1f;
    }



    public void GameClear()
    {
        Time.timeScale = 0f;
    }

    public void GetLifeThread()
    {
        restLife++;
        restLifeText.text = "×" + restLife.ToString();
    }

    public void LostLife(int damage)
    {
        restLife -= damage;
        restLifeText.text = "×" + restLife;
        if(restLife == 0)
        {
            Result();
            // ReStart();
        }
    }

    public void GetTori(string name)
    {
        if(name == "Tori" && !chototsuFlg)
        {
            fillChototsuGage += 10;
        }
        else if(name == "Tori" && chototsuFlg)
        {
            fillChototsuGage += 5;
        }
        else if(name == "ShiroTori")
        {
            fillChototsuGage += 100;
        }
        chototsuGageImage.fillAmount = fillChototsuGage / maxChototsuGage;
        if(chototsuGageImage.fillAmount >= 1)
        {
            chototsuFlg = true;
            StartChototsumoshin();
        }
    }

    public void MakeLiberationPower()
    {
        if (!chototsuFlg)
        {
            return;
        }
        fillChototsuGage -= 100;
        chototsuGageImage.fillAmount = fillChototsuGage / maxChototsuGage;
        if(chototsuGageImage.fillAmount < 1)
        {
            chototsuFlg = false;
        }
        Vector2 liberationPowerPos = new Vector2(Random.Range(-2.1f,2.1f), player.transform.position.y + 19.2f);
        Instantiate(liberationPower, liberationPowerPos , transform.rotation);
    }

    public void StartChototsumoshin()
    {
        fillChototsuGage -= 100;
        chototsuGageImage.fillAmount = fillChototsuGage / maxChototsuGage;
        switch(liberationPatten)
        {
            case "Chototsumoshin":
                player.GetComponent<Player>().Chototsumoshin(7);
                cleaner.GetComponent<Cleaner>().Chototsumoshin();
                mainCamera.GetComponent<MainCamera>().Chototsumoshin();
                chototsuGageImage.fillAmount = fillChototsuGage / maxChototsuGage;
                break;

            case "Mure":
                Vector3 murePos = player.transform.position;
                murePos.y = murePos.y + 5;
                Instantiate(mure, murePos, transform.rotation);
                EndChototsumoshin();
                break;

            case "Hogeki":
                drawlineComponent.HogekiCountUp();
                EndChototsumoshin();
                break;
        }


    }

    public void EndChototsumoshin()
    {
        switch(liberationPatten)
        {
            case "Chototsumoshin":
                cleaner.GetComponent<Cleaner>().EndChototsumoshin();
                mainCamera.GetComponent<MainCamera>().EndChototsumoshin();
                chototsuFlg = false;
                break;

            case "Mure":
                chototsuFlg = false;
                break;
            
            case "Hogeki":
                chototsuFlg = false;
                break;
        }
        
    }

    public void Result()
    {
        Time.timeScale = 0f;
        runCanvas.SetActive(false);
        currentScore = Mathf.RoundToInt(player.transform.position.y);
        highScore = PlayerPrefs.GetInt("HighScore");
        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(player.transform.position.y));
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        highScoreText.text = highScore + "間";
        currentScoreText.text = currentScore + "間";
        resultCanvas.SetActive(true);
    }

    public void Critical()
    {
        drawlineComponent.BokujuCountUp(1);
    }

    public void SetBokujuCount(int count)
    {
        bokujuCount = count;
        bokujuCountText.text = "✖︎" + bokujuCount;
    }

    public void GetHude()
    {
        drawlineComponent.BokujuCountUp(30);
    }

    public void Muteki()
    {
        restLife = 100000;
    }





}

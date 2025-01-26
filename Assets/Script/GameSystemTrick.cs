using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using System.IO;
using TMPro;
using UnityEngine.Localization.Settings;

public class GameSystemTrick : MonoBehaviour
{
    public static GameSystemTrick instance;
    // const string STATISTICS_NAME = "Mugen_ver2.0";
    const string STATISTICS_NAME = "Mugen_ver2.1";
    const string versionPlayCount = "PlayCount_ver2.1";
    public GameObject enemy;
    public GameObject player;
    public float enemyPeriodTime;
    public float enemyElapsedTime;
    public Text meter;
    public Text speed;
    public GameObject gate;
    public float gatePeriodTime;
    public float gateElapsedTime;
    public float gearUpMeter;
    public GameObject road1;
    public GameObject road2;
    public GameObject road3;
    public float num;
    public Text restLifeText;
    public int restLife;
    public Image chototsuGageImage;
    public Slider chototsuGageSlider;
    public float fillChototsuGage;
    public float maxChototsuGage;
    public GameObject cleaner;
    public Cleaner cleanerScript;
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
    public Text highScoreText2;
    public Text highScoreText3;
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
    public int bomPoint;
    public int bonusPoint;
    // public string ranking;
    public GameObject camera;
    public MainCamera mCScript;
    public GameObject goal;
    public GameObject startCanvas;
    public GameObject countDown;
    public GameObject blackCanvas;
    public int chototsuCount;
    public int chototsuLevelPoint;
    public GoogleMobileAdsDemoScript gad;
    public int stageLife;
    public bool mugenFlg;
    public GameObject bomber;
    public MugenRoad mRoad1;
    public MugenRoad mRoad2;
    public MugenRoad mRoad3;
    public int shiki;
    public int stageCounter;
    public int stageCounterAll;
    public GameObject bigTori;
    public Player ps;
    public Enemy es;
    public GameObject tori;
    public bool toriFlg;
    public float toriTime;
    public SceneChanger sc;
    public bool scFlg;
    public float scTime;
    public GoogleMobileAdsDemoScript gmads;
    public Text rankingText;
    public GameObject rankingSV;
    public Text bandukeText;
    public string message;
    public string message2;
    public string message3;
    public Text countDownText;
    public AudioSource lineAudio;
    public AudioSource missAudio;
    public int toriCounter;
    public bool startFlg;
    public GameObject stampRat;
    public GameObject stampCaw;
    public GameObject stampTiger;
    public GameObject stampRabbit;
    public GameObject stampDragon;
    public GameObject stampSnake;
    public GameObject stampHorse;
    public GameObject stampSheep;
    public GameObject stampMonkey;
    public GameObject stampBird;
    public GameObject stampDog;
    public GameObject stampMos;
    public GameObject stampTatsuzin;
    public GameObject stampSuper;
    public GameObject stampGod;
    public GameObject stampGokaku;
    public GameObject stampSatori;
    public GameObject stampKanso;
    public bool resultEffectFlg;
    public GameObject[] fireworkUI;
    public GameObject fireworkUI0;
    public GameObject fireworkUI1;
    public GameObject fireworkUIMini;
    public float resultEffectTime;
    public AudioSource resultAudio;
    public bool getHighScoreFlg;
    public bool lostLifeFlg;
    public float toriMeter;
    public string resultPattern;
    public GameObject manual;
    public GameObject manualCanvas;
    public GameObject movie;
    public GameObject vd1;
    public GameObject vd2;
    public GameObject vd3;
    public GameObject vd4;
    public GameObject vd5;
    public VideoPlayer vp;
    public GameObject movieBack;
    public GameObject movieGo;
    public GameObject moviePlay;
    public GameObject movieStop;
    public int etoNum;
    public GameObject stopBotton;
    public GameObject restartBotton;
    public GameObject retryBotton;
    public string stageName;
    public int levelPointMainus;
    public int levelPointTotal;
    public int altLevel;
    public int jokyoPoint;
    public GameObject nonbiriGate;
    public GameObject shunkashutoGate;
    public GameObject togenkyoGate;
    public Text stageNameText;
    public Text highScoreTextKanban;
    public Text levelText;
    public Text jokyoText;
    public Slider tokuSlider;
    public int altBonnoPoint;
    public Text resultGetPointText;
    public Text resultGetTokuText;
    // public int beforeLevel;
    public bool levelUpFlg;
    public float textChikaChikTime;
    public GameObject exitBotton;
    public AudioSource taikoAudio;
    public TwitterShare twitterShare;
    public LineShare lineShare;
    public PlusPoint plusPoint;
    public int prismCounter;
    public bool prismFlg;
    public string prismName;
    public GameObject demoCtrl;
    public int money;
    public int getMoney;
    public Text resultMoney;
    public SnapbarManager snapbarManager;
    public Sprite test;
    public Sprite test2;
    public Sprite test3;
    public int beforeLevel;
    public int afterLevel;
    public Sprite satoruImage;
    public Sprite bonnoImage;
    public Sprite enImage;
    public Sprite stamp1Image;
    public Sprite stamp2Image;
    public Sprite stamp3Image;
    public Sprite stamp4Image;
    public Sprite stamp5Image;
    public Sprite stamp6Image;
    public Sprite stamp7Image;
    public Sprite stamp8Image;
    public Sprite stamp9Image;
    public Sprite stamp10Image;
    public Sprite stamp11Image;
    public Sprite stamp12Image;
    public Sprite stamp13Image;
    public Sprite stamp14Image;
    public Sprite stamp15Image;
    public Sprite stamp16Image;
    public GameObject ruleView;
    public GameObject illustratedBookView;
    public int loginTry;
    public Sprite loginErrorImage;
    public bool shareFlg;
    public bool kansoFlg;
    public NGWordFilter ngWordFilter;

    private string tableName = "TextTable"; // Localizationテーブル名を指定

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        // Debug.developerConsoleVisible = true;
        // Debug.unityLogger.logEnabled = true;
        // Debug.Log(SceneManager.GetActiveScene().name);

        Application.targetFrameRate = 60;
        ReStart();
        /*初回ログインの処理
        if(PlayerPrefs.GetInt("FirstManual",0) == 0)
        {
            OpenManualCanvas();
            // Invoke("OpenMovie",0.02f);
            OpenMovie();
            PlayerPrefs.SetInt("FirstManual",1);
        }
        */
        // restLifeText.text = "×" + restLife;
        // highScore = PlayerPrefs.GetInt("HighScore");
        // AdsManager.instance.HideBanner();
        // adsCanvas.GetComponent<AdsManager>().HideBanner();
        // liberationPatten = "Chototsumoshin";

        restLife = stageLife + Mathf.FloorToInt(PlayerPrefs.GetInt("RestLife", 0) / 20);

        // restLife = 4;
        drawlineComponent = drawLine.GetComponent<DrawLine>();
        liberationPatten = PlayerPrefs.GetString("Skill", "Chototsumoshin");
        // liberationPatten = "Deka";
        bokujuCountText.text = "✖︎" + bokujuCount;
        camera = GameObject.FindWithTag("MainCamera");
        mCScript = camera.GetComponent<MainCamera>();
        goal = GameObject.FindWithTag("Goal");
        bokujuCountText.text = "✖︎" + restLife;
        startCanvas = GameObject.FindWithTag("StartCanvas");
        chototsuLevelPoint = PlayerPrefs.GetInt("ChototsuLevelPoint", 0);
        // chototsuLevelPoint = 100;
        // Time.timeScale = 0f;
        // blackCanvas = GameObject.FindWithTag("BlackCanvas");
        // BlackCanvasStart();
        gad = GetComponent<GoogleMobileAdsDemoScript>();
        mRoad1 = road1.GetComponent<MugenRoad>();
        mRoad2 = road2.GetComponent<MugenRoad>();
        mRoad3 = road3.GetComponent<MugenRoad>();
        shiki = 1;
        stageCounter = 1;
        stageCounterAll = 0;

        ps = player.GetComponent<Player>();
        scTime = 15;
        ps.SetGear(stageCounterAll);
        toriCounter = 1;
        ps.SetToriCounter(toriCounter);
        fireworkUI = new GameObject[2] { fireworkUI0, fireworkUI1 };
        stageName = SceneManager.GetActiveScene().name;
        beforeLevel = PlayerPrefs.GetInt("MugenLevel", 108);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startFlg)
        {
            return;
        }
        /*
        if(scFlg)
        {
            scTime -= Time.deltaTime;
            countDownText.text = Mathf.Ceil(scTime).ToString();
        }
        if(scTime <= 0)
        {
            sc.ChangeMugen();
            scTime = 0;
            countDownText.text = Mathf.Ceil(scTime).ToString();
        }
        */
        resultEffectTime -= Time.deltaTime;
        if (resultEffectFlg && resultEffectTime < 0f)
        {
            GameObject firework = Instantiate(fireworkUI[Random.Range(0, 2)], resultCanvas.GetComponent<Transform>().position + new Vector3(Random.Range(-300, 300), Random.Range(-800, 800), -2), transform.rotation);
            firework.GetComponent<Transform>().SetParent(resultCanvas.GetComponent<Transform>());
            resultEffectTime = Random.Range(0.1f, 1f);
        }
        if (getHighScoreFlg && resultEffectTime < 0f)
        {
            GameObject firework = Instantiate(fireworkUIMini, resultCanvas.GetComponent<Transform>().position + new Vector3(Random.Range(-300, 300), Random.Range(600, 800), -2), transform.rotation);
            firework.GetComponent<Transform>().SetParent(resultCanvas.GetComponent<Transform>());
            resultEffectTime = Random.Range(0.1f, 1f);
        }
        if (levelUpFlg && resultEffectTime < 0f)
        {
            GameObject firework = Instantiate(fireworkUIMini, resultCanvas.GetComponent<Transform>().position + new Vector3(Random.Range(-300, 300), Random.Range(600, 800), -2), transform.rotation);
            firework.GetComponent<Transform>().SetParent(resultCanvas.GetComponent<Transform>());
            resultEffectTime = Random.Range(0.1f, 1f);
        }
        if (getHighScoreFlg && textChikaChikTime < 0)
        {
            highScoreTextKanban.color = new Color(1, 0, 0, 0.5f);
            textChikaChikTime = 0.1f;
        }
        else if (getHighScoreFlg && textChikaChikTime >= 0)
        {
            highScoreTextKanban.color += new Color(1, 0, 0, 5f * Time.deltaTime);
            textChikaChikTime -= Time.deltaTime;
        }
        if (levelUpFlg && textChikaChikTime < 0)
        {
            levelText.color = new Color(1, 0, 0, 0.5f);
            textChikaChikTime = 0.1f;
        }
        else if (levelUpFlg && textChikaChikTime >= 0)
        {
            levelText.color += new Color(1, 0, 0, 5f * Time.deltaTime);
            textChikaChikTime -= Time.deltaTime;
        }

        // meter.text = bomPoint + "徳";
        /*
        if(Mathf.RoundToInt(goal.transform.position.y) - Mathf.RoundToInt(player.transform.position.y) < 0)
        {
            bokujuCountText.text = "到達！";
        }
        else
        {
            bokujuCountText.text = "あと" + (Mathf.RoundToInt(goal.transform.position.y) - Mathf.RoundToInt(player.transform.position.y)) + "m";
        }
        */

        // meter.text = Mathf.RoundToInt(player.transform.position.y) * 10 + bomPoint + "徳";
        /* speed.text = Player.instance.gear.ToString();
        if(player.transform.position.y > gearUpMeter)
        {
            GearUp();
        }

        itemChargeTime += Time.deltaTime;
        if(itemChargeTime > itemAppearTime)
        {
            ActiveItemAppearFlg();
        }
        */
        /*
        toriTime -= Time.deltaTime;
        if(toriTime < 0)
        {
            float toriTimeAlt = toriTime;
            toriTime = 90 + toriTime;
            toriFlg = true;
        }
        */

        if (toriMeter < player.transform.position.y)
        {
            if (PlayerPrefs.GetInt("完春夏秋冬並木", 0) == 1)
            {
                toriMeter += 1000 + toriCounter * 100 * 2 / 3;
            }
            else
            {
                toriMeter += 1000 + toriCounter * 100;
            }

            toriFlg = true;
        }
        if (player.transform.position.y - road1.transform.position.y > 19.2f)
        {
            MakeStage(road1, mRoad1);
            /*
            road1.transform.position += new Vector3(0,57.6f,0);
            mRoad1.MakeStageCast(1);

            
            Instantiate(bomber,road1.transform.position + new Vector3(0,0f,0), Quaternion.identity);
            Instantiate(bomber,road1.transform.position + new Vector3(0,2f,0), Quaternion.identity);
            Instantiate(bomber,road1.transform.position + new Vector3(0,4f,0), Quaternion.identity);
            Instantiate(bomber,road1.transform.position + new Vector3(0,6f,0), Quaternion.identity);
            Instantiate(bomber,road1.transform.position + new Vector3(0,8f,0), Quaternion.identity);
            Instantiate(bomber,road1.transform.position + new Vector3(0,10f,0), Quaternion.identity);
            Instantiate(bomber,road1.transform.position + new Vector3(0,12f,0), Quaternion.identity);
            Instantiate(bomber,road1.transform.position + new Vector3(0,14f,0), Quaternion.identity);
            Instantiate(bomber,road1.transform.position + new Vector3(0,16f,0), Quaternion.identity);
            */

        }
        if (player.transform.position.y - road2.transform.position.y > 19.2f)
        {
            MakeStage(road2, mRoad2);
            /*
            road2.transform.position += new Vector3(0,57.6f,0);
            mRoad2.MakeStageCast(1);
            
            Instantiate(bomber,road2.transform.position + new Vector3(0,0f,0), Quaternion.identity);
            Instantiate(bomber,road2.transform.position + new Vector3(0,2f,0), Quaternion.identity);
            Instantiate(bomber,road2.transform.position + new Vector3(0,4f,0), Quaternion.identity);
            Instantiate(bomber,road2.transform.position + new Vector3(0,6f,0), Quaternion.identity);
            Instantiate(bomber,road2.transform.position + new Vector3(0,8f,0), Quaternion.identity);
            Instantiate(bomber,road2.transform.position + new Vector3(0,10f,0), Quaternion.identity);
            Instantiate(bomber,road2.transform.position + new Vector3(0,12f,0), Quaternion.identity);
            Instantiate(bomber,road2.transform.position + new Vector3(0,14f,0), Quaternion.identity);
            Instantiate(bomber,road2.transform.position + new Vector3(0,16f,0), Quaternion.identity);
            */

        }
        if (player.transform.position.y - road3.transform.position.y > 19.2f)
        {
            MakeStage(road3, mRoad3);
            /*
            road3.transform.position += new Vector3(0,57.6f,0);
            mRoad3.MakeStageCast(1);
            
            Instantiate(bomber,road3.transform.position + new Vector3(0,0f,0), Quaternion.identity);
            Instantiate(bomber,road3.transform.position + new Vector3(0,2f,0), Quaternion.identity);
            Instantiate(bomber,road3.transform.position + new Vector3(0,4f,0), Quaternion.identity);
            Instantiate(bomber,road3.transform.position + new Vector3(0,6f,0), Quaternion.identity);
            Instantiate(bomber,road3.transform.position + new Vector3(0,8f,0), Quaternion.identity);
            Instantiate(bomber,road3.transform.position + new Vector3(0,10f,0), Quaternion.identity);
            Instantiate(bomber,road3.transform.position + new Vector3(0,12f,0), Quaternion.identity);
            Instantiate(bomber,road3.transform.position + new Vector3(0,14f,0), Quaternion.identity);
            Instantiate(bomber,road3.transform.position + new Vector3(0,16f,0), Quaternion.identity);
            */


        }
    }

    public void MakeStage(GameObject road, MugenRoad mRoad)
    {
        road.transform.position += new Vector3(0, 57.6f, 0);

        // Instantiate(bigTori,road.transform.position - new Vector3(0, -9.6f,0), Quaternion.identity);
        /*
        if(stageCounter == 0 && stageCounterAll == 0)
        {
            stageCounter = 4;
        }
        */
        stageCounter++;
        // stageCounterAll++;
        /*
        if(stageCounterAll % 100 == 0)
        {
            ps.SetGear(stageCounterAll /100);
        }
        */
        // if(bomPoint >= 1000 * toriCounter)// && !toriFlg)
        if (toriFlg)
        {
            mRoad.MakeTori();
            // ps.SetToriCounter(toriCounter);
            // toriCounter ++;
            toriFlg = false;
            toriCounter++;
            // Instantiate(tori,new Vector3(Random.Range(-2.5f,2.5f), road.transform.position.y,1), Quaternion.identity);
            // toriFlg = true;
        }
        if (prismFlg)
        {
            mRoad.MakePrism(prismName);
            prismFlg = false;
        }
        switch (shiki)
        {
            case 1:
                // if(stageCounter == 6 + stageCounterAll)
                // if(stageCounter == 4 + stageCounterAll)
                if (stageCounter == 9)
                {
                    mRoad.ChangeStage(shiki + 1);
                    Instantiate(bigTori, road.transform.position - new Vector3(0, 10.2f, 0), Quaternion.identity);
                    return;
                }
                // if(stageCounter == 5 + stageCounterAll)
                if (stageCounter == 10)
                {
                    mRoad.ChangeStage(shiki + 1);
                }
                // if(stageCounter == 6 + stageCounterAll)
                if (stageCounter == 11)
                {
                    shiki++;
                    mRoad.ChangeStage(shiki);
                    stageCounter = 0;
                }
                break;

            case 2:
                // if(stageCounter == 4 + stageCounterAll)
                if (stageCounter == 9)
                {
                    mRoad.ChangeStage(shiki + 1);
                    Instantiate(bigTori, road.transform.position - new Vector3(0, 10.2f, 0), Quaternion.identity);
                    return;
                }
                // if(stageCounter == 5 + stageCounterAll)
                if (stageCounter == 10)
                {
                    mRoad.ChangeStage(shiki + 1);
                }
                // if(stageCounter == 6 + stageCounterAll)
                if (stageCounter == 11)
                {
                    shiki++;
                    mRoad.ChangeStage(shiki);
                    stageCounter = 0;
                }
                break;

            case 3:
                // if(stageCounter == 3 + stageCounterAll)
                if (stageCounter == 8)
                {
                    taikoAudio.volume = 0.07f;
                    return;
                }
                // if(stageCounter == 4 + stageCounterAll)
                if (stageCounter == 9)
                {
                    mRoad.ChangeStage(shiki + 1);
                    Instantiate(bigTori, road.transform.position - new Vector3(0, 10.2f, 0), Quaternion.identity);
                    taikoAudio.volume = 0.04f;
                    return;
                }
                // if(stageCounter == 5 + stageCounterAll)
                if (stageCounter == 10)
                {
                    mRoad.ChangeStage(shiki + 1);
                    taikoAudio.volume = 0.01f;
                }
                // if(stageCounter == 6 + stageCounterAll)
                if (stageCounter == 11)
                {
                    shiki++;
                    mRoad.ChangeStage(shiki);
                    stageCounter = 0;
                    taikoAudio.volume = 0.00f;
                }
                break;

            case 4:
                // if(stageCounter == 5)
                if (stageCounter == 10)
                {
                    taikoAudio.volume = 0.01f;
                    return;
                }
                // if(stageCounter == 6)
                if (stageCounter == 11)
                {
                    Instantiate(bigTori, road.transform.position - new Vector3(0, 10.2f, 0), Quaternion.identity);
                    stageCounterAll++;
                    if (stageCounterAll >= 12)
                    {
                        mRoad.ChangeStage(5);
                    }
                    else
                    {
                        mRoad.ChangeStage(1);
                    }
                    taikoAudio.volume = 0.04f;
                    mRoad.Year(stageCounterAll);
                    return;
                }
                // if(stageCounter == 7)
                if (stageCounter == 12)
                {
                    if (stageCounterAll >= 12)
                    {
                        mRoad.ChangeStage(5);
                    }
                    else
                    {
                        mRoad.ChangeStage(1);
                    }
                    taikoAudio.volume = 0.07f;
                }
                // if(stageCounter == 8)
                if (stageCounter == 13)
                {

                    if (stageCounterAll >= 12)
                    {
                        shiki = 5;
                        mRoad.ChangeStage(5);
                    }
                    else
                    {
                        shiki = 1;
                        mRoad.ChangeStage(1);
                    }
                    stageCounter = 0;
                    // stageCounterAll++;
                    // toriFlg = false;
                    ps.SetGear(stageCounterAll);
                    taikoAudio.volume = 0.1f;
                }


                break;

            case 5:
                if (stageCounter == 5)
                {
                    mRoad.MakeGoal();
                    mRoad.StopMake();
                    return;
                }
                if (stageCounter == 6)
                {
                    mRoad.StopMake();
                    return;
                }
                if (stageCounter == 7)
                {
                    mRoad.StopMake();
                    return;
                }
                break;
        }
        mRoad.MakeStageCast(stageCounterAll);
    }

    public void StartCountDown()
    {
        startCanvas.SetActive(false);
        countDown.SetActive(true);

    }

    public void StartGame()
    {
        player.GetComponent<Player>().RunFlgTrue();
        drawlineComponent.StartFlgTrue();
        startCanvas.SetActive(false);
        runCanvas.SetActive(true);
        cleaner.SetActive(true);
        cleanerScript = cleaner.GetComponent<Cleaner>();
        cleanerScript.SetStageLife(stageLife);
        // demoCtrl.SetActive(false);
        Destroy(demoCtrl);
        startFlg = true;
        // Time.timeScale = 1f;

    }

    public void StopGame()
    {
        if (!startFlg)
        {
            return;
        }
        /*
        player.GetComponent<Player>().RunFlgFalse();
        drawlineComponent.StartFlgFalse();
        runCanvas.SetActive(false);
        startCanvas.SetActive(true);
        */
        drawlineComponent.StartFlgFalse();
        Time.timeScale = 0;
        stopBotton.SetActive(false);
        restartBotton.SetActive(true);
        retryBotton.SetActive(true);
        exitBotton.SetActive(true);
    }

    public void RestartGame()
    {
        drawlineComponent.StartFlgTrue();
        Time.timeScale = 1;
        stopBotton.SetActive(true);
        restartBotton.SetActive(false);
        retryBotton.SetActive(false);
        exitBotton.SetActive(false);
    }


    public void ReStart()
    {
        // SceneManager.LoadScene("Main");
        // SceneChanger.instance.ChangeMain();
        Time.timeScale = 1f;

    }

    public void LostLife()
    {
        // SceneChanger.instance.ChangeMenu();
        // Result();
        if (lostLifeFlg)
        {
            return;
        }
        lostLifeFlg = true;
        missAudio.Play();
        restLife--;
        // bokujuCountText.text = "✖︎" + restLife;
        cleanerScript.LostLife();
        mCScript.LostLifeStart();
        StartCoroutine(Vibrate(1));
        if (restLife <= 0)
        {
            Login();
            Invoke("Result", 1.5f);
        }
        ps.StartCoroutine("ResetPositionChikaChika");
        ps.ReSetBaseSpeed();
        Invoke("SetLostLifeFlgFalse", 1.5f);
    }

    public void SetLostLifeFlgFalse()
    {
        lostLifeFlg = false;
    }

    public void GetTori(string name)
    {
        if (name == "Tori")
        {
            // fillChototsuGage += 5;
            StartChototsumoshin();
            // ChototsuGage(100);
        }
        else if (name == "ShiroTori")
        {
            // fillChototsuGage += 100;
            ChototsuGage(500);
        }
        // chototsuGageImage.fillAmount = fillChototsuGage / maxChototsuGage;

        /*
        if(chototsuGageImage.fillAmount >= 1)
        {
            chototsuFlg = true;
        }
        */


    }

    public void ChototsuGage(int num)
    {

        // fillChototsuGage += num + chototsuLevelPoint;
        fillChototsuGage += num;
        // chototsuGageSlider.value = fillChototsuGage / maxChototsuGage;
        // Debug.Log(num); 
        if (fillChototsuGage / maxChototsuGage >= 1)
        {
            //chototsuFlg = true;
            /*
            while(fillChototsuGage > 100 + 100 * chototsuCount)
            {
                fillChototsuGage -= 100 + 100 * chototsuCount;
                chototsuCount++;
                maxChototsuGage = 100 + 100 * chototsuCount;
                chototsuGageSlider.value = fillChototsuGage / maxChototsuGage;
                
                StartChototsumoshin();
            }
            */
            while (fillChototsuGage >= 100)
            {
                fillChototsuGage -= 100;
                chototsuCount++;
                StartChototsumoshin();
            }
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
        if (chototsuGageImage.fillAmount < 1)
        {
            chototsuFlg = false;
        }
        Vector2 liberationPowerPos = new Vector2(Random.Range(-2.1f, 2.1f), player.transform.position.y + 19.2f);
        Instantiate(liberationPower, liberationPowerPos, transform.rotation);
    }

    public void StartChototsumoshin()
    {
        player.GetComponent<Player>().Chototsumoshin(10 + bomPoint * 0.0001f);
        /*
        if(toriCounter < 10)
        {
            player.GetComponent<Player>().Chototsumoshin(5 + toriCounter);
        }
        else
        {
            player.GetComponent<Player>().Chototsumoshin(15);
        }
        */

        //Debug.Log(chototsuCount);
        cleaner.GetComponent<Cleaner>().Chototsumoshin();
        mainCamera.GetComponent<MainCamera>().Chototsumoshin();
        /*
switch(liberationPatten)
{
    case "Chototsumoshin":
        // player.GetComponent<Player>().Chototsumoshin(chototsuCount);
        player.GetComponent<Player>().Chototsumoshin(5);
        cleaner.GetComponent<Cleaner>().Chototsumoshin();
        mainCamera.GetComponent<MainCamera>().Chototsumoshin();
        // chototsuGageImage.fillAmount = fillChototsuGage / maxChototsuGage;
        break;

    case "Mure":
        Vector3 murePos = player.transform.position;
        murePos.y = murePos.y + 5;
        Instantiate(mure, murePos, transform.rotation);
        /*
        for(int num = 0; num < chototsuCount; num++)
        {
            Instantiate(mure, murePos, transform.rotation);
        }


        break;

    case "Hogeki":
        drawlineComponent.HogekiCountUp();
        break;

    case "Deka":
        /*
        player.transform.localScale = new Vector3(0.2f + chototsuCount * 0.05f, 0.2f + chototsuCount * 0.05f,1);
        if(chototsuCount > 4)
        {
            player.GetComponent<Player>().Chototsumoshin(chototsuCount);
            Debug.Log(chototsuCount);
            cleaner.GetComponent<Cleaner>().Chototsumoshin();
            mainCamera.GetComponent<MainCamera>().Chototsumoshin();
        }

        player.GetComponent<Player>().Chototsumoshin(10);
        //Debug.Log(chototsuCount);
        cleaner.GetComponent<Cleaner>().Chototsumoshin();
        mainCamera.GetComponent<MainCamera>().Chototsumoshin();
        break;
}
*/
        chototsuFlg = true;
    }

    public void EndChototsumoshin()
    {
        cleaner.GetComponent<Cleaner>().EndChototsumoshin();
        mainCamera.GetComponent<MainCamera>().EndChototsumoshin();
        chototsuFlg = false;
    }

    public void Result()
    {
        //gad.ShowAd();
        gad.ShowInterstitial();
        // Time.timeScale = 0f;
        lineAudio.Stop();
        PlayerPrefs.SetInt("PlayCount", PlayerPrefs.GetInt("PlayCount", 0) + 1);
        PlayerPrefs.SetInt(versionPlayCount, PlayerPrefs.GetInt(versionPlayCount, 0) + 1);
        scFlg = true;
        player.GetComponent<Player>().RunFlgFalse();
        drawlineComponent.StartFlgFalse();
        runCanvas.SetActive(false);
        cleaner.SetActive(false);
        resultCanvas.SetActive(true);
        currentScore = bomPoint + bonusPoint;
        // PlayerPrefs.SetInt("Saisen", PlayerPrefs.GetInt("Saisen",0) + currentScore);
        // PlayerPrefs.SetInt("LevelPoint", PlayerPrefs.GetInt("LevelPoint",0) + currentScore);
        // ResultEffect();
        switch (stageName)
        {
            case "Mugen":
                // Debug.Log(PlayerPrefs.GetInt("STATISTICS_NAME", 1));
                highScore = PlayerPrefs.GetInt(STATISTICS_NAME, 0);
                if (currentScore >= highScore)
                {
                    // Debug.Log(currentScore);
                    // Debug.Log(highScore);
                    PlayerPrefs.SetInt(STATISTICS_NAME, currentScore);
                    highScore = PlayerPrefs.GetInt(STATISTICS_NAME, 0);
                    // Debug.Log(PlayerPrefs.GetInt(STATISTICS_NAME, 1));
                    getHighScoreFlg = true;
                    /*
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                    */
                    resultPattern = "最高徳";
                    StartCoroutine(SubmitScore(currentScore));

                }
                else
                {
                    /*
                    message = "まだいける";
                    message2 = "もうすこしだけ";
                    message3 = "がんばろう";
                    */
                    resultPattern = "普通";
                    StartCoroutine(SubmitScore(highScore));
                    // RequestLeaderBoard();

                }
                altBonnoPoint = PlayerPrefs.GetInt("MugenToku", 0) + currentScore; //* (1 + PlayerPrefs.GetInt("猪春夏秋冬並木",0) + PlayerPrefs.GetInt("犬春夏秋冬並木",0) + PlayerPrefs.GetInt("鳥春夏秋冬並木",0) + PlayerPrefs.GetInt("猿春夏秋冬並木",0) + PlayerPrefs.GetInt("羊春夏秋冬並木",0) + PlayerPrefs.GetInt("馬春夏秋冬並木",0) + PlayerPrefs.GetInt("蛇春夏秋冬並木",0) + PlayerPrefs.GetInt("龍春夏秋冬並木",0) + PlayerPrefs.GetInt("兎春夏秋冬並木",0) + PlayerPrefs.GetInt("虎春夏秋冬並木",0) + PlayerPrefs.GetInt("牛春夏秋冬並木",0) + PlayerPrefs.GetInt("鼠春夏秋冬並木",0) + PlayerPrefs.GetInt("達のんびり草原",0) * 2 + PlayerPrefs.GetInt("達春夏秋冬並木",0) * 2　+ PlayerPrefs.GetInt("達桃源郷積乱雲",0) * 2);
                getMoney = currentScore * (1 + PlayerPrefs.GetInt("猪春夏秋冬並木", 0) + PlayerPrefs.GetInt("犬春夏秋冬並木", 0) * 2 + PlayerPrefs.GetInt("鳥春夏秋冬並木", 0) * 3 + PlayerPrefs.GetInt("猿春夏秋冬並木", 0) * 4 + PlayerPrefs.GetInt("羊春夏秋冬並木", 0) * 5 + PlayerPrefs.GetInt("馬春夏秋冬並木", 0) * 6 + PlayerPrefs.GetInt("蛇春夏秋冬並木", 0) * 7 + PlayerPrefs.GetInt("龍春夏秋冬並木", 0) * 8 + PlayerPrefs.GetInt("兎春夏秋冬並木", 0) * 9 + PlayerPrefs.GetInt("虎春夏秋冬並木", 0) * 10 + PlayerPrefs.GetInt("牛春夏秋冬並木", 0) * 11 + PlayerPrefs.GetInt("鼠春夏秋冬並木", 0) * 12 + PlayerPrefs.GetInt("達春夏秋冬並木", 0) * 100 + PlayerPrefs.GetInt("Omikuji"));
                PlayerPrefs.SetInt("MugenToku", altBonnoPoint);
                // stageNameText.text = "春夏秋冬並木";
                levelPointTotal = PlayerPrefs.GetInt("MugenToku", 0);
                resultGetPointText.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "CurrentScore", arguments: new object[] { currentScore });
                resultGetTokuText.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "CurrentYen", arguments: new object[] { getMoney });
                money = PlayerPrefs.GetInt("Money", 0) + getMoney;
                PlayerPrefs.SetInt("Money", money);

                resultMoney.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "Yen", arguments: new object[] { money });
                highScoreTextKanban.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "HighScore", arguments: new object[] { PlayerPrefs.GetInt(STATISTICS_NAME, 0) });
                // PlayerPrefs.SetInt("LevelPoint", PlayerPrefs.GetInt("LevelPoint",0) + currentScore);
                break;

            case "Trick1_1":
                highScore = PlayerPrefs.GetInt("HS_Trick1_1", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick1_1", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick1_1");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;

            case "Trick1_2":
                highScore = PlayerPrefs.GetInt("HS_Trick1_2", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick1_2", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick1_2");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;

            case "Trick1_3":
                highScore = PlayerPrefs.GetInt("HS_Trick1_3", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick1_3", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick1_3");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;

            case "Trick2_1":
                highScore = PlayerPrefs.GetInt("HS_Trick2_1", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick2_1", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick2_1");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;

            case "Trick2_2":
                highScore = PlayerPrefs.GetInt("HS_Trick2_2", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick2_2", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick2_2");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;

            case "Trick2_3":
                highScore = PlayerPrefs.GetInt("HS_Trick2_3", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick2_3", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick2_3");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;

            case "Trick3_1":
                highScore = PlayerPrefs.GetInt("HS_Trick3_1", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick3_1", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick3_1");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;

            case "Trick3_2":
                highScore = PlayerPrefs.GetInt("HS_Trick3_2", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick3_2", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick3_2");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;

            case "Trick3_3":
                highScore = PlayerPrefs.GetInt("HS_Trick3_3", 0);
                if (currentScore > highScore)
                {
                    PlayerPrefs.SetInt("HS_Trick3_3", currentScore);
                    highScore = PlayerPrefs.GetInt("HS_Trick3_3");
                    StartCoroutine(SubmitScore(currentScore));
                }
                break;
        }
        for (int i = 0; i < 109; i++)
        {
            /*
            if(i < 25)
            {
                levelPointMainus = 100 * (i + 1);
            }
            if(i >= 25 && i < 50)
            {
                levelPointMainus = 200 * (i + 1);
            }
            if(i >= 50 && i < 75)
            {
                levelPointMainus = 500 * (i + 1);
            }
            if(i >= 75 && i < 101)
            {
                levelPointMainus = 1000 * (i + 1);
            }
            if(i >= 101 && i < 108)
            {
                levelPointMainus = 10000 * (i + 1);
            }
            */
            if (i < 10)
            {
                // 1000
                levelPointMainus = 100 * (i + 1);
            }
            if (i >= 10 && i < 20)
            {
                // 1000 + 2000 = 3000
                levelPointMainus = 200 * (i + 1);
            }
            if (i >= 20 && i < 30)
            {
                // 3000 + 4000 = 7000
                levelPointMainus = 400 * (i + 1);
            }
            if (i >= 30 && i < 40)
            {
                // 7000 + 8000 = 15000
                levelPointMainus = 800 * (i + 1);
            }
            if (i >= 40 && i < 50)
            {
                // 15000 + 16000 = 31000
                levelPointMainus = 1600 * (i + 1);
            }
            if (i >= 50 && i < 60)
            {
                // 31000 + 32000 = 63000
                levelPointMainus = 3200 * (i + 1);
            }
            if (i >= 60 && i < 70)
            {
                // 63000 + 64000 = 1270000
                levelPointMainus = 6400 * (i + 1);
            }
            if (i >= 70 && i < 80)
            {
                //127000 +128000 = 255000
                levelPointMainus = 12800 * (i + 1);
            }
            if (i >= 80 && i < 90)
            {
                // 255000 + 256000 = 511000
                levelPointMainus = 25600 * (i + 1);
            }
            if (i >= 90 && i < 100)
            {
                // 511000 + 512000 = 523000
                levelPointMainus = 51200 * (i + 1);
            }
            if (i >= 100 && i < 108)
            {
                // 523000 + 800000 = 1323000
                levelPointMainus = 100000 * (i + 1);
            }
            if (i == 108)
            {

                switch (stageName)
                {
                    case "Nonbirisogen":
                        if (PlayerPrefs.GetInt("悟のんびり草原", 0) == 1)
                        {
                            break;
                        }
                        if (resultPattern != "一位")
                        {
                            resultPattern = "悟";
                        }
                        PlayerPrefs.SetInt("NonbirisogenLevel", i);
                        PlayerPrefs.SetInt("悟のんびり草原", 1);

                        break;

                    case "Mugen":
                        if (PlayerPrefs.GetInt("悟春夏秋冬並木", 0) == 1)
                        {
                            break;
                        }
                        if (resultPattern != "一位")
                        {
                            resultPattern = "悟";
                        }
                        PlayerPrefs.SetInt("ShunkashutonamikiLevel", i);
                        PlayerPrefs.SetInt("悟春夏秋冬並木", 1);
                        break;

                    case "Togenkyosekiranun":
                        if (PlayerPrefs.GetInt("悟桃源郷積乱雲", 0) == 1)
                        {
                            break;
                        }
                        if (resultPattern != "一位")
                        {
                            resultPattern = "悟";
                        }
                        PlayerPrefs.SetInt("TogenkyosekiranunLevel", i);
                        PlayerPrefs.SetInt("悟桃源郷積乱雲", 1);
                        break;
                }

                altLevel = 108 - i;
                levelText.text = "残煩悩：" + altLevel;
                jokyoPoint = levelPointMainus - levelPointTotal;
                jokyoText.text = "解脱";
                tokuSlider.maxValue = 1;
                tokuSlider.value = 1;
                break;
            }
            if (levelPointTotal >= levelPointMainus)
            {
                levelPointTotal -= levelPointMainus;
                // Debug.Log(levelPointTotal);
            }
            else
            {



                jokyoPoint = levelPointMainus - levelPointTotal;
                jokyoText.text = "次の克服まで：" + jokyoPoint + "徳";
                tokuSlider.maxValue = levelPointMainus;
                tokuSlider.value = levelPointTotal;
                /*
                Debug.Log(tokuSlider.value);
                Debug.Log(levelPointTotal);
                Debug.Log(levelPointMainus);
                Debug.Log(altLevel);      
                */
                switch (stageName)
                {
                    case "Nonbirisogen":

                        altLevel = 108 - i;
                        beforeLevel = 108 - PlayerPrefs.GetInt("NonbirisogenLevel", 0);
                        if (altLevel < beforeLevel)
                        {
                            levelText.text = "残煩悩：" + beforeLevel + "→" + altLevel;
                            levelUpFlg = true;
                            // ResultEffect();
                        }
                        else
                        {
                            levelText.text = "残煩悩：" + altLevel;
                        }
                        PlayerPrefs.SetInt("NonbirisogenLevel", i);
                        break;

                    case "Mugen":
                        /*
                        altLevel = 108 -i;
                        beforeLevel = 108 - PlayerPrefs.GetInt("ShunkashutonamikiLevel", 0);
                        if(altLevel < beforeLevel)
                        {
                            levelText.text = "残煩悩：" + beforeLevel + "→" + altLevel;
                            levelUpFlg = true;
                            // ResultEffect();
                        }
                        else
                        {
                            levelText.text = "残煩悩：" + altLevel;
                        }
                        PlayerPrefs.SetInt("ShunkashutonamikiLevel", i);
                        */
                        altLevel = 108 - i;
                        levelText.text = "残煩悩：" + altLevel;
                        break;

                    case "Togenkyosekiranun":
                        altLevel = 108 - i;
                        beforeLevel = 108 - PlayerPrefs.GetInt("TogenkyosekiranunLevel", 0);
                        if (altLevel < beforeLevel)
                        {
                            levelText.text = "残煩悩：" + beforeLevel + "→" + altLevel;
                            levelUpFlg = true;
                            // ResultEffect();
                        }
                        else
                        {
                            levelText.text = "残煩悩：" + altLevel;
                        }
                        PlayerPrefs.SetInt("TogenkyosekiranunLevel", i);
                        break;
                }
                break;
            }

        }
        PlayerPrefs.SetInt("MugenLevel", altLevel);
        LevelUp();
        // highScoreText.text = "最高記録　　" + highScore + "徳\n" + "今回の得徳　" + currentScore + "徳\n\n";
        highScoreText.text = "";
        highScoreText2.text = "";
        highScoreText3.text = "";
        // currentScoreText.text = "今回の得徳" + currentScore + "徳";
        // currentScoreText.text = currentScore + "徳" + "(基礎徳:" + Mathf.RoundToInt(player.transform.position.y) * 10 + bomPoint + "徳)";

        // RequestLeaderBoard();
        /*
        snapbarManager.ShowSnapbar("テストだよ1", test, 3.0f);
        snapbarManager.ShowSnapbar("テストだよ2", test, 3.0f);
        snapbarManager.ShowSnapbar("テストだよ3", test2, 3.0f);
        snapbarManager.ShowSnapbar("テストだよ4", test2, 3.0f);
        snapbarManager.ShowSnapbar("テストだよ5", test3, 3.0f);
        snapbarManager.ShowSnapbar("テストだよ6", test3, 3.0f);
        */
    }

    public void LevelUp()
    {
        afterLevel = PlayerPrefs.GetInt("MugenLevel", 108);
        if (beforeLevel == 0)
        {
            return;
        }
        if (beforeLevel == afterLevel)
        {
            return;
        }

        if (afterLevel == 0)
        {
            message = "解脱完了、「悟」のご朱印獲得しました！\nここからが本当のえとばしり！！";
            snapbarManager.ShowSnapbar(message, satoruImage, 3);
            PlayerPrefs.SetInt("MugenLevel", afterLevel);
            beforeLevel = afterLevel;
        }
        else
        {
            message = "煩悩克服!\n" + "残りの煩悩" + beforeLevel + "→" + afterLevel;
            snapbarManager.ShowSnapbar(message, bonnoImage, 3);
            PlayerPrefs.SetInt("MugenLevel", afterLevel);
            beforeLevel = afterLevel;
        }

    }


    public void Critical()
    {

        // drawlineComponent.BokujuCountUp(1);
        //ChototsuGage(5);
        mCScript.BlowStart();
    }

    public void SetBokujuCount(int count)
    {
        bokujuCount = count;
        bokujuCountText.text = "✖︎" + bokujuCount;
    }

    public void GetLifeThread()
    {
        restLife++;
        /*
        if(restLife >= 14)
        {
            restLife = 14;
        }
        */
        cleanerScript.RebornLife();
        // restLifeText.text = "×" + restLife.ToString();
    }

    public void GetPoint(int point)
    {
        bomPoint += point;
        /*
        if (bomPoint > 1000 * toriCounter)
        {
            ps.SetToriCounter(toriCounter);
            toriMeter -= 100;
            toriCounter++;
        }
        */

        if (bomPoint > prismCounter * 10000)
        {
            if (prismCounter % 3 == 0)
            {
                prismName = "Gold";
            }
            else
            {
                prismName = "Silver";
            }
            prismFlg = true;
            prismCounter++;
        }
        /*
        if(bomPoint >= 3000 * stageCounterAll && !toriFlg)
        {
            Instantiate(tori,new Vector3(Random.Range(-2.5f,2.5f), player.transform.position.y + 19.2f,0), Quaternion.identity);
            toriFlg = true;
        }
        */
        /*
        if(bomPoint >= 0 && bomPoint <= 1000)
        {
            // meter.color = new Color(0.5f,0.5f,0.5f,1f);
            meter.GetComponent<Outline>().effectColor = new Color(0.5f,0.5f,0.5f,1f);
        }
        if(bomPoint > 1000 && bomPoint <= 2000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.86f,0.86f,0.86f,1f);
        }
        if(bomPoint > 2000 && bomPoint <= 3000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.86f,0.86f,0.86f,1f);
        }
        if(bomPoint > 3000 && bomPoint <= 4000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.9f,0.96f,0.96f,1f);
        }
        if(bomPoint > 4000 && bomPoint <= 5000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.94f,0.94f,0.56f,1f);
        }
        if(bomPoint > 5000 && bomPoint <= 6000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.94f,0.94f,0f,1f);
        }
        if(bomPoint > 6000 && bomPoint <= 7000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.92f,0.37f,0f,1f);
        }
        if(bomPoint > 7000 && bomPoint <= 8000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.92f,0f,0f,1f);
        }
        if(bomPoint > 8000 && bomPoint <= 9000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.19f,0.38f,0.96f,1f);
        }
        if(bomPoint > 9000 && bomPoint <= 10000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.18f,0.18f,0.55f,1f);
        }
        if(bomPoint > 10000 && bomPoint <= 11000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.75f,0.56f,0.95f,1f);
        }
        if(bomPoint > 11000)
        {
            meter.GetComponent<Outline>().effectColor = new Color(0.5f,0,0.5f,1f);
        }
        */
        if (point != 0)
        {
            plusPoint.Plus(point);
        }

        meter.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "TotalPoint", arguments: new object[] { bomPoint });
        ps.SetCurrentPoint(bomPoint);
    }

    public void PrismCheck()
    {

    }

    public void Goal()
    {
        bonusPoint = restLife * 10000; //bokujuCount * 300;
        // PlayerPrefs.SetInt("完春夏秋冬並木", 1);
        kansoFlg = true;
        Result();
    }

    // Trick1_1
    IEnumerator SubmitScore(int playerScore)
    {
        yield return new WaitForSeconds(0.1f);
        SetPlayerDisplayName(PlayerPrefs.GetString("Name", "お客さん"));
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        // StatisticName = SceneManager.GetActiveScene().name,
                        StatisticName = STATISTICS_NAME,

                        Value = playerScore
                    }
                }
            },
            result =>
            {
                // Debug.Log("スコア送信");
                Invoke("RequestLeaderBoard", 0.5f);
                PlayFabClientAPI.UpdatePlayerStatistics(
                    new UpdatePlayerStatisticsRequest
                    {
                        Statistics = new List<StatisticUpdate>()
                        {
                            new StatisticUpdate
                            {
                                StatisticName = "PlayCount",
                                Value = PlayerPrefs.GetInt("PlayCount",0)
                            }
                        }
                    },
                    result =>
                    {

                    },
                    error =>
                    {

                    }
                    );
                PlayFabClientAPI.UpdatePlayerStatistics(
                    new UpdatePlayerStatisticsRequest
                    {
                        Statistics = new List<StatisticUpdate>()
                        {
                            new StatisticUpdate
                            {
                                StatisticName = versionPlayCount,
                                Value = PlayerPrefs.GetInt(versionPlayCount,0)
                            }
                        }
                    },
                    result =>
                    {

                    },
                    error =>
                    {

                    }
                    );
            },
            error =>
            {
                // Debug.Log(error.GenerateErrorReport());
                loginTry++;
                if (loginTry >= 10)
                {
                    snapbarManager.ShowSnapbar("ログインができません。\nネット環境が良い状態で\n再ログインしてください。", loginErrorImage, 10);
                }
                else
                {
                    StartCoroutine(SubmitScore(playerScore));
                }

            }
            );

        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = "PlayCount",

                        Value = PlayerPrefs.GetInt("PlayCount",0)
                    }
                }
            },
            result =>
            {

            },
            error =>
            {

            }
            );
    }

    public void SetPlayerDisplayName(string displayName)
    {

        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = displayName
            },
            result =>
            {
                Debug.Log("Set display name was succeeded.");
            },
            error =>
            {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }

    public void Login()
    {
        string id = PlayerPrefs.GetString("ID", "No ID");
        string currentName = PlayerPrefs.GetString("Name", "お客さん");

        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = id, CreateAccount = true },
            result =>
            {
                // Debug.Log("ログイン成功！");
            },
            error =>
            {
                // Debug.Log("ログイン失敗");
                Login();
            });
    }

    public void RequestLeaderBoard()
    {
        // yield return new WaitForSecondsRealtime(1);
        PlayFabClientAPI.GetLeaderboardAroundPlayer(
            new GetLeaderboardAroundPlayerRequest
            {
                // StatisticName = SceneManager.GetActiveScene().name,
                StatisticName = STATISTICS_NAME,
                MaxResultsCount = 21
            },
            result =>
            {
                foreach (Transform child in rankingSV.transform)
                {
                    //自分の子供をDestroyする
                    Destroy(child.gameObject);
                }
                int beforeStamp1 = PlayerPrefs.GetInt("猪春夏秋冬並木", 0);
                int beforeStamp2 = PlayerPrefs.GetInt("犬春夏秋冬並木", 0);
                int beforeStamp3 = PlayerPrefs.GetInt("鳥春夏秋冬並木", 0);
                int beforeStamp4 = PlayerPrefs.GetInt("猿春夏秋冬並木", 0);
                int beforeStamp5 = PlayerPrefs.GetInt("羊春夏秋冬並木", 0);
                int beforeStamp6 = PlayerPrefs.GetInt("馬春夏秋冬並木", 0);
                int beforeStamp7 = PlayerPrefs.GetInt("蛇春夏秋冬並木", 0);
                int beforeStamp8 = PlayerPrefs.GetInt("龍春夏秋冬並木", 0);
                int beforeStamp9 = PlayerPrefs.GetInt("兎春夏秋冬並木", 0);
                int beforeStamp10 = PlayerPrefs.GetInt("虎春夏秋冬並木", 0);
                int beforeStamp11 = PlayerPrefs.GetInt("牛春夏秋冬並木", 0);
                int beforeStamp12 = PlayerPrefs.GetInt("鼠春夏秋冬並木", 0);
                int beforeStamp13 = PlayerPrefs.GetInt("達春夏秋冬並木", 0);
                int beforeStamp14 = PlayerPrefs.GetInt("超春夏秋冬並木", 0);
                int beforeStamp15 = PlayerPrefs.GetInt("神春夏秋冬並木", 0);
                int beforeStamp16 = PlayerPrefs.GetInt("完春夏秋冬並木", 0);

                // Text banduke2 = Instantiate(bandukeText,new Vector3(0,0,0), Quaternion.identity);
                string comment = "";
                if (currentScore < 500)
                {
                    resultPattern = "亥";

                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);

                    /*
                    comment = "亥";
                    stampMos.SetActive(true);
                    message = "しのぶれど";
                    message2 = "もうすこしだけ";
                    message3 = "がんばろう";
                    PlayerPrefs.SetInt("猪春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 1500 && currentScore >= 500)
                {
                    resultPattern = "戌";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    /*
                    comment = "戌";
                    stampDog.SetActive(true);
                    message = "ひさかたの";
                    message2 = "ひかりのどけき";
                    message3 = "よいはしり";
                    PlayerPrefs.SetInt("犬春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 3000 && currentScore >= 1500)
                {
                    resultPattern = "酉";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    /*
                    comment = "酉";
                    stampBird.SetActive(true);
                    message = "ひとはいさ";
                    message2 = "こころもしらず";
                    message3 = "みこみあり";
                    PlayerPrefs.SetInt("鳥春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 5000 && currentScore >= 3000)
                {
                    resultPattern = "申";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    /*
                    comment = "申";
                    stampMonkey.SetActive(true);
                    message = "あらしふく";
                    message2 = "きみのみちすじ";
                    message3 = "まだのびる";
                    PlayerPrefs.SetInt("猿春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 7500 && currentScore >= 5000)
                {
                    resultPattern = "未";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    /*
                    comment = "未";
                    stampSheep.SetActive(true);
                    message = "ごうかいに";
                    message2 = "たまぞちりける";
                    message3 = "はしりかた";
                    PlayerPrefs.SetInt("羊春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 10500 && currentScore >= 7500)
                {
                    resultPattern = "午";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    /*
                    comment = "午";
                    stampHorse.SetActive(true);
                    message = "がんばりの";
                    message2 = "しるしなりける";
                    message3 = "５０００てん";
                    PlayerPrefs.SetInt("馬春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 14000 && currentScore >= 10500)
                {
                    resultPattern = "巳";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    /*
                    comment = "巳";
                    stampSnake.SetActive(true);
                    message = "今はただ";
                    message2 = "ほめざるをえぬ";
                    message3 = "そのはしり";
                    PlayerPrefs.SetInt("蛇春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 18000 && currentScore >= 14000)
                {
                    resultPattern = "辰";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    /*
                    comment = "辰";
                    stampDragon.SetActive(true);
                    message = "ほめるにも";
                    message2 = "なおあまりある";
                    message3 = "ゆびさばき";
                    PlayerPrefs.SetInt("龍春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 22500 && currentScore >= 18000)
                {
                    resultPattern = "卯";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                    /*
                    comment = "卯";
                    stampRabbit.SetActive(true);
                    message = "おほけなく";
                    message2 = "ひょうかをすると";
                    message3 = "すさまじい";
                    PlayerPrefs.SetInt("兎春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 27500 && currentScore >= 22500)
                {
                    resultPattern = "寅";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                    /*
                    comment = "寅";
                    stampTiger.SetActive(true);
                    message = "ほこらしい";
                    message2 = "やまどりのおの";
                    message3 = "けものみち";
                    PlayerPrefs.SetInt("虎春夏秋冬並木",1);
                    */
                }
                else if (currentScore < 33000 && currentScore >= 27500)
                {
                    resultPattern = "丑";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("牛春夏秋冬並木", 1);
                    /*
                    comment = "丑";
                    stampCaw.SetActive(true);
                    message = "きみがため";
                    message2 = "まだまだたりぬ";
                    message3 = "ぎじゅつりょく";
                    PlayerPrefs.SetInt("牛春夏秋冬並木",1);
                    */
                }
                else if (currentScore >= 33000)
                {
                    resultPattern = "子";
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("牛春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鼠春夏秋冬並木", 1);
                    /*
                    comment = "子";
                    stampRat.SetActive(true);
                    message = "これやこの";
                    message2 = "かいきゅうねずみの";
                    message3 = "しごとぶり";
                    PlayerPrefs.SetInt("鼠春夏秋冬並木",1);
                    */
                }
                if (kansoFlg)
                {
                    resultPattern = "完";
                    PlayerPrefs.SetInt("完春夏秋冬並木", 1);
                }
                /*
                if(getHighScoreFlg)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                }
                */


                // banduke2.text = "今回の階級　"　+ comment;
                // banduke2.transform.parent = rankingSV.transform;
                // banduke2.transform.localScale = new Vector3(1,1,1);
                /*
                Text banduke1 = Instantiate(bandukeText,new Vector3(0,0,0), Quaternion.identity);
                banduke1.text = "今回の得徳　" + currentScore + "徳";
                banduke1.transform.parent = rankingSV.transform;
                banduke1.transform.localScale = new Vector3(1,1,1);
                
                /*
                Text banduke5 = Instantiate(rankingText,new Vector3(0,0,0), Quaternion.identity);
                banduke5.text = " ";
                banduke5.transform.parent = rankingSV.transform;
                banduke5.transform.localScale = new Vector3(1,1,1);
                */
                /*
                Text banduke3 = Instantiate(bandukeText,new Vector3(0,0,0), Quaternion.identity);
                banduke3.text = "最高得徳　" + highScore + "徳";
                banduke3.transform.parent = rankingSV.transform;
                banduke3.transform.localScale = new Vector3(1,1,1);
                /*
                Text banduke4 = Instantiate(bandukeText,new Vector3(0,0,0), Quaternion.identity);
                banduke4.text = highScore + "徳";
                banduke4.transform.parent = rankingSV.transform;
                banduke4.transform.localScale = new Vector3(1,1,1);
                */
                /*
                Text banduke6 = Instantiate(rankingText,new Vector3(0,0,0), Quaternion.identity);
                banduke6.text = " ";
                banduke6.transform.parent = rankingSV.transform;
                banduke6.transform.localScale = new Vector3(1,1,1);
                */
                /*
                switch(stageName)
                {
                    case "Nonbirisogen":
                        if(PlayerPrefs.GetInt("合のんびり草原",0) == 0 && currentScore > 1000)
                        {
                            PlayerPrefs.SetInt("合のんびり草原",1);
                            resultPattern = "合格";
                        }
                        
                        break;

                    case "Mugen":
                        if(PlayerPrefs.GetInt("合春夏秋冬並木",0) == 0 && currentScore > 10000)
                        {
                            PlayerPrefs.SetInt("合春夏秋冬並木",1);
                            resultPattern = "合格";
                        }
                        break;
                }
                */
                Text banduke = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                // banduke.text = "全員番付";
                banduke.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "RankingTitle");
                banduke.transform.parent = rankingSV.transform;
                banduke.transform.localScale = new Vector3(1, 1, 1);

                for (int i = 0; i < result.Leaderboard.Count; i++)
                {
                    string ranking = "";
                    string rankingName = "";
                    Text iremono;
                    Text iremonoName;
                    var x = result.Leaderboard[i];
                    // ranking = string.Format("{0}位 {1}徳", x.Position + 1, x.StatValue);
                    ranking = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "Ranking", arguments: new object[] { x.Position + 1, x.StatValue });
                    ranking.ToUpper();
                    // rankingName = string.Format("{0}", x.DisplayName);


                    ngWordFilter.CheckNGWord(x.DisplayName, (isNG) =>
                    {
                        if (isNG)
                        {
                            Debug.Log("NGワードが含まれているため、名前を「クプアス」に変更します。");
                            rankingName = "クプアス";
                        }
                        else
                        {
                            Debug.Log("NGワードは含まれていません。");
                            if (x.DisplayName != null)
                            {
                                rankingName = string.Format("{0}", x.DisplayName);
                            }
                            else
                            {
                                rankingName = "名無しのゴンベ";
                            }
                        }
                    });
                    rankingName.ToUpper();
                    //if(x.DisplayName == PlayerPrefs.GetString("Name","No Name") && currentScore == highScore)
                    // if((x.PlayFabId == PlayerPrefs.GetString("PlayFabId", "none")) && (currentScore == highScore) && (PlayerPrefs.GetString("PlayFabId", "none") != "none"))
                    if (x.PlayFabId == PlayerPrefs.GetString("MasterID", "") && currentScore == highScore)
                    {
                        if (x.StatValue != currentScore)
                        {
                            RequestLeaderBoard();
                            return;
                        }
                        /*
                        message = "かざはやを";
                        message2 = "あつめてはやし";
                        message3 = "よきはしり";
                        ResultEffect();
                        
                        resultPattern = "番付入り";
                        */
                        /*
                        if(x.Position + 1 < 11)
                        {
                            int num = x.Position + 1;
                            message = "しのぶれど";
                            message2 = "ばんづけはいった";
                            message3 = "すさまじい";
                            ResultEffect();
                        }
                        */
                        if (x.Position + 1 <= 100 && x.Position + 1 > 10)
                        {
                            resultPattern = "百位以内";
                            PlayerPrefs.SetInt("達春夏秋冬並木", 1);
                        }
                        if (x.Position + 1 > 1 && x.Position + 1 < 10)
                        {
                            resultPattern = "十位以内";
                            PlayerPrefs.SetInt("超春夏秋冬並木", 1);
                            PlayerPrefs.SetInt("達春夏秋冬並木", 1);
                        }
                        if (x.Position + 1 == 1)
                        {
                            /*
                            message = "千早ぶる";
                            message2 = "かみよもきかず";
                            message3 = "えとばしり";
                            PlayerPrefs.SetInt("神春夏秋冬並木",1);
                            stampGod.SetActive(true);
                            stampRat.SetActive(false);
                            stampCaw.SetActive(false);
                            stampTiger.SetActive(false);
                            stampRabbit.SetActive(false);
                            stampDragon.SetActive(false);
                            stampSnake.SetActive(false);
                            stampHorse.SetActive(false);
                            stampSnake.SetActive(false);
                            stampMonkey.SetActive(false);
                            stampBird.SetActive(false);
                            stampDog.SetActive(false);
                            stampMos.SetActive(false);
                            ResultEffect();
                            */
                            resultPattern = "一位";
                            PlayerPrefs.SetInt("神春夏秋冬並木", 1);
                            PlayerPrefs.SetInt("超春夏秋冬並木", 1);
                            PlayerPrefs.SetInt("達春夏秋冬並木", 1);
                        }
                    }
                    // ranking.ToUpper();
                    iremono = Instantiate(rankingText, new Vector3(0, 0, 0), Quaternion.identity);
                    iremonoName = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                    iremono.text = ranking;
                    iremonoName.text = rankingName;
                    iremono.transform.SetParent(rankingSV.transform, false);
                    iremono.transform.localScale = new Vector3(1, 1, 1);
                    iremonoName.transform.SetParent(rankingSV.transform, false);
                    iremonoName.transform.localScale = new Vector3(1, 1, 1);
                    if (result.Leaderboard[i].PlayFabId == PlayerPrefs.GetString("MasterID", ""))
                    {
                        iremono.GetComponent<BandukeText>().SetRedFlg();
                        iremonoName.GetComponent<BandukeText>().SetRedFlg();
                    }
                }
                ;

                ResultPattern();
                int afterStamp1 = PlayerPrefs.GetInt("猪春夏秋冬並木", 0);
                int afterStamp2 = PlayerPrefs.GetInt("犬春夏秋冬並木", 0);
                int afterStamp3 = PlayerPrefs.GetInt("鳥春夏秋冬並木", 0);
                int afterStamp4 = PlayerPrefs.GetInt("猿春夏秋冬並木", 0);
                int afterStamp5 = PlayerPrefs.GetInt("羊春夏秋冬並木", 0);
                int afterStamp6 = PlayerPrefs.GetInt("馬春夏秋冬並木", 0);
                int afterStamp7 = PlayerPrefs.GetInt("蛇春夏秋冬並木", 0);
                int afterStamp8 = PlayerPrefs.GetInt("龍春夏秋冬並木", 0);
                int afterStamp9 = PlayerPrefs.GetInt("兎春夏秋冬並木", 0);
                int afterStamp10 = PlayerPrefs.GetInt("虎春夏秋冬並木", 0);
                int afterStamp11 = PlayerPrefs.GetInt("牛春夏秋冬並木", 0);
                int afterStamp12 = PlayerPrefs.GetInt("鼠春夏秋冬並木", 0);
                int afterStamp13 = PlayerPrefs.GetInt("達春夏秋冬並木", 0);
                int afterStamp14 = PlayerPrefs.GetInt("超春夏秋冬並木", 0);
                int afterStamp15 = PlayerPrefs.GetInt("神春夏秋冬並木", 0);
                int afterStamp16 = PlayerPrefs.GetInt("完春夏秋冬並木", 0);
                if (beforeStamp1 == 0)
                {
                    if (beforeStamp1 != afterStamp1)
                    {
                        snapbarManager.ShowSnapbar("「亥」のご朱印獲得、おめでとう！", stamp1Image, 3);
                    }
                }
                if (beforeStamp2 == 0)
                {
                    if (beforeStamp2 != afterStamp2)
                    {
                        snapbarManager.ShowSnapbar("「戌」のご朱印獲得、おめでとう！", stamp2Image, 3);
                    }
                }
                if (beforeStamp3 == 0)
                {
                    if (beforeStamp3 != afterStamp3)
                    {
                        snapbarManager.ShowSnapbar("「酉」のご朱印獲得、おめでとう！", stamp3Image, 3);
                    }
                }
                if (beforeStamp4 == 0)
                {
                    if (beforeStamp4 != afterStamp4)
                    {
                        snapbarManager.ShowSnapbar("「申」のご朱印獲得、おめでとう！", stamp4Image, 3);
                    }
                }
                if (beforeStamp5 == 0)
                {
                    if (beforeStamp5 != afterStamp5)
                    {
                        snapbarManager.ShowSnapbar("「未」のご朱印獲得、おめでとう！", stamp5Image, 3);
                    }
                }
                if (beforeStamp6 == 0)
                {
                    if (beforeStamp6 != afterStamp6)
                    {
                        snapbarManager.ShowSnapbar("「午」のご朱印獲得、おめでとう！", stamp6Image, 3);
                    }
                }
                if (beforeStamp7 == 0)
                {
                    if (beforeStamp7 != afterStamp7)
                    {
                        snapbarManager.ShowSnapbar("「巳」のご朱印獲得、おめでとう！", stamp7Image, 3);
                    }
                }
                if (beforeStamp8 == 0)
                {
                    if (beforeStamp8 != afterStamp8)
                    {
                        snapbarManager.ShowSnapbar("「辰」のご朱印獲得、おめでとう！", stamp8Image, 3);
                    }
                }
                if (beforeStamp9 == 0)
                {
                    if (beforeStamp9 != afterStamp9)
                    {
                        snapbarManager.ShowSnapbar("「卯」のご朱印獲得、おめでとう！", stamp9Image, 3);
                    }
                }
                if (beforeStamp10 == 0)
                {
                    if (beforeStamp10 != afterStamp10)
                    {
                        snapbarManager.ShowSnapbar("「寅」のご朱印獲得、おめでとう！", stamp10Image, 3);
                    }
                }
                if (beforeStamp11 == 0)
                {
                    if (beforeStamp11 != afterStamp12)
                    {
                        snapbarManager.ShowSnapbar("「丑」のご朱印獲得、おめでとう！", stamp11Image, 3);
                    }
                }
                if (beforeStamp12 == 0)
                {
                    if (beforeStamp12 != afterStamp12)
                    {
                        snapbarManager.ShowSnapbar("「子」のご朱印獲得、おめでとう！", stamp12Image, 3);
                    }
                }
                if (beforeStamp13 == 0)
                {
                    if (beforeStamp13 != afterStamp13)
                    {
                        snapbarManager.ShowSnapbar("「達」のご朱印獲得、おめでとう！", stamp13Image, 3);
                    }
                }
                if (beforeStamp14 == 0)
                {
                    if (beforeStamp14 != afterStamp14)
                    {
                        snapbarManager.ShowSnapbar("「超」のご朱印獲得、おめでとう！", stamp14Image, 3);
                    }
                }
                if (beforeStamp15 == 0)
                {
                    if (beforeStamp15 != afterStamp15)
                    {
                        snapbarManager.ShowSnapbar("「神」のご朱印獲得、おめでとう！", stamp15Image, 3);
                    }
                }
                if (beforeStamp16 == 0)
                {
                    if (beforeStamp16 != afterStamp16)
                    {
                        snapbarManager.ShowSnapbar("「完」のご朱印獲得、おめでとう！", stamp16Image, 3);
                    }
                }
                /*
                highScoreText.text = message;
                highScoreText2.text = message2;
                highScoreText3.text = message3;
                */
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
                snapbarManager.ShowSnapbar("ログインができません。\nネット環境が良い状態で\n再ログインしてください。", loginErrorImage, 10);
                RequestLeaderBoard();

            }
            );
    }

    /*
    public void RequestLeaderBoard()
    {
        // yield return new WaitForSecondsRealtime(1);
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = SceneManager.GetActiveScene().name,
                StartPosition = 0,
                MaxResultsCount = 10
            },
            result =>
            {
                /*
                result.Leaderboard.ForEach(
                    x => Debug.Log(string.Format("{0}位:{1} スコア{2}", x.Position + 1, x.DisplayName, x.StatValue))
                    );
                */
    /*
    ranking = "";
    for (int i = 0; i < result.Leaderboard.Count; i++)
    {
        var x = result.Leaderboard[i];
        ranking += string.Format("{0}位:{1}:{2}徳", x.Position + 1, x.DisplayName, x.StatValue) + "\n";
    };
    resultCanvas.GetComponent<Transform>().GetChild(8).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = ranking;
    // text.text = ranking;
},
error =>
{
    Debug.Log(error.GenerateErrorReport());
    RequestLeaderBoard();
}
);
}
*/

    IEnumerator Vibrate(int cnt)
    {
        for (int i = 0; i < cnt; i++)
        {

            if (SystemInfo.supportsVibration)
            {
#if UNITY_ANDROID || UNITY_IOS
                Handheld.Vibrate(); // Android/iOS のみの場合
#endif

            }
            yield return new WaitForSeconds(0.6f);
        }
    }

    public void SetSCFlgFalse()
    {
        scFlg = false;
    }

    public bool GetSCFlg()
    {
        return scFlg;
    }

    public void ResultEffect()
    {
        resultEffectFlg = true;
        resultAudio.Play();
    }

    public void ResultEffectOneShot()
    {
        resultAudio.Play();
    }

    public void ResultPattern()
    {
        switch (resultPattern)
        {
            case "一位":
                message = "千早ぶる";
                message2 = "神代もきかず";
                message3 = "えとばしり";

                stampGod.SetActive(true);
                ResultEffect();
                break;

            case "完":
                stampKanso.SetActive(true);
                ResultEffect();
                break;

            case "悟":
                message = "心にも";
                message2 = "あらでうき世に";
                message3 = "ながらへば";
                stampSatori.SetActive(true);
                ResultEffect();
                break;

            case "十位以内":
                message = "駆け抜ける";
                message2 = "えとの姿は";
                message3 = "天つ風";

                stampSuper.SetActive(true);
                ResultEffect();
                break;

            case "百位以内":
                message = "猛者たちの";
                message2 = "ゆくへも知らぬ";
                message3 = "えとの道";

                stampTatsuzin.SetActive(true);
                ResultEffect();
                break;

            case "合格":
                message = "おめでとう";
                message2 = "新たな道で";
                message3 = "遊べるよ！";
                PlayerPrefs.SetInt("合春夏秋冬並木", 1);
                stampGokaku.SetActive(true);
                ResultEffect();
                break;

            case "最高得徳":
                message = "最高点";
                message2 = "次なる敵も";
                message3 = "己のみ";
                if (currentScore < 500)
                {
                    stampMos.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                }
                else if (currentScore < 1500 && currentScore >= 500)
                {
                    stampDog.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                }
                else if (currentScore < 3000 && currentScore >= 1500)
                {
                    stampBird.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                }
                else if (currentScore < 5000 && currentScore >= 3000)
                {
                    stampMonkey.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                }
                else if (currentScore < 7500 && currentScore >= 5000)
                {
                    stampSheep.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                }
                else if (currentScore < 10500 && currentScore >= 7500)
                {
                    stampHorse.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                }
                else if (currentScore < 14000 && currentScore >= 10500)
                {
                    stampSnake.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                }
                else if (currentScore < 18000 && currentScore >= 14000)
                {
                    stampDragon.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                }
                else if (currentScore < 22500 && currentScore >= 18000)
                {
                    stampRabbit.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                }
                else if (currentScore < 27500 && currentScore >= 22500)
                {
                    stampTiger.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                }
                else if (currentScore < 33000 && currentScore >= 27500)
                {
                    stampCaw.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("牛春夏秋冬並木", 1);
                }
                else if (currentScore >= 33000)
                {
                    stampRat.SetActive(true);
                    PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("牛春夏秋冬並木", 1);
                    PlayerPrefs.SetInt("鼠春夏秋冬並木", 1);

                }
                ResultEffect();
                break;

            case "子":
                stampRat.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("鼠春夏秋冬並木", 0) == 0)
                {
                    message = "これやこの";
                    message2 = "誰もが敬う";
                    message3 = "厄祓い";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("鼠春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "これやこの";
                    message2 = "誰もが敬う";
                    message3 = "厄祓い";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                PlayerPrefs.SetInt("牛春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鼠春夏秋冬並木", 1);
                break;

            case "丑":
                stampCaw.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("牛春夏秋冬並木", 0) == 0)
                {
                    message = "君がため";
                    message2 = "まだまだ足らぬ";
                    message3 = "技術力";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("牛春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "君がため";
                    message2 = "まだまだ足らぬ";
                    message3 = "技術力";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                PlayerPrefs.SetInt("牛春夏秋冬並木", 1);
                break;

            case "寅":
                stampTiger.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("虎春夏秋冬並木", 0) == 0)
                {
                    message = "誇らしい";
                    message2 = "山どりの尾の";
                    message3 = "獣道";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("虎春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "誇らしい";
                    message2 = "山どりの尾の";
                    message3 = "獣道";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                PlayerPrefs.SetInt("虎春夏秋冬並木", 1);
                break;

            case "卯":
                stampRabbit.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("兎春夏秋冬並木", 0) == 0)
                {
                    message = "おほけなく";
                    message2 = "";
                    message3 = "";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("兎春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "おほけなく";
                    message2 = "ひょうかをすると";
                    message3 = "やんごとない";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                PlayerPrefs.SetInt("兎春夏秋冬並木", 1);
                break;

            case "辰":
                stampDragon.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("龍春夏秋冬並木", 0) == 0)
                {
                    message = "ほめるにも";
                    message2 = "なおあまりある";
                    message3 = "ゆびさばき";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("龍春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "ほめるにも";
                    message2 = "なおあまりある";
                    message3 = "ゆびさばき";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                PlayerPrefs.SetInt("龍春夏秋冬並木", 1);
                break;

            case "巳":
                stampSnake.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("蛇春夏秋冬並木", 0) == 0)
                {
                    message = "今はただ";
                    message2 = "ほめざるをえぬ";
                    message3 = "そのはしり";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("蛇春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "今はただ";
                    message2 = "ほめざるをえぬ";
                    message3 = "そのはしり";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("蛇春夏秋冬並木", 1);
                break;

            case "午":
                stampHorse.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("馬春夏秋冬並木", 0) == 0)
                {
                    message = "がんばりの";
                    message2 = "しるしなりける";
                    message3 = "５０００てん";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("馬春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "がんばりの";
                    message2 = "しるしなりける";
                    message3 = "５０００てん";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                PlayerPrefs.SetInt("馬春夏秋冬並木", 1);
                break;

            case "未":
                stampSheep.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("羊春夏秋冬並木", 0) == 0)
                {
                    message = "ごうかいに";
                    message2 = "たまぞちりける";
                    message3 = "はしりかた";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("羊春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "ごうかいに";
                    message2 = "たまぞちりける";
                    message3 = "はしりかた";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                PlayerPrefs.SetInt("羊春夏秋冬並木", 1);
                break;

            case "申":
                stampMonkey.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("猿春夏秋冬並木", 0) == 0)
                {
                    message = "あらしふく";
                    message2 = "きみのみちすじ";
                    message3 = "まだのびる";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("猿春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "あらしふく";
                    message2 = "きみのみちすじ";
                    message3 = "まだのびる";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                PlayerPrefs.SetInt("猿春夏秋冬並木", 1);
                break;

            case "酉":
                stampBird.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("鳥春夏秋冬並木", 0) == 0)
                {
                    message = "ひとはいさ";
                    message2 = "こころもしらず";
                    message3 = "みこみあり";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("鳥春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "ひとはいさ";
                    message2 = "こころもしらず";
                    message3 = "みこみあり";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                PlayerPrefs.SetInt("鳥春夏秋冬並木", 1);
                break;

            case "戌":
                stampDog.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("犬春夏秋冬並木", 0) == 0)
                {
                    message = "ひさかたの";
                    message2 = "ひかりのどけき";
                    message3 = "よいはしり";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("犬春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "ひさかたの";
                    message2 = "ひかりのどけき";
                    message3 = "よいはしり";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                PlayerPrefs.SetInt("犬春夏秋冬並木", 1);
                break;

            case "亥":
                stampMos.SetActive(true);
                if (getHighScoreFlg == true && PlayerPrefs.GetInt("猪春夏秋冬並木", 0) == 0)
                {
                    message = "しのぶれど";
                    message2 = "もうすこしだけ";
                    message3 = "がんばろう";
                    ResultEffect();
                }
                else if (getHighScoreFlg == true && PlayerPrefs.GetInt("猪春夏秋冬並木", 0) == 1)
                {
                    message = "最高点";
                    message2 = "次なる敵も";
                    message3 = "己のみ";
                    ResultEffect();
                }
                else
                {
                    message = "しのぶれど";
                    message2 = "もうすこしだけ";
                    message3 = "がんばろう";
                }
                PlayerPrefs.SetInt("猪春夏秋冬並木", 1);
                break;
        }
    }

    public void OpenManualCanvas()
    {
        manualCanvas.SetActive(true);
    }

    public void CloseManualCanvas()
    {
        manualCanvas.SetActive(false);
    }

    public void OpenURL()
    {
        var webViewObject = new GameObject("WebViewObject").AddComponent<WebViewObject>();

        // 初期化
        webViewObject.Init(
            // NOTE: iOSでUIWebViewではなくWKWebViewを利用する(現在はほぼ必須な設定項目だと思ってもらえれば)
            enableWKWebView: true
        );

        // URLを読み込みWebViewを表示する
        webViewObject.SetVisibility(true);
        webViewObject.LoadURL("https://youtu.be/vAbpxrB_EEs?si=7V6t-TiBniw7NmKF");
    }

    public void OpenMovie()
    {
        movie.SetActive(true);
        manual.SetActive(false);

        vp.time = 0;
        // vp.Play();
        // vp.Stop();
    }

    public void CloseMovie()
    {
        moviePlay.SetActive(false);
        movieStop.SetActive(true);
        vp.time = 0;
        vp.Play();
        vp.Stop();
        movie.SetActive(false);
        manual.SetActive(true);

    }

    public void OpenVisualDictionally1()
    {
        vd1.SetActive(true);
        manual.SetActive(false);
    }

    public void CloseVisualDictionally1()
    {
        vd1.SetActive(false);
        manual.SetActive(true);
    }

    public void OpenVisualDictionally2()
    {
        vd2.SetActive(true);
        manual.SetActive(false);
    }

    public void CloseVisualDictionally2()
    {
        vd2.SetActive(false);
        manual.SetActive(true);
    }

    public void OpenVisualDictionally3()
    {
        vd3.SetActive(true);
        manual.SetActive(false);
    }

    public void CloseVisualDictionally3()
    {
        vd3.SetActive(false);
        manual.SetActive(true);
    }

    public void OpenVisualDictionally4()
    {
        vd4.SetActive(true);
        manual.SetActive(false);
    }

    public void CloseVisualDictionally4()
    {
        vd4.SetActive(false);
        manual.SetActive(true);
    }

    public void OpenVisualDictionally5()
    {
        vd5.SetActive(true);
        manual.SetActive(false);
    }

    public void CloseVisualDictionally5()
    {
        vd5.SetActive(false);
        manual.SetActive(true);
    }

    public void MovieBack()
    {
        vp.time -= 5;
    }

    public void MovieGo()
    {
        vp.time += 5;
    }

    public void MoviePlay()
    {
        vp.Play();
        moviePlay.SetActive(false);
        movieStop.SetActive(true);
    }

    public void MovieStop()
    {
        vp.Pause();
        moviePlay.SetActive(true);
        movieStop.SetActive(false);
    }

    public void SetTweet()
    {
        string tweet = currentScore + "の徳を積みました！\n\n#えとばしり！\niOS\nhttps://apps.apple.com/jp/app/%E3%81%88%E3%81%A8%E3%81%B0%E3%81%97%E3%82%8A/id6470151998\nAndroid\nhttps://play.google.com/store/apps/details?id=com.HishoCompany.Chototsumoshin&pcampaignid=web_share";
        twitterShare.SetTweetText(tweet);
        twitterShare.Tweet();
        // GetEn();

    }

    public void SetLine()
    {
        string postMessage;
        if (shareFlg)
        {
            postMessage = "共有は1走りにつき1回までです。";
            snapbarManager.ShowSnapbar(postMessage, enImage, 3);
            return;
        }
        string lineMessage = currentScore + "徳取りました！\n\n#えとばしり！\niOS\nhttps://apps.apple.com/jp/app/%E3%81%88%E3%81%A8%E3%81%B0%E3%81%97%E3%82%8A/id6470151998\nAndroid\nhttps://play.google.com/store/apps/details?id=com.HishoCompany.Chototsumoshin&pcampaignid=web_share";
        lineShare.SetTweetText(lineMessage);
        lineShare.Tweet();
        GetEn();
    }

    public void GetEn()
    {
        string postMessage;


        postMessage = "共有によって追加で" + getMoney + "縁獲得！";
        snapbarManager.ShowSnapbar(postMessage, enImage, 15);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + getMoney);
        money = PlayerPrefs.GetInt("Money", 0);
        resultMoney.text = "所持金：" + money + "縁";
        shareFlg = true;
    }

    public int GetTotalPoint()
    {
        return bomPoint;
    }

    public bool GetChototsuFlg()
    {
        return chototsuFlg;
    }

    public void OpenRule()
    {
        ruleView.SetActive(true);
        illustratedBookView.SetActive(false);
    }

    public void OpenIllustratedBook()
    {
        ruleView.SetActive(false);
        illustratedBookView.SetActive(true);
    }

    public int GetShiki()
    {
        return shiki;
    }




    /*
        public void BlackCanvasStart()
        {
            blackCanvas.GetComponent<BlackCanvas>().StartFlgTrue();
        }
        public void BlackCanvasEnd()
        {
            blackCanvas.SetActive(true);
            blackCanvas.GetComponent<BlackCanvas>().EndFlgTrue();
        }
    */
    public void GotoDemo()
    {
        SceneManager.LoadScene("Demo");
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Enemy : MonoBehaviour
{
    public int life;
    public Text lifeUI;
    public GameObject player;
    public float lifeTime;
    public int attackPoint;
    public string name;
    public bool rightMoveFlg;
    public bool leftMoveFlg;
    public bool frontMoveFlg;
    public bool backMoveFlg;
    public Vector3 startPosition;
    public int flgJudgeNum;
    public Animator bomberAnim;
    public bool blowFlg;
    public Vector3 blowingDir;
    public bool rankingFlg;
    public bool justFlg;
    public GameObject center;
    public Canvas getPoint;
    public int point;
    public bool bomFlg;
    public bool chinowaFlg;
    public GameObject weapon;
    public GameObject mure;
    public Canvas getPointIns;
    public GameObject blast;
    public GameObject sweetSpot;
    public GameObject sweetSpot1;
    public GameObject sweetSpot2;
    public GameObject sweetSpot3;
    public GameObject sweetSpot4;
    public GameObject sweetSpot5;
    public GameObject sweetSpot6;
    public GameObject sweetSpot7;
    public GameObject sweetSpot8;
    public GameObject sweetSpot9;
    public GameObject sweetSpot10;
    public GameObject sweetSpot11;
    public GameObject sweetSpot12;
    public GameObject sweetSpot13;
    public GameObject sweetSpot14;
    public GameObject sweetSpot15;
    public GameObject sweetSpot16;
    public GameObject sweetSpot17;
    public bool sweetSpotFlg;
    public float sweetSpotRange;
    public Quaternion playerRot;
    public Player playerClass;
    public Vector3 etopDir;
    public Vector3 playerDir;
    public float plusAngle;
    public int levelPoint;
    public GameObject hitEffect;
    public GameObject hitEffectS;
    public GameObject sonicMove;
    public bool hitStopFlg;
    public float hitsStopX;
    public float gear0;
    public float gear1;
    public float gear2;
    public float gear3;
    public float gear4;
    public ParticleSystem particle;
    public AudioSource audioSource;
    public AudioClip bomSE;
    public AudioClip blowSE;
    public float baseSpeed;
    public float fireTime;
    public GameObject fire;
    public bool fireFlg;
    public AudioSource snowBallAudio;
    public bool amaterasuFlg;
    public int rensaPoint;
    public GameObject windArrow;
    public bool windArrowScaleFlg;
    public float kingSpeed;
    public int murePoint;
    public int chototsuPoint;
    public int amaterasuPoint;
    public Vector3 hitPos;
    public bool hitEffectFlg;
    public ParticleSystem blowParticle;
    public ParticleSystem tokuParticle;
    public SpriteRenderer shadow;
    public SpriteRenderer sr;
    public float waveVector;
    public Vector3 waveMove;
    public string waveLR;
    public bool startFlg;
    public Vector3 initialScale;
    public float shiki;

    // public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {

        // rankingFlg = DrawLine.instance.GetRankingFlg();
        rankingFlg = false;
        Invoke(nameof(SetStartFlgTrue), Random.Range(0, 1.5f));
        // levelPoint = Mathf.FloorToInt(PlayerPrefs.GetInt("levelPoint", 0));
        /*
        int levelPointMainus = 0;
        int levelPointTotal = PlayerPrefs.GetInt("LevelPoint", 0);
        for(int i = 0;i < 101; i++)
        {
            
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
            if(levelPointTotal >= levelPointMainus)
            {
                levelPointTotal -= levelPointMainus;
            }
            else
            {
                levelPoint = i;
                break;
            }
            
            
            
        }
        */
        switch (SceneManager.GetActiveScene().name)
        {
            case "Nonbirisogen":
                levelPoint = PlayerPrefs.GetInt("NonbirisogenLevel", 0) + PlayerPrefs.GetInt("悟のんびり草原", 0) * 12;
                break;

            case "Mugen":
                // levelPoint = PlayerPrefs.GetInt("ShunkashutonamikiLevel", 0) + PlayerPrefs.GetInt("悟春夏秋冬並木", 0) * 12;
                levelPoint = 0;
                // Debug.Log(levelPoint);
                break;

            case "Togenkyosekiranun":
                levelPoint = PlayerPrefs.GetInt("TogenkyosekiranunLevel", 0) + PlayerPrefs.GetInt("悟桃源郷積乱雲", 0) * 12;
                break;
        }
        // Debug.Log(levelPoint);
        // levelPoint = 1;

        /*
        if (rankingFlg)
        {
            controller = GameSystem.instance;
        }
        else 
        {
            controller = GameSystemTrick.instance;
        }
        */
        flgJudgeNum = Random.Range(0, 2);
        if (flgJudgeNum == 0)
        {
            rightMoveFlg = true;
            leftMoveFlg = false;
            // frontMoveFlg = false;
            // backMoveFlg = true;

            // transform.localScale = new Vector3(-1, 2, 1);

            kingSpeed = kingSpeed * -1;
        }
        else if (flgJudgeNum == 1)
        {
            rightMoveFlg = false;
            leftMoveFlg = true;
            // frontMoveFlg = false;
            // backMoveFlg = true;

            // transform.localScale = new Vector3(1, 2, 1);
        }
        if (name == "KingBomber")
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
                    break;

                case 1:
                    transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
                    break;
            }
        }
        startPosition = transform.position;
        if (name == "ShoteBomber")
        {
            shiki = GameSystemTrick.instance.GetShiki() * 0.2f;
            initialScale = new Vector3(transform.localScale.x - shiki, transform.localScale.y - shiki, transform.localScale.z);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        playerClass = player.GetComponent<Player>();
        // lifeTime = 0.3f + PlayerPrefs.GetInt("BlowLifeTime",0) * 0.1f;
        // lifeTime = 1f + GameSystemTrick.instance.GetTotalPoint() * 0.00001f;
        lifeTime = 1.5f;
        if (name == "GoldenBomber")
        {
            lifeTime = 5f;
        }
        if (name == "KingBomber")
        {
            lifeTime = 5f;
        }

        if (name == "FireBomber")
        {
            lifeTime = 5f;
        }

        // life = Random.Range(1,6);
        // lifeUI.text = life.ToString();
        // player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(hitStopFlg)
        {
            // transform.position = new Vector3(hitsStopX + Random.Range(-0.3f,0.3f), transform.position.y + 0.2f, transform.position.z);
            transform.position = new Vector3(hitsStopX + Random.Range(-0.3f,0.3f), transform.position.y, transform.position.z);
            return;
        }
        */
        if (sweetSpotFlg)
        {
            /*
            Debug.Log(player.transform.rotation.z);
            sweetSpot1.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot2.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot3.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot4.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot5.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot6.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot7.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot8.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot9.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot10.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot11.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot12.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot13.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot14.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot15.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot16.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            sweetSpot17.transform.rotation = Quaternion.Euler(0.0f,0.0f,(player.transform.rotation.z + -40f * sweetSpotRange) * 50);
            */
            etopDir = center.transform.position - player.transform.position;
            playerDir = playerClass.GetDir();
            playerRot = player.transform.rotation;
            plusAngle = Vector3.SignedAngle(etopDir, playerDir, Vector3.forward);

            if (plusAngle > 90f)
            {
                plusAngle = 90;
            }
            else if (plusAngle < -90f)
            {
                plusAngle = -90;
            }
            else if (plusAngle <= 90f && plusAngle >= -90f)
            {
                plusAngle = plusAngle * -4f;
            }


            // Debug.Log(plusAngle);


            windArrow.transform.rotation = playerRot * Quaternion.AngleAxis(0 * sweetSpotRange + plusAngle, Vector3.forward);
            if (1.2f < windArrow.transform.localScale.x)
            {
                windArrowScaleFlg = false;
            }
            if (1f > windArrow.transform.localScale.x)
            {
                windArrowScaleFlg = true;
            }
            if (windArrowScaleFlg)
            {
                windArrow.transform.localScale += new Vector3(2, 2, 0) * Time.deltaTime;
            }
            else
            {
                windArrow.transform.localScale -= new Vector3(2, 2, 0) * Time.deltaTime;
            }

            sweetSpot.transform.rotation = playerRot * Quaternion.AngleAxis(0 * sweetSpotRange + plusAngle, Vector3.forward);
            /*20230810
            sweetSpot1.transform.rotation = playerRot * Quaternion.AngleAxis(-40 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot2.transform.rotation = playerRot * Quaternion.AngleAxis(-35 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot3.transform.rotation = playerRot * Quaternion.AngleAxis(-30 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot4.transform.rotation = playerRot * Quaternion.AngleAxis(-25 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot5.transform.rotation = playerRot * Quaternion.AngleAxis(-20 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot6.transform.rotation = playerRot * Quaternion.AngleAxis(-15 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot7.transform.rotation = playerRot * Quaternion.AngleAxis(-10 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot8.transform.rotation = playerRot * Quaternion.AngleAxis(-5 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot9.transform.rotation = playerRot * Quaternion.AngleAxis(0 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot10.transform.rotation = playerRot * Quaternion.AngleAxis(5 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot11.transform.rotation = playerRot * Quaternion.AngleAxis(10 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot12.transform.rotation = playerRot * Quaternion.AngleAxis(15 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot13.transform.rotation = playerRot * Quaternion.AngleAxis(20 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot14.transform.rotation = playerRot * Quaternion.AngleAxis(25 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot15.transform.rotation = playerRot * Quaternion.AngleAxis(30 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot16.transform.rotation = playerRot * Quaternion.AngleAxis(35 * sweetSpotRange + plusAngle, Vector3.forward);
            sweetSpot17.transform.rotation = playerRot * Quaternion.AngleAxis(40 * sweetSpotRange + plusAngle, Vector3.forward);
            /*
            sweetSpot1.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-40f * sweetSpotRange, Vector3.forward);
            sweetSpot2.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-35f * sweetSpotRange, Vector3.forward);
            sweetSpot3.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-30f * sweetSpotRange, Vector3.forward);
            sweetSpot4.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-25f * sweetSpotRange, Vector3.forward);
            sweetSpot5.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-20f * sweetSpotRange, Vector3.forward);
            sweetSpot6.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-15f * sweetSpotRange, Vector3.forward);
            sweetSpot7.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-10f * sweetSpotRange, Vector3.forward);
            sweetSpot8.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-5f * sweetSpotRange, Vector3.forward);
            sweetSpot9.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(0 * sweetSpotRange, Vector3.forward);
            sweetSpot10.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(5f * sweetSpotRange, Vector3.forward);
            sweetSpot11.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(10f * sweetSpotRange, Vector3.forward);
            sweetSpot12.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(15f * sweetSpotRange, Vector3.forward);
            sweetSpot13.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(20f * sweetSpotRange, Vector3.forward);
            sweetSpot14.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(25f * sweetSpotRange, Vector3.forward);
            sweetSpot15.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(30f * sweetSpotRange, Vector3.forward);
            sweetSpot16.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(35f * sweetSpotRange, Vector3.forward);
            sweetSpot17.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(40f * sweetSpotRange, Vector3.forward);
            
            /*
            sweetSpot1.transform.rotation = playerRot * Quaternion.AngleAxis(-40f * sweetSpotRange, Vector3.forward);
            sweetSpot2.transform.rotation = playerRot * Quaternion.AngleAxis(-35f * sweetSpotRange, Vector3.forward);
            sweetSpot3.transform.rotation = playerRot * Quaternion.AngleAxis(-30f * sweetSpotRange, Vector3.forward);
            sweetSpot4.transform.rotation = playerRot * Quaternion.AngleAxis(-25f * sweetSpotRange, Vector3.forward);
            sweetSpot5.transform.rotation = playerRot * Quaternion.AngleAxis(-20f * sweetSpotRange, Vector3.forward);
            sweetSpot6.transform.rotation = playerRot * Quaternion.AngleAxis(-15f * sweetSpotRange, Vector3.forward);
            sweetSpot7.transform.rotation = playerRot * Quaternion.AngleAxis(-10f * sweetSpotRange, Vector3.forward);
            sweetSpot8.transform.rotation = playerRot * Quaternion.AngleAxis(-5f * sweetSpotRange, Vector3.forward);
            sweetSpot9.transform.rotation = playerRot * Quaternion.AngleAxis(0 * sweetSpotRange, Vector3.forward);
            sweetSpot10.transform.rotation = playerRot * Quaternion.AngleAxis(5f * sweetSpotRange, Vector3.forward);
            sweetSpot11.transform.rotation = playerRot * Quaternion.AngleAxis(10f * sweetSpotRange, Vector3.forward);
            sweetSpot12.transform.rotation = playerRot * Quaternion.AngleAxis(15f * sweetSpotRange, Vector3.forward);
            sweetSpot13.transform.rotation = playerRot * Quaternion.AngleAxis(20f * sweetSpotRange, Vector3.forward);
            sweetSpot14.transform.rotation = playerRot * Quaternion.AngleAxis(25f * sweetSpotRange, Vector3.forward);
            sweetSpot15.transform.rotation = playerRot * Quaternion.AngleAxis(30f * sweetSpotRange, Vector3.forward);
            sweetSpot16.transform.rotation = playerRot * Quaternion.AngleAxis(35f * sweetSpotRange, Vector3.forward);
            sweetSpot17.transform.rotation = playerRot * Quaternion.AngleAxis(40f * sweetSpotRange, Vector3.forward);
            */
        }
        //transform.Translate(Vector2.up * Time.deltaTime);
        // transform.position += new Vector3(1, 0, 0)  * Time.deltaTime;
        if (blowFlg)
        {
            if (hitEffectFlg)
            {
                transform.position = new Vector3(hitPos.x + Random.Range(-0.2f, 0.2f), hitPos.y, hitPos.z);
                /*
                transform.position = hitPos + blowingDir.normalized * Time.deltaTime * 5;
                hitPos = transform.position;
                transform.position = new Vector3(hitPos.x + Random.Range(-0.5f,0.5f), hitPos.y , hitPos.z);
                */

                return;
            }
            switch (name)
            {
                case "ShoteBomber":
                    transform.position += blowingDir.normalized * Time.deltaTime * 25;
                    break;

                case "Bomber":
                    transform.position += blowingDir.normalized * Time.deltaTime * 25;
                    /*
                    if(getPointIns != null)
                    {
                        // getPointIns.transform.position += blowingDir.normalized * Time.deltaTime * 25;
                        getPointIns.transform.position = transform.position + new Vector3(0,1,0);  
                    }
                    */
                    break;

                case "RollingBomber":
                    transform.position += blowingDir.normalized * Time.deltaTime * 25;
                    /*
                    if(getPointIns != null)
                    {
                        // getPointIns.transform.position += blowingDir.normalized * Time.deltaTime * 25;  
                        getPointIns.transform.position = transform.position + new Vector3(0,1,0);  
                    }
                    */
                    break;

                case "PitchBomber":
                    transform.position += blowingDir.normalized * Time.deltaTime * 25;
                    /*
                    if(getPointIns != null)
                    {
                        // getPointIns.transform.position += blowingDir.normalized * Time.deltaTime * 25;  
                        getPointIns.transform.position = transform.position + new Vector3(0,1,0);  
                    }
                    */
                    break;

                case "SmallBomber":
                    transform.position += blowingDir.normalized * Time.deltaTime * 35;
                    /*
                    if(getPointIns != null)
                    {
                        // getPointIns.transform.position += blowingDir.normalized * Time.deltaTime * 35;  
                        getPointIns.transform.position = transform.position + new Vector3(0,1,0);  
                    }
                    */
                    break;

                case "FireBomber":

                    transform.position += blowingDir.normalized * Time.deltaTime * 25;
                    /*
                    fireTime += Time.deltaTime;
                    if(fireTime > 0.7f && fireFlg)
                    {
                        Instantiate(fire,transform.position,transform.rotation);
                        fireTime = 0;
                    }
                    
                    if(getPointIns != null)
                    {
                        // getPointIns.transform.position += blowingDir.normalized * Time.deltaTime * 25;  
                        getPointIns.transform.position = transform.position + new Vector3(0,1,0);  
                    }
                    */
                    break;

                case "GoldenBomber":
                    transform.position += blowingDir.normalized * Time.deltaTime * 25;
                    break;

                case "KingBomber":
                    transform.position += blowingDir.normalized * Time.deltaTime * 35;
                    break;

            }


            return;
        }

        switch (name)
        {
            case "RollingBomber":

                if (rightMoveFlg)
                {
                    // transform.Translate(new Vector2(0.5f, transform.position.y));
                    transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
                    // transform.rotation = Quaternion.Euler(0, 180, 0);
                    bomberAnim.SetInteger("RollingIdle", 2);
                    // transform.RotateAround(new Vector3(transform.position.x, transform.position.y - 2, 0), Vector3.forward , -5f);
                    // transform.rotation = Quaternion.AngleAxis(360 / 2 * Time.deltaTime, new Vector3(transform.position.x, transform.position.y - 2, 0));
                    // transform.rotation = transform.rotation * Quaternion.AngleAxis(-2, new Vector3(0, 0, 1));
                    /*
                    sweetSpot1.transform.rotation = sweetSpot1.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot2.transform.rotation = sweetSpot2.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot3.transform.rotation = sweetSpot3.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot4.transform.rotation = sweetSpot4.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot5.transform.rotation = sweetSpot5.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot6.transform.rotation = sweetSpot6.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot7.transform.rotation = sweetSpot7.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot8.transform.rotation = sweetSpot8.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot9.transform.rotation = sweetSpot9.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot10.transform.rotation = sweetSpot10.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot11.transform.rotation = sweetSpot11.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot12.transform.rotation = sweetSpot12.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot13.transform.rotation = sweetSpot13.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot14.transform.rotation = sweetSpot14.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot15.transform.rotation = sweetSpot15.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot16.transform.rotation = sweetSpot16.transform.rotation * Quaternion.Euler (0, 180, 0);
                    sweetSpot17.transform.rotation = sweetSpot17.transform.rotation * Quaternion.Euler (0, 180, 0);
                    */
                }

                if (leftMoveFlg)
                {
                    transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
                    // transform.rotation = Quaternion.Euler(0, 0, 0);
                    bomberAnim.SetInteger("RollingIdle", 1);
                    //transform.Translate(new Vector2(-0.5f, transform.position.y));
                    // transform.rotation = Quaternion.AngleAxis(360, new Vector3(transform.position.x, transform.position.y - 2, 0));
                }

                if (transform.position.x > 2.1f)
                {
                    rightMoveFlg = false;
                    leftMoveFlg = true;
                    // transform.localScale = new Vector3(1, 1, 1);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    bomberAnim.SetInteger("RollingIdle", 2);
                    // transform.rotation = transform.rotation * Quaternion.AngleAxis(180, new Vector3(0, 1, 0));
                }

                if (transform.position.x < -2.1f)
                {
                    rightMoveFlg = true;
                    leftMoveFlg = false;
                    // transform.localScale = new Vector3(-1, 1, 1);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    bomberAnim.SetInteger("RollingIdle", 1);
                    // transform.rotation = transform.rotation * Quaternion.AngleAxis(-180, new Vector3(0, 1, 0));
                }
                break;

            case "PitchBomber":
                if (frontMoveFlg)
                {

                    // transform.Translate(new Vector2(0.5f, transform.position.y));
                    transform.position -= new Vector3(0, 3f, 0) * Time.deltaTime;
                    // Debug.Log("move");
                    // transform.RotateAround(new Vector3(transform.position.x, transform.position.y - 2, 0), Vector3.forward , -5f);
                    // transform.rotation = Quaternion.AngleAxis(360 / 2 * Time.deltaTime, new Vector3(transform.position.x, transform.position.y - 2, 0));
                    // transform.rotation = transform.rotation * Quaternion.AngleAxis(-2, new Vector3(0, 0, 1));
                }
                /*
                if(backMoveFlg)
                {
                    transform.position += new Vector3(0, -1, 0)  * Time.deltaTime;
                    //transform.Translate(new Vector2(-0.5f, transform.position.y));
                    // transform.rotation = Quaternion.AngleAxis(360, new Vector3(transform.position.x, transform.position.y - 2, 0));
                }
                */

                /*
                if(transform.position.y - startPosition.y < 2.1f || transform.position.y - startPosition.y > 2.1f)
                {
                    rightMoveFlg = false;
                    leftMoveFlg = false;
                    // transform.rotation = transform.rotation * Quaternion.AngleAxis(180, new Vector3(0, 1, 0));
                }
                */
                break;

            case "KingBomber":


                KingMove();
                break;

        }
        /*
        if (player.transform.position.y - transform.position.y > 19.2)
        {
            Destroy(gameObject);
        }
        

        lifeTime += Time.deltaTime;
        if(lifeTime > 15)
        {
            gameObject.SetActive(false);
        }
        */

    }

    void LateUpdate()
    {
        // アニメーションが適用された後に、相対的なスケールを再適用
        if (name == "ShoteBomber")
        {
            transform.localScale = Vector3.Scale(initialScale, transform.localScale);
        }
    }

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
            if(name == "PitchBomber")
            {
                collision.gameObject.SetActive(false);
            }
            break;

            case "LifeThread":
            // gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            break;

            case "Tori":
            // gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            break;

            case "Obstacle":
            // gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            break;

            case "Cleaner":
            if (blowFlg)
            {
                blowFlg = false;
                return;
            }
            GameSystem.instance.LostLife(attackPoint);
            gameObject.SetActive(false);
            break;

            /*
            case "Player":
            bomberAnim.SetBool("BomFlg", true);
            StartCoroutine(SetBomFlgFalse());
            break;
            

        }
    }
    */

    public void KingMove()
    {
        transform.RotateAround(new Vector3(0, startPosition.y, startPosition.z), Vector3.forward, kingSpeed * Time.deltaTime);
        if (kingSpeed > 0 && transform.position.y > startPosition.y)
        {
            bomberAnim.SetInteger("KingIdle", 1);
        }

        if (kingSpeed > 0 && transform.position.y < startPosition.y)
        {
            bomberAnim.SetInteger("KingIdle", 0);
        }

        if (kingSpeed < 0 && transform.position.y > startPosition.y)
        {
            bomberAnim.SetInteger("KingIdle", 0);
        }

        if (kingSpeed < 0 && transform.position.y < startPosition.y)
        {
            bomberAnim.SetInteger("KingIdle", 1);
        }

    }

    public void SetStartFlgTrue()
    {
        startFlg = true;
    }

    public bool GetStartFlg()
    {
        return startFlg;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Instantiate(hitEffect,(collision.gameObject.transform.position + transform.position)/2 + (transform.position - collision.gameObject.transform.position).normalized * 3, Quaternion.FromToRotation(Vector3.up,(transform.position - collision.gameObject.transform.position )));
        switch (collision.gameObject.tag)
        {
            case "Player":
                /*
                if(blowFlg)
                {
                    blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                    return;
                }
                */
                // Instantiate(hitEffect,(collision.gameObject.transform.position + transform.position)/2 + (transform.position - collision.gameObject.transform.position).normalized * 3, Quaternion.FromToRotation(Vector3.up,(transform.position - collision.gameObject.transform.position )));
                break;

            case "Enemy":
                Invoke("Bom", lifeTime);
                break;

            case "Mure":
                /*
                blowFlg = true;
                justFlg = true;
                blowingDir = ((center.transform.position - collision.gameObject.GetComponent<Weapon>().center.transform.position) + blowingDir);
                GetPoint(2);
                Invoke("Bom", 0.7f);
                */
                // Debug.Log("Mure1");
                if (blowFlg)
                {

                    blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);

                    return;
                }
                if (name == "FireBomber")
                {
                    justFlg = true;
                }
                if (name == "KingBomber")
                {
                    justFlg = true;
                }
                if (name == "PitchBomber")
                {
                    particle.Stop();
                }
                Bom();
                /*
                blowingDir = center.transform.position - collision.gameObject.transform.position;
                blowFlg = true;
                // Debug.Log("Just");
                // justFlg = true;
                // GetComponent<Rigidbody2D>().AddForce(blowingDir * 3);
                Invoke(nameof(Bom), lifeTime);
                */

                if (rankingFlg)
                {
                    GameSystem.instance.Critical();
                }
                else
                {
                    GameSystemTrick.instance.Critical();
                }
                GetPoint(5);

                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (bomFlg)
        {
            return;
        }
        /*
        if (justFlg)
        {
            if(rankingFlg)
            {
                GameSystem.instance.Critical();
            }
            else
            {
                GameSystemTrick.instance.Critical();
            }
            
        }
        */
        switch (collision.gameObject.tag)
        {
            case "Mure":
                if (bomFlg || blowFlg)
                {
                    blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                    // Instantiate(hitEffectS,(collision.gameObject.transform.position + transform.position)/2, Quaternion.FromToRotation(Vector3.up,(transform.position - collision.gameObject.transform.position )));
                    // tokuParticle.Play();
                    rensaPoint++;
                    if (rensaPoint == 1 && GetName() == "GoldenBomber")
                    {
                        GetPoint(100 * 2 - 1000);
                    }
                    else if (rensaPoint == 1 && GetName() != "GoldenBomber")
                    {
                        GetPoint(100 * 2 - 10);
                    }
                    else
                    {
                        GetPoint(100);
                    }
                    return;
                }
                if (sweetSpotFlg)
                {
                    sweetSpotFlg = false;
                    windArrow.SetActive(false);
                    sweetSpot.SetActive(false);
                }

                audioSource.PlayOneShot(blowSE);
                if (name == "FireBomber")
                {
                    fireFlg = false;
                    justFlg = true;
                }
                if (name == "KingBomber")
                {
                    fireFlg = false;
                    justFlg = true;
                }
                if (name == "PitchBomber")
                {
                    particle.Stop();
                }
                blowFlg = true;
                justFlg = true;
                blowingDir = center.transform.position - collision.gameObject.transform.position;
                Invoke("Bom", lifeTime);

                switch (name)
                {
                    case "ShoteBomber":
                        murePoint = 100;
                        break;

                    case "Bomber":
                        murePoint = 100;
                        break;

                    case "RollingBomber":
                        murePoint = 100;
                        break;

                    case "PitchBomber":
                        murePoint = 100;
                        break;

                    case "SmallBomber":
                        murePoint = 100;
                        break;

                    case "FireBomber":
                        murePoint = 100;
                        break;

                    case "GoldenBomber":
                        murePoint = 1000;
                        break;

                    case "KingBomber":
                        murePoint = 100;
                        break;
                }
                GetPoint(murePoint);
                Instantiate(hitEffectS, (collision.gameObject.transform.position + transform.position) / 2, Quaternion.FromToRotation(Vector3.up, (transform.position - collision.gameObject.transform.position)));
                Instantiate(sonicMove, transform.position, Quaternion.identity);
                break;

            case "Enemy":
                if (!startFlg)
                {
                    gameObject.SetActive(false);
                }
                Enemy cge = collision.gameObject.GetComponent<Enemy>();

                if (!cge.GetStartFlg())
                {
                    return;
                }
                /*
                if(justFlg)
                {
                    if(rankingFlg)
                    {
                        GameSystem.instance.Critical();
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                    }
                    GetPoint(300);
                    return;
                }
                */
                if (sweetSpotFlg)
                {
                    sweetSpotFlg = false;
                    windArrow.SetActive(false);
                    sweetSpot.SetActive(false);
                }

                if (name == "PitchBomber")
                {
                    particle.Stop();
                }
                // fireFlg = true;
                audioSource.PlayOneShot(blowSE);
                // blowingDir = ((center.transform.position - collision.gameObject.GetComponent<Enemy>().center.transform.position) + blowingDir);
                /*　
                if(!blowFlg)
                {
                    Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
                    baseSpeed = enemyScript.GetBaseSpeed();
                    point += enemyScript.RetrunPoint() + 20;
                    Invoke("Bom", 1 + lifeTime * 0.01f);
                    // Instantiate(hitEffect,(collision.gameObject.transform.position + transform.position)/2 + (transform.position - collision.gameObject.transform.position).normalized * 3, Quaternion.FromToRotation(Vector3.up,(transform.position - collision.gameObject.transform.position )));
                    if(rankingFlg)
                    {
                        GameSystem.instance.Critical();
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                    }
                }
                */

                if (blowFlg && !cge.GetBlowFlg())
                {
                    /*
                    if(cge.GetName() == "GoldenBomber")
                    {
                        cge.SetJustFlg();
                        cge.Blow(center.transform.position, new Vector3(0,1,0), 1);
                        Debug.Log("Golden");
                        return;
                    }
                    */
                    rensaPoint++;
                    int num = 0;
                    int eneNum = 0;
                    switch (name)
                    {
                        case "ShoteBomber":
                            num = 10;
                            break;

                        case "Bomber":
                            num = 10;
                            break;

                        case "RollingBomber":
                            num = 10;
                            break;

                        case "PitchBomber":
                            num = 10;
                            break;

                        case "SmallBomber":
                            num = 10;
                            break;

                        case "FireBomber":
                            num = 10;
                            break;

                        case "GoldenBomber":
                            num = 1000;
                            break;

                        case "KingBomber":
                            num = 10;
                            break;
                    }
                    switch (cge.GetName())
                    {
                        case "ShoteBomber":
                            eneNum = 100;
                            break;

                        case "Bomber":
                            eneNum = 100;
                            break;

                        case "RollingBomber":
                            eneNum = 100;
                            break;

                        case "PitchBomber":
                            eneNum = 100;
                            break;

                        case "SmallBomber":
                            eneNum = 100;
                            break;

                        case "FireBomber":
                            eneNum = 100;
                            break;

                        case "GoldenBomber":
                            eneNum = 1000;
                            break;

                        case "KingBomber":
                            eneNum = 100;
                            break;
                    }
                    if (rensaPoint == 1 && num == 1000)
                    {
                        GetPoint(eneNum);
                    }
                    else if (rensaPoint == 1 && num != 1000)
                    {
                        GetPoint(eneNum * 2 - num);
                    }
                    else
                    {
                        GetPoint(eneNum);
                    }

                }
                else if (blowFlg && cge.GetBlowFlg())
                {
                    blowingDir = ((center.transform.position - cge.center.transform.position) + blowingDir);
                }



                if (!blowFlg)
                {
                    /*
                    if(name == "GoldenBomber")
                    {
                        return;
                    }
                    */
                    bomFlg = false;
                    // gameObject.SetActive(false);
                    Bom();
                    if (rankingFlg)
                    {
                        GameSystem.instance.Critical();
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                    }

                    return;
                }
                // blowFlg = true;
                // GetPoint(5 * GameObject.FindWithTag("Player").GetComponent<Player>().GetGear()); ここ

                // gameObject.transform.localScale = gameObject.transform.localScale * 2f;

                break;

            case "Weapon":
                blowFlg = true;
                // justFlg = true;
                blowingDir = ((center.transform.position - collision.gameObject.GetComponent<Weapon>().center.transform.position) + blowingDir);
                // Instantiate(hitEffect,(collision.gameObject.transform.position + transform.position)/2 + (transform.position - collision.gameObject.transform.position).normalized * 3, Quaternion.FromToRotation(Vector3.up,(transform.position - collision.gameObject.transform.position )));
                GetPoint(5);
                Invoke("Bom", 0.7f);
                break;

            case "SnowBall":
                snowBallAudio = GameObject.FindWithTag("SnowBallSound").GetComponent<AudioSource>();
                snowBallAudio.Play();
                // Bom();
                break;



            case "Chinowa":
                if (!blowFlg)
                {
                    return;
                }
                chinowaFlg = true;
                Invoke("Bom", 0.1f);
                break;

            case "ChinowaPart":
                if (!blowFlg)
                {
                    return;
                }
                blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                GetPoint(5);
                // Debug.Log("aaa");
                break;

            case "LifeThread":
                // gameObject.SetActive(false);
                if (justFlg)
                {
                    if (rankingFlg)
                    {
                        GameSystem.instance.Critical();
                        GameSystem.instance.GetLifeThread();
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                        GameSystemTrick.instance.GetLifeThread();
                    }
                    collision.gameObject.SetActive(false);
                    return;
                }
                Bom();
                collision.gameObject.SetActive(false);
                break;

            case "Tori":
                blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                // GameObject.FindWithTag("Player").GetComponent<Player>().CollisionTori(collision.gameObject);
                break;

            case "MureSymbol":
                blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                // GameObject.FindWithTag("Player").GetComponent<Player>().CollisionMureSymbol(collision.gameObject);
                break;

            case "AmaterasuSymbol":
                blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                // GameObject.FindWithTag("Player").GetComponent<Player>().CollisionAmaterasuSymbol(collision.gameObject);
                break;

            case "ShiroTori":
                if (justFlg)
                {
                    if (rankingFlg)
                    {
                        GameSystem.instance.Critical();
                        GameSystem.instance.GetTori("ShiroTori");
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                        GameSystemTrick.instance.GetTori("ShiroTori");
                    }
                    collision.gameObject.SetActive(false);
                    return;
                }
                // gameObject.SetActive(false);
                Bom();
                collision.gameObject.SetActive(false);
                break;

            case "Obstacle":
                // gameObject.SetActive(false);
                /*
                if(justFlg)
                {
                    if(rankingFlg)
                    {
                        GameSystem.instance.Critical();
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                    }
                    // collision.gameObject.SetActive(false);
                    // return;
                    point += 500;
                }
                Bom();
                */
                if (blowFlg)
                {
                    // GetPoint(1);
                    blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                }

                // collision.gameObject.SetActive(false);
                break;

            case "Bubble":
                if (blowFlg)
                {
                    // GetPoint(1);
                    lifeTime += 0.5f;
                    blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                }
                break;

            case "Amaterasu":
                if (!blowFlg)
                {
                    return;
                }
                if (amaterasuFlg)
                {
                    return;
                }
                amaterasuFlg = true;
                blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                rensaPoint++;

                switch (name)
                {
                    case "ShoteBomber":
                        amaterasuPoint = 100;
                        break;

                    case "Bomber":
                        amaterasuPoint = 100;
                        break;

                    case "RollingBomber":
                        amaterasuPoint = 100;
                        break;

                    case "PitchBomber":
                        amaterasuPoint = 100;
                        break;

                    case "SmallBomber":
                        amaterasuPoint = 100;
                        break;

                    case "FireBomber":
                        amaterasuPoint = 100;
                        break;

                    case "GoldenBomber":
                        amaterasuPoint = 1000;
                        break;

                    case "KingBomber":
                        amaterasuPoint = 100;
                        break;
                }
                GetPoint(1000 * rensaPoint);
                collision.gameObject.GetComponent<Amaterasu>().Flare();
                break;

            case "Wall":

                if (blowFlg)
                {
                    blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                    // GetPoint(1);
                    return;

                }

                Bom();
                break;

            case "Cleaner":
                if (blowFlg)
                {
                    // SetActiveFalse();
                    // blowFlg = false;
                    // gameObject.SetActive(false);
                    return;
                }
                Instantiate(blast, transform.position, transform.rotation);
                if (rankingFlg)
                {
                    GameSystem.instance.LostLife(attackPoint);
                    gameObject.SetActive(false);
                }
                else
                {
                    GameSystemTrick.instance.LostLife();
                    gameObject.SetActive(false);
                }
                // gameObject.SetActive(false);
                break;

            case "BoundWall":
                Vector3 boundDir = collision.gameObject.transform.position - transform.position;
                if (name == "FireBomber" && fireFlg && boundDir.y > 0)
                {
                    Instantiate(fire, transform.position, transform.rotation);
                    fireFlg = false;
                    return;
                }
                if (name == "KingBomber" && fireFlg && boundDir.y > 0)
                {
                    Instantiate(fire, transform.position, transform.rotation);
                    fireFlg = false;
                    return;
                }
                if (boundDir.y > 0) { Bom(); }
                if (blowFlg)
                {
                    if ((boundDir.y < 0 && blowingDir.y < 0) || (boundDir.y > 0 && blowingDir.y > 0))
                    {
                        blowingDir = new Vector3(blowingDir.x, blowingDir.y * -1, blowingDir.z);
                    }

                    // Instantiate(fire,transform.position,transform.rotation);




                    // GetPoint(1);
                    // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y * -1);
                    //return;
                }
                if (name == "FireBomber" && fireFlg && boundDir.y > 0)
                {
                    Instantiate(fire, transform.position, transform.rotation);
                    fireFlg = false;
                }
                if (name == "KingBomber" && fireFlg && boundDir.y > 0)
                {
                    Instantiate(fire, transform.position, transform.rotation);
                    fireFlg = false;
                }
                break;

            case "JackPod":
                GetPoint(10);
                // Debug.Log("1000");
                break;

            case "Player":
                /*
                if(blowFlg)
                {
                    blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                    return;
                }
                */
                // Instantiate(hitEffect,(collision.gameObject.transform.position + transform.position)/2 + (transform.position - collision.gameObject.transform.position).normalized * 3, Quaternion.FromToRotation(Vector3.up,(transform.position - collision.gameObject.transform.position )));
                //Debug.Log(plusAngle);
                break;


        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (blowFlg)
        {
            return;
        }
        if (bomFlg)
        {
            return;
        }
        /*
        if(collision.gameObject.tag == "Prism")
        {
            bomFlg = true;
            switch(name)
            {
                case "Bomber":
                GetPoint(10);
                break;

                case "RollingBomber":
                GetPoint(20);
                break;

                case "PitchBomber":
                GetPoint(20);
                break;

                case "SmallBomber":
                GetPoint(20);
                break;

                case "FireBomber":
                GetPoint(20);
                break;

                case "GoldenBomber":
                GetPoint(20);
                break;

                case "KingBomber":
                GetPoint(20);
                break;
            }
            Bom();
        }
        */
        switch (collision.gameObject.tag)
        {

            case "Wall":
                if (player.transform.position.x > transform.position.x)
                {
                    if (blowingDir.x < 0)
                    {
                        // blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                        blowingDir = new Vector3(0.3f, blowingDir.y, blowingDir.z);
                    }
                }
                if (player.transform.position.x < transform.position.x)
                {
                    if (blowingDir.x > 0)
                    {
                        // blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                        blowingDir = new Vector3(-0.3f, blowingDir.y, blowingDir.z);
                    }
                }
                break;

            case "BoundWall":
                if (player.transform.position.y > transform.position.y)
                {
                    if (blowingDir.y < 0)
                    {
                        // blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                        blowingDir = new Vector3(blowingDir.y, 0.5f, blowingDir.z);
                    }
                }
                if (player.transform.position.y < transform.position.y)
                {
                    if (blowingDir.y > 0)
                    {
                        // blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                        blowingDir = new Vector3(blowingDir.y, -0.5f, blowingDir.z);
                    }
                }
                break;

            case "Wave":
                switch (waveLR)
                {
                    case "Left":
                        LWaveMove();
                        break;
                    case "Right":
                        RWaveMove();
                        break;
                }
                break;
        }


    }

    public void LWaveMove()
    {
        if (blowFlg)
        {
            return;
        }
        if (name == "KingBomber")
        {
            return;
        }
        waveVector -= 0.01f;
        waveMove = new Vector3(waveVector, 0, 0) * Time.deltaTime;
        transform.Translate(waveMove * 0.1f, Space.World);
        if (transform.position.x < -1.7f)
        {
            transform.position = new Vector3(-1.7f, transform.position.y, transform.position.z);
            return;
        }
    }

    public void RWaveMove()
    {
        if (blowFlg)
        {
            return;
        }
        if (name == "KingBomber")
        {
            return;
        }
        waveVector += 0.01f;
        waveMove = new Vector3(waveVector, 0, 0) * Time.deltaTime;
        transform.Translate(waveMove * 0.1f, Space.World);
        if (transform.position.x > 1.7f)
        {
            transform.position = new Vector3(1.7f, transform.position.y, transform.position.z);
            return;
        }
    }

    public void OnWave(float vec, string lr)
    {

        waveLR = lr;
        switch (waveLR)
        {
            case "Left":
                waveVector = vec;
                break;
            case "Right":
                waveVector = vec;
                break;
        }
    }


    public void Blow(Vector3 playerPos, Vector3 playerDir, int gear)
    {
        if (bomFlg)
        {
            return;
        }
        if (blowFlg)
        {
            return;
        }

        int num = 0;
        /*
        sweetSpotFlg = false;
        windArrow.SetActive(false);
        sweetSpot.SetActive(false);
        */
        justFlg = true;
        fireFlg = true;
        blowingDir = center.transform.position - playerPos;
        blowFlg = true;
        Vector3 a = blowingDir.normalized;
        Vector3 b = playerDir.normalized;
        /*
        if(name == "FireBomber")
        {
            if(justFlg)
            {
                fireFlg = false;
            }
            else
            {
                justFlg = true;
                ifeTime += 2;
            }
            
        }
        
        if(name == "KingBomber")
        {
            if(justFlg)
            {
                fireFlg = false;
            }
            else
            {
                justFlg = true;
                // lifeTime += 2;
            }
            
        }
        */
        if (name == "PitchBomber")
        {
            particle.Stop();
        }
        // if(b.x - 0.15f <= a.x && a.x <= b.x + 0.15f)
        if (justFlg)
        {
            // Debug.Log("Just");
            // justFlg = true;
            // GetComponent<Rigidbody2D>().AddForce(blowingDir * 3);
            // blowSE.Play();
            audioSource.PlayOneShot(blowSE);
            /*
            if(gear > 12)
            {
                lifeTime += 3;
            }
            else
            {
                lifeTime += gear / 4;
            }
            */
            /*
            if(name == "GoldenBomber")
            {
                lifeTime = 3;
            }
            */
            Invoke(nameof(Bom), lifeTime);

            if (rankingFlg)
            {
                GameSystem.instance.Critical();
            }
            else
            {
                GameSystemTrick.instance.Critical();
            }

            switch (name)
            {
                case "ShoteBomber":
                    num = 10;
                    break;

                case "Bomber":
                    num = 10;
                    break;

                case "RollingBomber":
                    num = 10;
                    break;

                case "PitchBomber":
                    num = 10;
                    break;

                case "SmallBomber":
                    num = 10;
                    break;

                case "FireBomber":
                    num = 10;
                    break;

                case "GoldenBomber":
                    num = 1000;
                    break;

                case "KingBomber":
                    num = 10;
                    break;
            }
            // Instantiate(hitEffect,(playerPos + transform.position)/2 + (transform.position - playerPos).normalized * 3, Quaternion.FromToRotation(Vector3.up,(transform.position - playerPos)));
            Instantiate(hitEffectS, (playerPos + transform.position) / 2, Quaternion.FromToRotation(Vector3.up, (transform.position - playerPos)));
            Instantiate(sonicMove, transform.position, Quaternion.identity);
            hitPos = transform.position + blowingDir.normalized;
            hitEffectFlg = true;
            blowParticle.Play();
            Invoke(nameof(SetHitEffectFlgFalse), 0.1f);
            StartCoroutine(HitStop());
        }
        else
        {
            num = 5;
            Bom();
        }
        /*
        switch(name)
        {
            case "Bomber":
                
                break;

            case "GreenBomber":
                num = num * 2;
                break;

            case "FireBomber":
                num = num * 2;
                break;

            case "RollingBomber":
                num = num * 2;
                break;

            case "PitchBomber":
                num = num * 2;
                break;
        }
        */
        /*
        if(gear3 < baseSpeed)
        {
            num = num * 4;
        }
        else if(gear3 >= baseSpeed && gear2 < baseSpeed)
        {
            num = num * 3;
        }
        else if(gear2 >= baseSpeed && gear1 < baseSpeed)
        {
            num = num * 2;
        }
        else if(gear1 >= baseSpeed)
        {
            num = num * 1;
        }
        */
        GetPoint(num);
    }

    public void BlowChototsu(Vector3 playerPos, int gear)
    {
        if (bomFlg)
        {
            return;
        }
        if (blowFlg)
        {
            return;
        }
        // audioSource.PlayOneShot(bomSE);
        blowingDir = center.transform.position - playerPos;
        blowFlg = true;
        justFlg = true;
        // Invoke(nameof(Bom), lifeTime);

        if (rankingFlg)
        {
            GameSystem.instance.Critical();
        }
        else
        {
            GameSystemTrick.instance.Critical();
        }

        switch (name)
        {
            case "ShoteBomber":
                chototsuPoint = 100;
                break;

            case "Bomber":
                chototsuPoint = 100;
                break;

            case "RollingBomber":
                chototsuPoint = 100;
                break;

            case "PitchBomber":
                chototsuPoint = 100;
                break;

            case "SmallBomber":
                chototsuPoint = 100;
                break;

            case "FireBomber":
                chototsuPoint = 100;
                break;

            case "GoldenBomber":
                chototsuPoint = 1000;
                break;

            case "KingBomber":
                chototsuPoint = 100;
                break;
        }
        GetPoint(chototsuPoint);
        // Instantiate(hitEffect,(playerPos + transform.position)/2 + (transform.position - playerPos).normalized * 3, Quaternion.FromToRotation(Vector3.up,(transform.position - playerPos)));
        Instantiate(hitEffectS, (playerPos + transform.position) / 2, Quaternion.FromToRotation(Vector3.up, (transform.position - playerPos)));
        Instantiate(sonicMove, transform.position, Quaternion.identity);
        StartCoroutine(HitStop());
        Bom();
    }

    public void Bom()
    {
        bomFlg = true;
        // bomSE.Play();
        audioSource.PlayOneShot(bomSE);
        tokuParticle.Play();
        if (name == "PitchBomber")
        {
            particle.Stop();
        }
        /*
        if(!blowFlg)
        {
            GetPoint(1);
        }
        */
        blowingDir = new Vector3(0, 0, 0);
        // bomberAnim.SetTrigger("Bom");
        switch (name)
        {
            case "ShoteBomber":
                bomberAnim.SetBool("BomFlg", true);
                break;

            case "Bomber":
                bomberAnim.SetBool("BomFlg", true);
                break;

            case "RollingBomber":
                bomberAnim.SetBool("RollingBomFlg", true);
                break;

            case "PitchBomber":
                bomberAnim.SetBool("PitchBomFlg", true);
                break;

            case "SmallBomber":
                bomberAnim.SetBool("SmallBomFlg", true);
                break;

            case "FireBomber":
                fireFlg = false;
                bomberAnim.SetBool("FireBomFlg", true);
                break;

            case "GoldenBomber":
                bomberAnim.SetBool("GoldenBomFlg", true);
                break;

            case "KingBomber":
                bomberAnim.SetBool("KingBomberFlg", true);
                break;
        }
        // StartCoroutine(ResetTime());
        // Time.timeScale = 0;

        Invoke(nameof(SetActiveFalse), 0.5f);
        // StartCoroutine(SetBomFlgFalse());
    }

    public void SetActiveFalse()
    {
        // yield return new WaitForSeconds(0.5f);
        // bomberAnim.SetBool("BomFlg", false);
        if (rankingFlg)
        {

        }
        else
        {
            if (justFlg)
            {
                if ((name == "KingBomber" && fireFlg) || (name == "FireBomber" && fireFlg))
                {
                    GameSystemTrick.instance.GetPoint(5);
                }
                else
                {
                    GameSystemTrick.instance.GetPoint(point + levelPoint);
                }
            }
            else
            {
                GameSystemTrick.instance.GetPoint(point);
            }
        }
        /*
        if(blowFlg)
        {
            GameObject plusPoint = GameObject.FindWithTag("PlusPoint");
            plusPoint.GetComponent<PlusPoint> ().Plus(point);
        }
        */

        point = 0;
        switch (name)
        {
            case "ShoteBomber":
                bomberAnim.SetBool("BomFlg", false);
                break;

            case "Bomber":
                bomberAnim.SetBool("BomFlg", false);
                break;

            case "RollingBomber":
                bomberAnim.SetBool("RollingBomFlg", false);
                break;

            case "PitchBomber":
                bomberAnim.SetBool("PitchBomFlg", false);
                break;
        }
        if (chinowaFlg)
        {
            switch (name)
            {
                case "Bomber":
                    Instantiate(weapon, transform.position, transform.rotation);
                    break;

                case "RollingBomber":
                    Instantiate(mure, transform.position, transform.rotation);
                    break;

                case "PitchBomber":
                    bomberAnim.SetBool("PitchBomFlg", false);
                    break;
            }
            chinowaFlg = false;

        }

        // Destroy(getPoint);

        blowFlg = false;
        justFlg = false;
        bomFlg = false;
        gameObject.SetActive(false);
        /*
        sr.DOFade(1f, 0.5f);
        shadow.DOFade(0.3f, 0.5f);
        */

    }

    /*
    public void SetBomFlgFalse()
    {
        switch(name)
        {
            case "Bomber":
            bomberAnim.SetBool("BomFlg", false);
            break;

            case "RollingBomber":
            bomberAnim.SetBool("RollingBomFlg", false);
            break;

            case "PitchBomber":
            bomberAnim.SetBool("PitchBomFlg", false);
            break;
        }
        
        Invoke(nameof(SetActiveFalse), 0.02f);
    }
    */

    IEnumerator ResetTime()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1f;
    }

    IEnumerator HitStop()
    {
        // Debug.Log("HitStop");
        hitsStopX = transform.position.x;
        hitStopFlg = true;
        yield return new WaitForSecondsRealtime(0.3f);
        hitStopFlg = false;
    }

    public void GetPoint(int num)
    {
        if (point == -100)
        {
            return;
        }

        // numにレベル分のスコア追加する
        /*
        if(justFlg)
        {
            point += num + levelPoint;
        }
        else
        {
            point += num;
        }
        */
        point += num;
        // num += levelPoint;
        /*
        switch(name)
        {
            case "Bomber":
                
                break;

            case "GreenBomber":
                num = num * 2;
                break;

            case "FireBomber":
                num = num * 2;
                break;

            case "RollingBomber":
                num = num * 2;
                break;

            case "PitchBomber":
                num = num * 2;
                break;
        }
        */

        /*
        if(getPointIns == null)
        {
            getPointIns = Instantiate(getPoint, transform.position + new Vector3(0,1,0), Quaternion.identity);
            // getPointIns.transform.SetParent(this.gameObject.transform);
        }
        getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "+" + point;
        
        if(gear3 < baseSpeed)
        {
            getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.007f,0.34f,0.93f,1f);
        }
        else if(gear3 >= baseSpeed && gear2 < baseSpeed)
        {
            getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.007f,0.61f,0.93f,1f);
            // getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.5f,0.5f,0.5f,1f);
        }
        else if(gear2 >= baseSpeed && gear1 < baseSpeed)
        {
            getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.007f,0.95f,0.9f,1f);
            //getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.5f,0.5f,0.5f,1f);
        }
        else if(gear1 >= baseSpeed)
        {
            // getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.5f,0.5f,0.5f,1f);
            // getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.5f,0.5f,0.5f,1f);
        }
        */
        /*
        if(point == 1)
        {
            // canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.5f,0.5f,0.5f,1f);
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.5f,0.5f,0.5f,1f);
        }
        if(point == 2)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.86f,0.86f,0.86f,1f);
        }
        if(point == 3)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.86f,0.86f,0.86f,1f);
        }
        if(point == 4)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.9f,0.96f,0.96f,1f);
        }
        if(point == 5)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.94f,0.94f,0.56f,1f);
        }
        if(point == 6)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.94f,0.94f,0f,1f);
        }
        if(point == 7)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.92f,0.37f,0f,1f);
        }
        if(point == 8)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.92f,0f,0f,1f);
        }
        if(point == 9)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.19f,0.38f,0.96f,1f);
        }
        if(point == 10)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.18f,0.18f,0.55f,1f);
        }
        if(point == 11)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.75f,0.56f,0.95f,1f);
        }
        if(point >= 12)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Outline>().effectColor = new Color(0.5f,0,0.5f,1f);
        }
        */

        if (rankingFlg)
        {

        }
        else
        {
            // GameSystemTrick.instance.GetPoint(point);
        }
    }

    public int RetrunPoint()
    {
        return point;
    }

    public bool GetJustFlg()
    {
        return justFlg;
    }

    public void SetJustFlg()
    {
        if (bomFlg)
        {
            return;
        }
        justFlg = true;
    }

    public bool GetBlowFlg()
    {
        return blowFlg;
    }

    public bool GetBomFlg()
    {
        return bomFlg;
    }

    public void SweetSpotON(float speed)
    {
        // playerRot = player.transform.rotation;
        if (blowFlg || bomFlg)
        {
            return;
        }
        baseSpeed = speed;
        if (gear3 < baseSpeed)
        {
            sweetSpot3.SetActive(true);
            sweetSpot = sweetSpot3;
            // lifeTime = 2f;
            // levelPoint = 20;
        }
        else if (gear3 >= baseSpeed && gear2 < baseSpeed)
        {
            sweetSpot2.SetActive(true);
            sweetSpot = sweetSpot2;
            // lifeTime = 1.5f;
            // levelPoint = 15;
        }
        else if (gear2 >= baseSpeed && gear1 < baseSpeed)
        {
            sweetSpot1.SetActive(true);
            sweetSpot = sweetSpot1;
            // lifeTime = 1f;
            // levelPoint = 5;
        }
        else if (gear1 >= baseSpeed)
        {
            sweetSpot4.SetActive(true);
            sweetSpot = sweetSpot4;
            // lifeTime = 0.5f;
            // levelPoint = 1;
        }

        /*
        sweetSpot1.SetActive(true);
        sweetSpot2.SetActive(true);
        sweetSpot3.SetActive(true);
        sweetSpot4.SetActive(true);
        sweetSpot5.SetActive(true);
        sweetSpot6.SetActive(true);
        sweetSpot7.SetActive(true);
        sweetSpot8.SetActive(true);
        sweetSpot9.SetActive(true);
        sweetSpot10.SetActive(true);
        sweetSpot11.SetActive(true);
        sweetSpot12.SetActive(true);
        sweetSpot13.SetActive(true);
        sweetSpot14.SetActive(true);
        sweetSpot15.SetActive(true);
        sweetSpot16.SetActive(true);
        sweetSpot17.SetActive(true);
        */
        windArrow.SetActive(true);
        sweetSpotFlg = true;
    }

    public void SweetSpotOFF()
    {
        if (sweetSpot == null)
        {
            return;
        }
        sweetSpotFlg = false;
        sweetSpot.SetActive(false);
        /*
        sweetSpot1.SetActive(false);
        sweetSpot2.SetActive(false);
        sweetSpot3.SetActive(false);
        sweetSpot4.SetActive(false);
        sweetSpot5.SetActive(false);
        sweetSpot6.SetActive(false);
        sweetSpot7.SetActive(false);
        sweetSpot8.SetActive(false);
        sweetSpot9.SetActive(false);
        sweetSpot10.SetActive(false);
        sweetSpot11.SetActive(false);
        sweetSpot12.SetActive(false);
        sweetSpot13.SetActive(false);
        sweetSpot14.SetActive(false);
        sweetSpot15.SetActive(false);
        sweetSpot16.SetActive(false);
        sweetSpot17.SetActive(false);
        */
    }

    public void MoveFlgOn()
    {
        if (name != "PitchBomber")
        {
            return;
        }
        frontMoveFlg = true;
        particle.Play();
        // Debug.Log(frontMoveFlg);
    }

    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    public string GetName()
    {
        return name;
    }

    public void SetHitEffectFlgFalse()
    {
        hitEffectFlg = false;
        // transform.position = hitPos + blowingDir.normalized * 3;
    }
    // public int GetLife()
    // {
    //     return life;
    // }


}

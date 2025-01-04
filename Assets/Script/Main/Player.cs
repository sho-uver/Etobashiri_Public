using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float baseSpeed;
    public int gear;
    public static Player instance;
    public bool chototsuFlg;
    public float chototsuSpeed;
    public float chototsuTime;
    public float chototsuBaseSpeed;
    public bool rankingFlg;
    public bool cloudFlg;
    public float acceleration;
    public bool resetPosFlg;
    public bool runFlg;
    public float levelSpeedUp;
    public float levelSpeedDown;
    public int levelPoint;
    public GameObject speedEffect1;
    public GameObject speedEffect2;
    public GameObject speedEffect3;
    public CapsuleCollider2D speedEffectCol1;
    public CapsuleCollider2D speedEffectCol2;
    public CapsuleCollider2D speedEffectCol3;
    public bool speedEffectFlg1;
    public bool speedEffectFlg2;
    public bool speedEffectFlg3;
    public GameObject getWind;
    public float gear0;
    public float gear1;
    public float gear2;
    public float gear3;
    public float gear4;
    public DeleteField df;
    public AudioSource iceAudio;
    public AudioSource chototsuAudio;
    public AudioSource snowBallAudio;
    public GameObject firework;
    public GameObject firework2;
    public GameObject mure;
    public int toriCounter;
    public AudioSource runAudio;
    public AudioSource taikoAudio;
    public Rigidbody2D rb;
    public int altGear;
    public GameObject amaterasu;
    public Amaterasu amaterasuScript;
    public float ordinarySpeed;
    public int lineCount;
    public Image tsumuzikazeGage;
    public GameObject tsumuzikaze;
    public bool tsumuzikazeFlg;
    public GameObject mainCamera;
    public MainCamera mainCameraScript;
    public ParticleSystem tsumuzikazeParticleDown;
    public ParticleSystem tsumuzikazeParticleUp;
    public ParticleSystem blowParticle;
    public SpriteRenderer sr;
    public int currentPoint;
    public float pointSpeed;
    public bool mutekiFlg;
    // Start is called before the first frame update
    public bool chototsuItemGetFlg;

    // 「どの Line に反応したか」管理用
    private int currentBestLineCount = -1;   // 今反応中のLineCount
    private GameObject currentBestLineObj;   // 今反応中のLine
    public float defaultGravityScale;
    public bool lineCollisionFlg;
    public float lineCollisionTime;
    public float lineCollisionSpeed;
    private Coroutine vibrationCoroutine;
    public Animator animator;
    void Start()
    {
        instance = this;
        levelSpeedUp = PlayerPrefs.GetInt("UpSpeed", 0) * 0.1f;
        levelSpeedDown = 1 - PlayerPrefs.GetInt("DownSpeed", 0) * 0.1f * 0.01f;
        // levelSpeedUp = 3f;
        // levelSpeedDown = 1 - 0.30f;
        // levelPoint = Mathf.FloorToInt(PlayerPrefs.GetInt("levelPoint", 0));
        // levelPoint = 10;
        speedEffectCol1 = speedEffect1.GetComponent<CapsuleCollider2D>();
        speedEffectCol2 = speedEffect2.GetComponent<CapsuleCollider2D>();
        speedEffectCol3 = speedEffect3.GetComponent<CapsuleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        mainCameraScript = mainCamera.GetComponent<MainCamera>();
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!runFlg)
        {
            return;
        }
        if (lineCollisionFlg)
        {
            lineCollisionSpeed += 0.1f * Time.deltaTime;
            if (lineCollisionSpeed > 2)
            {
                lineCollisionSpeed = 2;
            }
            lineCollisionTime += Time.deltaTime;
            if (lineCollisionTime > 0.1f) ResetGravity();
            rb.angularVelocity = 0f;
            rb.velocity = new Vector2(0, 0);
        }
        if (resetPosFlg)
        {
            return;
        }

        // SpeedEffect();
        if (chototsuFlg)
        {

            ResetPosition();
            // transform.position = new Vector3(0, transform.position.y + chototsuBaseSpeed * Time.deltaTime + chototsuSpeed * toriCounter * Time.deltaTime, 0);
            transform.position = new Vector3(0, transform.position.y + chototsuBaseSpeed * Time.deltaTime + chototsuSpeed * Time.deltaTime, 0);
            chototsuTime -= Time.deltaTime;
            /*
            if(SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            */
            if (chototsuTime <= 0)
            {
                EndChototsumoshin();

            }

            return;
        }
        // systemSpeed = 3;
        /*
        if(gear <= 5)
        {
            altGear = 1;
        }
        else
        {
            altGear = gear - 4;
        }
        */
        // transform.Translate(Vector2.up * ((baseSpeed * Time.deltaTime + speed * gear * Time.deltaTime + levelSpeedUp * Time.deltaTime) * levelSpeedDown));
        /*ポイント付きの場合これ
        if(gear > 10)
        {
            transform.Translate(Vector2.up * (speed * 10 * Time.deltaTime + ordinarySpeed * Time.deltaTime + pointSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(Vector2.up * (speed * gear * Time.deltaTime + ordinarySpeed * Time.deltaTime + pointSpeed * Time.deltaTime));
        }
        */

        transform.Translate(Vector2.up * (speed * gear * Time.deltaTime + ordinarySpeed * Time.deltaTime + lineCollisionSpeed));
        // vector =         Vector2.up * ((baseSpeed * Time.deltaTime + speed * gear * Time.deltaTime + levelSpeedUp * Time.deltaTime) * levelSpeedDown);
        // Debug.Log("speeed");
        /*
        if(10 < baseSpeed)
        {
            baseSpeed = 10;
        }
        if(10f >= baseSpeed)
        {
            baseSpeed -= 0.01f;
        }
        if(4f >= baseSpeed)
        {
            baseSpeed = 4f;
        }
        */

        /*
        if(gear4 < baseSpeed)
        {
            baseSpeed = gear4;
        }
        else if(gear4 >= baseSpeed && gear2 < baseSpeed)
        {
            baseSpeed -= 0.0003f;
        }
        else if(gear2 >= baseSpeed && gear1 < baseSpeed)
        {
            baseSpeed -= 0.0002f;
        }
        else if(gear1 >= baseSpeed && gear0 < baseSpeed)
        {
            baseSpeed -= 0.0001f;
        }
        else if(4 >= baseSpeed)
        {
            baseSpeed = gear0;
        }
        */

        /*
        if(3 < speed)
        {
            speed = 3;
        }
        if(0.3f < speed)
        {
            speed -= 0.001f;
        }
        if(0.3f >= speed)
        {
            speed = 0.3f;
        }
        */

        /*
        if (!cloudFlg)
        {
            Debug.Log("b");
            transform.Translate(new Vector3(0,1,0) * (baseSpeed * Time.deltaTime + speed * gear * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else
        {
            Debug.Log("a");
            transform.Translate(Vector2.up * (baseSpeed * Time.deltaTime + speed * gear * Time.deltaTime));
        }
        */
        // transform.position += Vector3.up * Time.deltaTime * (systemSpeed + speed);
        if (tsumuzikazeFlg)
        {
            // 20240411tsumuzikazeGage.fillAmount -= Time.deltaTime * 0.075f;
            tsumuzikazeGage.fillAmount -= Time.deltaTime * 0.05f;
            if (tsumuzikazeGage.fillAmount <= 0)
            {
                tsumuzikazeGage.fillAmount = 0;
                tsumuzikaze.SetActive(false);
                tsumuzikazeFlg = false;
                ordinarySpeed -= 2;
                taikoAudio.pitch = 1f;
                runAudio.pitch = 1f;
                // tsumuzikazeParticleContinue.Stop();
            }
        }



    }


    /* 
    private void FixedUpdate()
    {
        rb.velocity = Vector2.up * (systemSpeed + speed);
    }
    */
    public void Chototsumoshin(float count)
    {
        /*
        int num;
        if(count + toriCounter >= 10)
        {
            num = 10;
        }
        else
        {
            num = count + toriCounter; 
        }

        chototsuTime += num;
        */
        chototsuTime += count;
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        transform.localScale = new Vector3(2f, 2f, 2f);
        chototsuFlg = true;
        Time.timeScale = 0f;
        StartCoroutine(ResetTime());
        // StartCoroutine(Vibrate(7));
    }

    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    public void SpeedEffect()
    {

        if (!speedEffectFlg3 && gear3 < baseSpeed)
        {
            speedEffect1.SetActive(true);
            speedEffect2.SetActive(true);
            speedEffect3.SetActive(true);
            speedEffectCol1.enabled = false;
            speedEffectCol2.enabled = false;
            speedEffectCol3.enabled = true;
            // GetComponent<CapsuleCollider2D>().size = new Vector2(7,10);
            // GetComponent<CapsuleCollider2D>().offset = new Vector2(0,-1.7f);
            speedEffectFlg1 = true;
            speedEffectFlg2 = true;
            speedEffectFlg3 = true;
            // taikoAudio.pitch =  1.5f;
            // runAudio.pitch =  1.5f;
        }

        if ((!speedEffectFlg2 || speedEffectFlg3) && gear3 >= baseSpeed && gear2 < baseSpeed)
        {
            speedEffect1.SetActive(true);
            speedEffect2.SetActive(true);
            speedEffect3.SetActive(false);
            speedEffectCol1.enabled = false;
            speedEffectCol2.enabled = true;
            // GetComponent<CapsuleCollider2D>().size = new Vector2(6,8);
            // GetComponent<CapsuleCollider2D>().offset = new Vector2(0,-1);
            speedEffectFlg1 = true;
            speedEffectFlg2 = true;
            speedEffectFlg3 = false;
            // taikoAudio.pitch =  1.3f;
            // runAudio.pitch =  1.3f;
        }

        if ((!speedEffectFlg1 || speedEffectFlg2) && gear2 >= baseSpeed && gear1 < baseSpeed)
        {
            speedEffect1.SetActive(true);
            speedEffect2.SetActive(false);
            speedEffect3.SetActive(false);
            speedEffectCol1.enabled = true;
            // GetComponent<CapsuleCollider2D>().size = new Vector2(5,7);
            // GetComponent<CapsuleCollider2D>().offset = new Vector2(0,0);
            speedEffectFlg1 = true;
            speedEffectFlg2 = false;
            speedEffectFlg3 = false;
            // taikoAudio.pitch =  1.1f;
            // runAudio.pitch =  1.1f;
        }

        if (speedEffectFlg1 && gear1 >= baseSpeed)
        {
            speedEffect1.SetActive(false);
            speedEffect2.SetActive(false);
            speedEffect3.SetActive(false);
            // GetComponent<CapsuleCollider2D>().size = new Vector2(3.5f,5);
            // GetComponent<CapsuleCollider2D>().offset = new Vector2(0,0);
            speedEffectFlg1 = false;
            speedEffectFlg2 = false;
            speedEffectFlg3 = false;
            // taikoAudio.pitch =  1f;
            // runAudio.pitch =  1f;
        }

    }

    /*
    public void ResetPosition()
    {

        transform.position = new Vector2(0, transform.position.y);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    */
    public IEnumerator ResetPositionChikaChika()
    {
        // transform.position = new Vector2(0, transform.position.y);
        // transform.rotation = Quaternion.Euler(0, 0, 0);
        resetPosFlg = true;
        df.DeleteFiledActivate();
        mutekiFlg = true;
        ResetPosition();
        tsumuzikazeGage.fillAmount -= 1f;
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        sr.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        mutekiFlg = false;
        df.DeleteFiledInactivate();
        resetPosFlg = false;
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(0, transform.position.y);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void ResetGravity()
    {
        rb.gravityScale = 0;
        lineCollisionFlg = false;
        lineCollisionTime = 0;
        lineCollisionSpeed = 0;
        animator.SetBool("LineFlg", false);
        StopVibration();
    }


    public void EndChototsumoshin()
    {

        chototsuTime = 0;
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        df.DeleteFiledActivate();

        chototsuFlg = false;
        if (rankingFlg)
        {
            GameSystem.instance.EndChototsumoshin();
        }
        else
        {
            GameSystemTrick.instance.EndChototsumoshin();
        }
        Invoke("DeleteFiledInactivate", 0.5f);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // if((chototsuFlg && collision.gameObject.tag != "Wall") || (chototsuFlg && collision.gameObject.tag != "Cleaner"))
        if (chototsuFlg)
        {
            /*
            if(collision.gameObject.tag == "Wall")
            {
                return;
            }
            if(collision.gameObject.tag == "Cleaner")
            {
                return;
            }
            */

            switch (collision.gameObject.tag)
            {
                case "Cleaner":
                    return;
                    break;

                case "Tsumuzikaze":
                    return;
                    break;

                case "Amaterasu":
                    return;
                    break;

                case "Wall":
                    return;
                    break;

                case "BoundWall":
                    return;
                    break;

                case "Wave":
                    return;
                    break;

                case "BigTori":
                    return;
                    break;

                case "LifeThread":
                    // collision.gameObject.SetActive(false);
                    GameSystemTrick.instance.GetLifeThread();
                    break;

                case "Tori":
                    // collision.gameObject.SetActive(false);
                    /*
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0,3,0), transform.rotation);
                    chototsuAudio.Play();
                    GameSystemTrick.instance.GetTori("Tori");
                    */

                    CollisionTori(collision.gameObject);


                    break;

                case "ShiroTori":
                    // collision.gameObject.SetActive(false);
                    GameSystemTrick.instance.GetTori("ShiroTori");
                    break;

                case "Hude":
                    GameSystem.instance.GetHude();
                    break;

                case "MureSymbol":
                    /*
                    chototsuAudio.Play();
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0,3,0), transform.rotation);
                    for(int n = 0; n < toriCounter; n++)
                    {
                        Instantiate(mure, transform.position, collision.gameObject.transform.rotation);
                    }
                    */

                    CollisionMureSymbol(collision.gameObject);

                    // collision.gameObject.SetActive(false);
                    // return;
                    break;

                case "AmaterasuSymbol":

                    CollisionAmaterasuSymbol(collision.gameObject);


                    break;

                case "Enemy":
                    Instantiate(firework2, collision.gameObject.transform.position + new Vector3(0, 3, 0), transform.rotation);
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0, 3, 0), transform.rotation);
                    Enemy eScript = collision.gameObject.GetComponent<Enemy>();
                    if (!eScript.GetBlowFlg())
                    {
                        VibrationMng.ShortVibration();
                        eScript.BlowChototsu(transform.position, gear);
                    }
                    // GameSystem.instance.Critical();
                    return;
                    break;

                case "LiberationPower":
                    GameSystem.instance.StartChototsumoshin();
                    Vector3 a = collision.transform.position - transform.position;
                    a = a.normalized;
                    Vector3 b = transform.forward.normalized;
                    if (b.x - 0.1f <= a.x && a.x <= b.x + 0.1f)
                    {
                        GameSystem.instance.StartChototsumoshin();
                    }
                    // collision.gameObject.SetActive(false);
                    break;

                case "Wind":
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0, 3, 0), transform.rotation);
                    return;
                    break;

                case "Object":
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0, 3, 0), transform.rotation);
                    break;

                case "SnowBall":
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0, 3, 0), transform.rotation);
                    break;

                case "Warp":
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0, 3, 0), transform.rotation);
                    break;

                case "Hole":
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0, 3, 0), transform.rotation);
                    break;

                case "Bubble":
                    Instantiate(firework, collision.gameObject.transform.position + new Vector3(0, 3, 0), transform.rotation);
                    break;

                case "Mure":
                    return;
                    break;

                case "SpeedEffect":
                    return;
                    break;

                case "Ice":
                    collision.gameObject.SetActive(false);
                    return;
                    break;


                case "Goal":

                    GameSystemTrick.instance.Goal();
                    break;

                case "Line":
                    return;
                    break;
            }
            collision.gameObject.SetActive(false);
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Enemy":
                CollisionEnemy(collision.gameObject);
                /*
                var result = speed - collision.gameObject.GetComponent<Enemy>().GetLife();
                if(result < 0)
                {
                    speed += result;
                    collision.gameObject.SetActive(false);
                }
                else
                {
                    collision.gameObject.SetActive(false);
                    // Destroy(collision.gameObject);
                }
                */

                /*
                if(SystemInfo.supportsVibration)
                {
                    Handheld.Vibrate();
                }
                */
                /*
                if(!collision.gameObject.GetComponent<Enemy>().GetBlowFlg())
                {
                    VibrationMng.ShortVibration();
                    collision.gameObject.GetComponent<Enemy>().Blow(transform.position, transform.up, gear);
                }
                */



                // Time.timeScale = 0f;
                // StartCoroutine(ResetTime());
                // StartCoroutine(SetActiveFalseEnemy(collision)); 



                break;

            case "Weapon":
                VibrationMng.ShortVibration();
                collision.GetComponent<Weapon>().Blow(transform.position, transform.up);
                break;
            /*    
            case "Gate":
                speed += 1;
                // Destroy(collision.gameObject);
                break;
            */

            case "MureSymbol":
                CollisionMureSymbol(collision.gameObject);
                /*
                chototsuAudio.Play();
                
                for(int n = 0; n < toriCounter; n++)
                    {
                        
                        Instantiate(mure, transform.position, collision.gameObject.transform.rotation);
                    }
                collision.gameObject.SetActive(false);
                */
                break;

            case "AmaterasuSymbol":
                CollisionAmaterasuSymbol(collision.gameObject);

                break;

            case "Wall":

                // StartCoroutine("ResetPosition");
                /*
                if(rankingFlg)
                {
                    GameSystem.instance.LostLife(1);
                }
                else
                {
                    GameSystemTrick.instance.LostLife();
                }
                */
                // transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(0 - transform.position.x, 10, transform.position.z));
                transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(0 - transform.position.x / 2, 10, transform.position.z));
                transform.position = new Vector3(transform.position.x + (0 - transform.position.x) / 5, transform.position.y, transform.position.z);
                /*
                if (transform.rotation.z >= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 330);

                }
                else if (transform.rotation.z < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 30);

                }
                */
                // GameSystemTrick.instance.SetToriTime(1);

                // GameSystem.instance.ReStart();
                break;

            case "LifeThread":
                collision.gameObject.SetActive(false);
                GameSystem.instance.GetLifeThread();
                break;

            case "Tori":
                CollisionTori(collision.gameObject);
                /*
                collision.gameObject.SetActive(false);
                chototsuAudio.Play();
                GameSystemTrick.instance.GetTori("Tori");
                */
                break;



            case "ShiroTori":
                collision.gameObject.SetActive(false);
                GameSystemTrick.instance.GetTori("ShiroTori");
                break;

            case "Hude":

                collision.gameObject.SetActive(false);
                GameSystem.instance.GetHude();
                break;

            case "Suikomi":
                if (transform.position.x > collision.gameObject.transform.position.x)
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
                if (transform.position.x < collision.gameObject.transform.position.x)
                {
                    transform.position += new Vector3(1, 0, 0);
                }
                break;

            case "Cleaner":
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                // collision.gameObject.transform.position = new Vector2(0, transform.position.y - 10);
                // StartCoroutine("ResetPosition");
                if (rankingFlg)
                {
                    // GameSystem.instance.LostLife(1);
                }
                else
                {
                    // GameSystemTrick.instance.LostLife();
                }
                break;

            case "Goal":

                // SceneChanger.instance.ChangeMenu();
                if (rankingFlg)
                {

                }
                else
                {
                    GameSystemTrick.instance.Goal();
                }
                break;

            case "Hole":
                collision.gameObject.SetActive(false);
                // StartCoroutine("ResetPosition");
                // collision.gameObject.SetActive(false);
                //collision.gameObject.transform.position = new Vector2(0, transform.position.y - 10);
                if (rankingFlg)
                {
                    GameSystem.instance.LostLife(1);
                }
                else
                {
                    GameSystemTrick.instance.LostLife();
                }
                break;

            case "Fire":
                // collision.gameObject.SetActive(false);
                // StartCoroutine("ResetPosition");
                // collision.gameObject.SetActive(false);
                //collision.gameObject.transform.position = new Vector2(0, transform.position.y - 10);
                // collision.gameObject.SetActive(false);
                if (mutekiFlg) { return; }
                if (rankingFlg)
                {
                    GameSystem.instance.LostLife(1);
                }
                else
                {
                    GameSystemTrick.instance.LostLife();
                }
                break;

            case "LiberationPower":
                GameSystem.instance.StartChototsumoshin();
                collision.gameObject.SetActive(false);
                break;

            case "SnowBall":
                snowBallAudio.Play();
                GameSystemTrick.instance.LostLife();
                // tsumuzikazeGage.fillAmount -= 1f;
                // tsumuzikazeParticleDown.Play();
                collision.gameObject.SetActive(false);
                break;

            case "Warp":
                // baseSpeed += 0.1f;
                break;

            case "Ice":
                // Debug.Log("ice");
                // gear4 += 2;
                // baseSpeed += 2;
                ordinarySpeed += 4;
                iceAudio.Play();
                // mainCameraScript.PlayerOnIce();
                break;

            case "Wind":

                break;


        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (chototsuFlg)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Wall":
                // transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(0 - transform.position.x, 10, transform.position.z));
                transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(transform.position.x, 10, transform.position.z));
                // transform.position.x = transform.position.x + (0 - transform.position.x)/5;
                transform.position = new Vector3(transform.position.x + (0 - transform.position.x) / 5, transform.position.y, transform.position.z);
                break;

            case "Cleaner":
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case "Ice":
                // mainCameraScript.PlayerOnIce();
                break;
        }
    }

    /*
        public void AOnCollisionEnter2D(Collision2D collision)
        {
            switch(collision.gameObject.tag)
            {
                case "Cloud":
                cloudFlg = true;

                break;
            }
        }
    */
    public void OnTriggerExit2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Ice":
                if (chototsuFlg)
                {
                    return;
                }
                // gear4 -= 2;
                // baseSpeed -= 2f;
                ordinarySpeed -= 4;
                iceAudio.Stop();
                break;
        }
    }



    IEnumerator ResetTime()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1f;
    }

    IEnumerator Vibrate(int cnt)
    {
        for (int i = 0; i < cnt; i++)
        {
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            yield return new WaitForSeconds(0.6f);
        }
    }

    private void StartVibration()
    {
        if (vibrationCoroutine == null)
        {
            vibrationCoroutine = StartCoroutine(VibrationCoroutine());
        }
    }
    private IEnumerator VibrationCoroutine()
    {
        while (true)
        {
            VibrationMng.ShortVibration();
            yield return new WaitForSeconds(0.001f); // 0.5秒間隔で振動
        }
    }
    private void StopVibration()
    {
        if (vibrationCoroutine != null)
        {
            StopCoroutine(vibrationCoroutine);
            vibrationCoroutine = null;
        }
    }
    /*
    IEnumerator SetActiveFalseEnemy(Collider2D collision) 
    {
        yield return new WaitForSeconds(0.6f);
        collision.gameObject.SetActive(false);
    }
    */



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            baseSpeed = 0;
            if (!collision.gameObject.GetComponent<Enemy>().GetBlowFlg())
            {
                VibrationMng.ShortVibration();
                collision.gameObject.GetComponent<Enemy>().Blow(transform.position, transform.up, gear);
            }
        }
        if (collision.gameObject.tag == "Line")
        {
            // 衝突したLineのLineCountを取得
            Line lineScript = collision.gameObject.GetComponent<Line>();
            if (lineScript == null) return;  // 念のため

            int newLineCount = lineScript.GetLineCount();
            // 「現在反応中のLineCount」と比較して、新しい方が大きければ更新
            // （50以上差があれば小さい方が“実質大きい” という仕様を考慮）
            if (IsNewLineCountBigger(newLineCount, currentBestLineCount))
            {
                currentBestLineCount = newLineCount;
                currentBestLineObj = collision.gameObject;

                // ここでPlayerの角度を調整
                AdjustPlayerAngle(collision);
            }
            // rb.gravityScale = defaultGravityScale;
            lineCollisionFlg = true;
            lineCollisionTime = 0;
            animator.SetBool("LineFlg", true);
            StartVibration();
        }

    }



    public void OnCollisionStay2D(Collision2D collision)
    {
        /*
        if(collision.gameObject.tag == "Line")
        {
            baseSpeed += 5f * Time.deltaTime;
            
        }
        */
    }


    public void OnCollisionExit2D(Collision2D collision)
    {
        /*
        if(collision.gameObject.tag == "Line")
        {
            // Invoke("ResetRotation",0.1f);

        }
        */

    }

    /// <summary>
    /// LineCount を比較するときに、
    /// ・1～100 の循環
    /// ・差が50超なら小さい方を“大きい”とみなす
    /// という仕様に対応した判定関数
    /// </summary>
    private bool IsNewLineCountBigger(int newCount, int currentCount)
    {
        // まだ何も反応していない場合
        if (currentCount < 1) return true; // currentが -1 などの初期値なら新しい方を優先

        // 同じ値なら上書きしない（必要なら上書きするロジックに変えてもOK）
        if (newCount == currentCount) return false;

        // 差分を正規化 (0～99)
        int diff = newCount - currentCount;
        diff = diff % 100;
        if (diff < 0) diff += 100;
        // diff が 1～99 の範囲になる

        // 差が50以下なら“newCountの方が大きい”、50超なら“currentCountの方が大きい”
        // 例）diff = 10 → newCountの方が大きい
        //     diff = 90 → 90>50 なので currentCountの方が実質大きい
        if (diff == 0) return false;  // 同値
        if (diff <= 50) return true;  // newCountが大きい
        return false;                 // currentCountが大きい
    }

    /// <summary>
    /// ぶつかったLineにあわせて、Playerの角度を「垂直」に調整する
    /// </summary>
    private void AdjustPlayerAngle(Collision2D collision)
    {
        // 衝突点を拾い、Playerの中心 X との大小比較で「左 or 右」を判定
        ContactPoint2D contact = collision.GetContact(0);
        Vector3 contactPos = contact.point; // ワールド座標の衝突点
        Vector3 playerPos = transform.position;

        // ラインの中心
        Vector3 lineCenter = collision.transform.position;

        // プレイヤー中心→ライン中心ベクトル
        Vector3 dir = lineCenter - playerPos;

        // 左半分 vs 右半分
        bool isLeftHit = (contactPos.x < playerPos.x);

        // 「Playerの中心線と垂直になるように」
        // → transform.right を (player→line)方向に合わせる
        //    ただし左から当たったときは -dir にする等、好みで調整
        if (isLeftHit)
        {
            // 左半分なら逆方向
            // transform.right = -dir;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * -1; // Y軸反転
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x); // Y軸反転
            transform.localScale = scale;
            // 右半分ならそのまま
            // transform.right = dir;
        }
    }


    public Vector2 PlayerVector()
    {
        // Vector2 vector = Vector2.up * (speed * gear * Time.deltaTime + ordinarySpeed * Time.deltaTime + pointSpeed * Time.deltaTime);
        Vector2 vector = Vector2.up * (speed * gear * Time.deltaTime + ordinarySpeed * Time.deltaTime + lineCollisionSpeed);
        // Vector2 vector = Vector2.up * ((baseSpeed * Time.deltaTime + speed * gear * Time.deltaTime + levelSpeedUp * Time.deltaTime) * levelSpeedDown);
        return vector;
    }

    public bool GetChototsuFlg()
    {
        return chototsuFlg;
    }

    public void InvokeResetBubble()
    {
        Invoke("ResetVelocity", 0.3f);
        Invoke("ResetRotation", 0.3f);
    }

    public void ResetVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    public void SetAcceleration(float num)
    {
        acceleration = num;
        Invoke("ResetAcceleration", 1f);

    }

    public void ResetAcceleration()
    {
        acceleration = 0;
    }

    public void RunFlgTrue()
    {
        runFlg = true;
    }

    public void RunFlgFalse()
    {
        runFlg = false;
    }
    public Vector3 GetDir()
    {
        return transform.up;
    }
    public void SetGear(int num)
    {
        gear = num;
        if (gear == 6)
        {
            speed = 0.25f;
        }
        if (gear == 10)
        {
            speed = 0.3f;
        }
        // speed = speed * 1.1f + GameSystemTrick.instance.GetTotalPoint() * 0.00001f;
        // speed = 0.1f + GameSystemTrick.instance.GetTotalPoint() * 0.00002f;

        /*
        if(gear > 11)
        {
            taikoAudio.pitch =  1.5f;
            runAudio.pitch =  1.5f;
        }
        else
        {
            taikoAudio.pitch =  1f + gear * 0.05f;
            runAudio.pitch =  1f + gear * 0.05f;
        }
        */
    }
    public int GetGear()
    {
        return gear;
    }
    public void ReSetBaseSpeed()
    {
        baseSpeed -= 2f;
    }

    public void DeleteFiledInactivate()
    {
        df.DeleteFiledInactivate();
    }

    public float SetMureLifeTime()
    {
        float time;
        time = 30;
        return time;
    }

    public void GetWind(float num)
    {
        tsumuzikazeGage.fillAmount += num;
        // tsumuzikazeParticleUp.Play();
        if (tsumuzikazeGage.fillAmount >= 1 && !tsumuzikazeFlg)
        {
            // tsumuzikazeParticleContinue.Play();
            // tsumuzikazeParticleUp.Play();
            tsumuzikaze.SetActive(true);
            tsumuzikazeFlg = true;
            chototsuAudio.Play();
            ordinarySpeed += 2;
            taikoAudio.pitch = 1.5f;
            runAudio.pitch = 1.5f;

        }
        /*
        if(gear4 < baseSpeed)
        {

        }
        else if(gear4 >= baseSpeed && gear2 < baseSpeed)
        {
            baseSpeed += 0.026f * gear;
        }
        else if(gear2 >= baseSpeed && gear1< baseSpeed)
        {
            baseSpeed += 0.03f * gear;
        }
        else if(gear1 >= baseSpeed)
        {
            baseSpeed += 0.05f * gear;
        }
        */
    }

    public void SetToriCounter(int num)
    {
        toriCounter = num;
    }

    public void CollisionEnemy(GameObject collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (!enemy.GetBlowFlg())
        {
            // baseSpeed = 0;
            // SpeedEffect();
            VibrationMng.ShortVibration();
            // mainCameraScript.BlowStart();
            enemy.Blow(transform.position, transform.up, gear);
            /*
            if(enemy.GetJustFlg())
            {
                MCBlowStart();
            }
            */
            blowParticle.Play();
            /*
                if(enemy.GetJustFlg())
                {
                    blowParticle.Play();
                }
            */
        }

    }

    public void CollisionMureSymbol(GameObject collision)
    {
        if (chototsuItemGetFlg) { return; }
        chototsuItemGetFlg = true;
        Invoke("ChototsuItemGetFlgOff", 1);
        collision.transform.parent.gameObject.SetActive(false);
        chototsuAudio.Play();
        for (int n = 0; n < 7; n++)
        {
            Instantiate(mure, transform.position, collision.gameObject.transform.rotation);
        }
        /*
        int count;
        
        if(toriCounter >= 10)
        {
            count = 10;
        }
        else
        {
            count = toriCounter;
        }
        for(int n = 0; n < count; n++)
        {
            Instantiate(mure, transform.position, collision.gameObject.transform.rotation);
        }
        */
        // collision.SetActive(false);
    }

    public void CollisionTori(GameObject collision)
    {
        if (chototsuItemGetFlg) { return; }
        chototsuItemGetFlg = true;
        Invoke("ChototsuItemGetFlgOff", 1);
        collision.transform.parent.gameObject.SetActive(false);
        chototsuAudio.Play();
        GameSystemTrick.instance.GetTori("Tori");
    }

    public void CollisionAmaterasuSymbol(GameObject collision)
    {
        if (chototsuItemGetFlg) { return; }
        chototsuItemGetFlg = true;
        Invoke("ChototsuItemGetFlgOff", 1);
        collision.transform.parent.gameObject.SetActive(false);
        chototsuAudio.Play();
        amaterasu.SetActive(true);
        amaterasuScript.SetLifeTime(currentPoint * 0.0001f);
        /*
        if(toriCounter >= 10)
        {
            amaterasuScript.SetLifeTime(10 * 1);
        }
        else
        {
            amaterasuScript.SetLifeTime(toriCounter * 1);
        }
        */
    }

    public void BubbleReset()
    {
        Invoke("BubbleResetNext", 0.2f);
    }

    public void BubbleResetNext()
    {
        rb.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.angularVelocity = 0;
    }

    public void LineGetter(float num)
    {
        baseSpeed += num;
    }

    public void BaseSpeedReset()
    {
        baseSpeed = 0;
    }

    public void MCBlowStart()
    {
        mainCameraScript.BlowStart();
    }

    public void SetCurrentPoint(int point)
    {
        currentPoint = point;
        pointSpeed = point * 0.00003f;

    }

    public void ChototsuItemGetFlgOff()
    {
        chototsuItemGetFlg = false;
    }


}

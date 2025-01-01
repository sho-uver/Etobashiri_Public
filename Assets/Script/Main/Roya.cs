using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Roya : MonoBehaviour
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
    public bool sweetSpotFlg;
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
    public float sweetSpotRange;
    public bool windArrowScaleFlg;
    public float kingSpeed;
    public int murePoint;
    public int chototsuPoint;
    public int amaterasuPoint;
    public Vector3 hitPos;
    public bool hitEffectFlg;
    public ParticleSystem blowParticle;
    public ParticleSystem tokuParticle;
    public int breakCount;
    public GameObject royaImage0;
    public GameObject royaImage1;
    public GameObject royaImage2;
    public GameObject royaImage3;
    public GameObject royaImage4;
    public GameObject royaImage5;
    public bool breakFlg;
    private Transform objectTransform; // GameObjectのTransform
    public float jumpHeight; // ジャンプの高さ
    public float duration; // ジャンプにかかる時間（上昇と下降）
    public float jumpTime;
    public float rotationDuration;// 回転にかかる時間
    public float fadeDuration; // フェードアウトにかかる時間
    public bool deleteFlg;
    public bool mureFlg;
    public bool doubleBlockFlg;
    public GameObject shadowImage;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerClass = player.GetComponent<Player>();

        switch(name)
        {
            case "Gold":
                breakCount = 5;
                // breakCount = 0;
                break;

            case "Silver":
                breakCount = 3;
                // breakCount = 0;
                break;

            case "Togenkyo":
                breakCount = -1;
                breakFlg = true;
                break;

            case "Debug":
                breakCount = 1;
                break;
        }
        ChangeImage();
        // このGameObjectのTransformを取得
        

        // ジャンプのアニメーションを繰り返し実行
        InvokeRepeating(nameof(Jump), 0f, jumpTime); // 4秒ごとにジャンプ
    }

    // Update is called once per frame
    void Update()
    {
        if(sweetSpotFlg)
        {
            etopDir = transform.position - player.transform.position;
            playerDir = playerClass.GetDir();
            playerRot = player.transform.rotation;
            plusAngle = Vector3.SignedAngle (etopDir, playerDir, Vector3.forward);
            if(plusAngle > 90f)
            {
                plusAngle = 90;
            }
            else if(plusAngle < -90f)
            {
                plusAngle = -90;
            }
            else if(plusAngle <= 90f && plusAngle >= -90f)
            {
                plusAngle = plusAngle * -4f;
            }
            windArrow.transform.rotation = playerRot * Quaternion.AngleAxis(0 * sweetSpotRange + plusAngle, Vector3.forward);
            if(1.2f < windArrow.transform.localScale.x)
            {
                windArrowScaleFlg = false;
            }
            if(1f > windArrow.transform.localScale.x)
            {
                windArrowScaleFlg = true;
            }
            if(windArrowScaleFlg)
            {
                windArrow.transform.localScale += new Vector3(2,2,0) * Time.deltaTime;
            }
            else
            {
                windArrow.transform.localScale -= new Vector3(2,2,0) * Time.deltaTime;
            }
        }

        if(blowFlg)
        {
            transform.position += blowingDir.normalized * Time.deltaTime * 25;

            return;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Player":
                // Blow(collision.gameObject.transform.position);
                break;

            case "Enemy":
                
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(deleteFlg)
        {
            switch(collision.gameObject.tag)
            {
                case "Enemy":
                    collision.gameObject.SetActive(false);
                    break;

                case "Obstacle":
                    collision.gameObject.SetActive(false);
                    break;

                case "Hole":
                    collision.gameObject.SetActive(false);
                    break;

                case "Bubble":
                    collision.gameObject.SetActive(false);
                    break;

                case "Ice":
                    collision.gameObject.SetActive(false);
                    break;

                case "SnowBall":
                    collision.gameObject.SetActive(false);
                    break;

                case "Warp":
                    collision.gameObject.SetActive(false);
                    break;

            }
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "Mure":
                /*
                blowingDir = ((transform.position - collision.gameObject.transform.position) + blowingDir);
                
                if(sweetSpotFlg)
                {
                    sweetSpotFlg = false;
                    windArrow.SetActive(false);
                }
                audioSource.PlayOneShot(blowSE);
                blowFlg = true;
                */
                if(blowFlg)
                {
                    return;
                }
                if(mureFlg)
                {
                    return;
                }
                BreakCountDown(1);
                Blow(collision.gameObject.transform.position);
                
                mureFlg = true;
                break;

            case "Enemy":
                Enemy cge = collision.gameObject.GetComponent<Enemy>();
                /*
                if(sweetSpotFlg)
                {
                    sweetSpotFlg = false;
                    windArrow.SetActive(false);
                }
                audioSource.PlayOneShot(blowSE);
                */
                if(blowFlg)
                {
                    blowingDir = ((transform.position - cge.transform.position) + blowingDir);
                    // Blow(cge.center.transform.position);
                }
                if(!blowFlg)
                {
                    // blowingDir = ((transform.position - cge.transform.position) + blowingDir);
                    BreakCountDown(1);
                    Blow(cge.center.transform.position);
                    
                    return;
                }
                break;

            case "SnowBall":
                snowBallAudio = GameObject.FindWithTag("SnowBallSound").GetComponent<AudioSource>();
                snowBallAudio.Play();
                collision.gameObject.SetActive(false);
                break;

            case "Tori":
                blowingDir = ((transform.position - collision.gameObject.transform.position) + blowingDir);
                    // GameObject.FindWithTag("Player").GetComponent<Player>().CollisionTori(collision.gameObject);
                    break;

            case "MureSymbol":
                blowingDir = ((transform.position - collision.gameObject.transform.position) + blowingDir);
                    // GameObject.FindWithTag("Player").GetComponent<Player>().CollisionMureSymbol(collision.gameObject);
                    break;

            case "AmaterasuSymbol":
                blowingDir = ((transform.position - collision.gameObject.transform.position) + blowingDir);
                    // GameObject.FindWithTag("Player").GetComponent<Player>().CollisionAmaterasuSymbol(collision.gameObject);
                    break;

            case "Obstacle":
                if(blowFlg)
                {
                    blowingDir = ((transform.position - collision.gameObject.transform.position) + blowingDir);
                }
                break;

            case "Bubble":
                if(blowFlg)
                {
                    lifeTime += 0.5f;
                    blowingDir = ((transform.position - collision.gameObject.transform.position) + blowingDir);
                }
                else
                {
                    BreakCountDown(1);
                    Blow(collision.gameObject.transform.position);
                    
                }
                break;

            case "Amaterasu":

                break;

            case "Wall":

                if(blowFlg)
                {
                    if(player.transform.position.x > transform.position.x)
                    {
                        if(blowingDir.x < 0)
                        {
                            // blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                            blowingDir = new Vector3(0.3f, 0.7f, blowingDir.z);
                        }
                    }
                    if(player.transform.position.x < transform.position.x)
                    {
                        if(blowingDir.x > 0)
                        {
                            // blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                            blowingDir = new Vector3(-0.3f, 0.7f, blowingDir.z);
                        }
                    }
                }
                break;

            case "Cleaner":
                break;

            case "BoundWall":
                if(!blowFlg)
                {
                    break;
                }
                if(player.transform.position.y < transform.position.y)
                {
                    // blowFlg = false;
                }
                else
                {
                    blowingDir = new Vector3(blowingDir.x, 0.7f, blowingDir.z);
                    /*
                    if(blowingDir.y < 0)
                    {
                        blowingDir = new Vector3(blowingDir.x, blowingDir.y * -1, blowingDir.z);
                    }
                    */
                    break;
                }
                if(breakFlg)
                {
                    ChangeImage();
                    // Invoke(nameof(SetActiveFalse), 1f);
                }
                break;

            case "Player":
                if(collision.gameObject.GetComponent<Player>().GetChototsuFlg())
                {
                    VibrationMng.ShortVibration();
                    BlowChototsu();
                }
                if(blowFlg)
                {
                    // Blow(collision.gameObject.transform.position);
                    return;
                }
                
                if(!collision.gameObject.GetComponent<Player>().GetChototsuFlg())
                {
                    VibrationMng.ShortVibration();
                    BreakCountDown(1);
                    Blow(collision.gameObject.transform.position);
                    
                }
                
                break;

            case "Tsumuzikaze":
                bool flg = GameSystemTrick.instance.GetChototsuFlg();
                if(flg)
                {
                    return;
                }
                if(blowFlg)
                {
                    // Blow(collision.gameObject.transform.position);
                    return;
                }
                    VibrationMng.ShortVibration();
                    BreakCountDown(1);
                    Blow(collision.gameObject.transform.position);
                    
                break;

            case "Fire":
                // BlowChototsu();
                break;
                
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(deleteFlg)
        {
            switch(collision.gameObject.tag)
            {
                case "Enemy":
                    collision.gameObject.SetActive(false);
                    break;

                case "Obstacle":
                    collision.gameObject.SetActive(false);
                    break;

                case "Hole":
                    collision.gameObject.SetActive(false);
                    break;

                case "Bubble":
                    collision.gameObject.SetActive(false);
                    break;

                case "Ice":
                    collision.gameObject.SetActive(false);
                    break;

                case "SnowBall":
                    collision.gameObject.SetActive(false);
                    break;

                case "Warp":
                    collision.gameObject.SetActive(false);
                    break;

            }
            return;
        }
        if(blowFlg)
        {
            return;
        }
        if(breakFlg)
        {
            return;
        }
        /*
        if(collision.gameObject.tag == "Prism")
        {
            blowFlg = true;
        }
        */
        switch(collision.gameObject.tag)
        {
            /*
            case "Prism":
                blowFlg = true;
                break;

            case "Enemy":
                blowFlg = true;
                break;
            */
            case "Wall":
                if(player.transform.position.x > transform.position.x)
                {
                    if(blowingDir.x < 0)
                    {
                        // blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                        blowingDir = new Vector3(0.3f, blowingDir.y, blowingDir.z);
                    }
                }
                if(player.transform.position.x < transform.position.x)
                {
                    if(blowingDir.x > 0)
                    {
                        // blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                        blowingDir = new Vector3(-0.3f, blowingDir.y, blowingDir.z);
                    }
                }
                break;

            case "BoundWall":
                if(player.transform.position.y < transform.position.y)
                {
                    blowFlg = false;
                }
                else
                {
                    if(blowingDir.y < 0)
                    {
                        blowingDir = new Vector3(blowingDir.x, 0.5f, blowingDir.z);
                    }
                }
                break;
            
        }
    }

    public void Blow(Vector3 playerPos)
    {
        if(blowFlg)
        {
            return;
        }
        if(doubleBlockFlg)
        {
            return;
        }
        if(breakFlg)
        {
            audioSource.PlayOneShot(bomSE);
            // EndAnimation();
            switch(name)
            {
                case "Gold":
                    GameSystemTrick.instance.GetLifeThread();
                    
                    EndAnimationGold();
                    Invoke(nameof(SetActiveFalse), 2.5f);
                    break;

                case "Silver":
                    GameSystemTrick.instance.GetPoint(3000);
                    EndAnimation();
                    tokuParticle.Play();
                    // breakFlg = false;
                    Invoke(nameof(SetActiveFalse), 2.5f);
                    break;

                case "Togenkyo":
                    GameSystemTrick.instance.GetPoint(3000);
                    EndAnimation();
                    tokuParticle.Play();
                    // breakFlg = false;
                    Invoke(nameof(SetActiveFalse), 2.5f);
                    break;

                case "Debug":
                    GameSystemTrick.instance.GetLifeThread();
                    EndAnimation();
                    Invoke(nameof(SetActiveFalse), 2.5f);
                    break;
            }
            // Invoke(nameof(SetActiveFalse), 2.5f);
            // SetActiveFalse();
            doubleBlockFlg = true;
            // audioSource.PlayOneShot(bomSE);
            return;
        }
        sweetSpotFlg = false;
        windArrow.SetActive(false);
        blowingDir = transform.position - playerPos;
        blowFlg = true;
        // audioSource.PlayOneShot(blowSE);
        blowParticle.Play();
        StartCoroutine(HitStop());
        Invoke(nameof(Warp),3f);
        audioSource.PlayOneShot(blowSE);
    }

    public void Warp()
    {
        transform.position = new Vector3(Random.Range(-1.5f,1.5f), player.transform.position.y + 30, transform.position.z);
        blowFlg = false;
        deleteFlg = true;
        mureFlg = false;
        Invoke(nameof(DeleteFlgOff),1);
    }

    public void DeleteFlgOff()
    {
        deleteFlg = false;
    }

    public void EndAnimation()
    {
                // Z軸を中心に回転するアニメーション
        transform.DORotate(new Vector3(0, 1080, 0), rotationDuration, RotateMode.FastBeyond360)
                 .SetEase(Ease.Linear) // 等速回転
                 .SetLoops(-1, LoopType.Incremental); // 無限にループ

        // 透明度を0にするアニメーション（フェードアウト）
        var spriteRenderer = royaImage0.GetComponent<SpriteRenderer>();
        spriteRenderer.DOFade(0f, fadeDuration).SetEase(Ease.Linear);
        var spriteRenderer2 = shadowImage.GetComponent<SpriteRenderer>();
        spriteRenderer2.DOFade(0f, fadeDuration).SetEase(Ease.Linear);
    }

    public void EndAnimationGold()
    {
        // 透明度を0にするアニメーション（フェードアウト）
        var spriteRenderer = royaImage0.GetComponent<SpriteRenderer>();
        spriteRenderer.DOFade(0f, 0).SetEase(Ease.Linear);

        var spriteRenderer2 = shadowImage.GetComponent<SpriteRenderer>();
        spriteRenderer2.DOFade(0f, 0).SetEase(Ease.Linear);
    }

    public void BlowChototsu()
    {
        if(doubleBlockFlg)
        {
            return;
        }
        audioSource.PlayOneShot(bomSE);
        switch(name)
        {
            case "Gold":
                GameSystemTrick.instance.GetLifeThread();
                break;

            case "Silver":
                GameSystemTrick.instance.GetPoint(3000);
                break;

            case "Togenkyo":
                GameSystemTrick.instance.GetPoint(3000);
                break;

            case "Debug":
                GameSystemTrick.instance.GetLifeThread();
                break;
        }
        SetActiveFalse();
    }

    public void SetActiveFalse()
    {
        blowFlg = false;
        gameObject.SetActive(false);
    }

    IEnumerator ResetTime() 
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1f;
    }

    IEnumerator HitStop() 
    {
        hitsStopX = transform.position.x;
        hitStopFlg = true;
        yield return new WaitForSecondsRealtime(0.3f);
        hitStopFlg = false;
    }

    public bool GetJustFlg()
    {
        return justFlg;
    }

    public void SetJustFlg()
    {
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

    public void SweetSpotON()
    {
        if(blowFlg)
        {
            return;
        }
        if(breakFlg)
        {
            return;
        }
        sweetSpotFlg = true;
        windArrow.SetActive(true);
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
    }

    public void BreakCountDown(int downNum)
    {
        breakCount -= downNum;
        // Debug.Log(breakCount);
        if(breakCount <= -1)
        {
            breakFlg = true;
            // return;
        }
        ChangeImage();
    }

    public void ChangeImage()
    {
        if(breakCount <= 0)
        {
            royaImage0.SetActive(true);
            royaImage1.SetActive(false);
            royaImage2.SetActive(false);
            royaImage3.SetActive(false);
            royaImage4.SetActive(false);
            royaImage5.SetActive(false);
            objectTransform = royaImage0.GetComponent<Transform>();
            return;
        }

        switch(breakCount)
        {
            case 1:
                royaImage0.SetActive(false);
                royaImage1.SetActive(true);
                royaImage2.SetActive(false);
                royaImage3.SetActive(false);
                royaImage4.SetActive(false);
                royaImage5.SetActive(false);
                objectTransform = royaImage1.GetComponent<Transform>();
                break;

            case 2:
                royaImage0.SetActive(false);
                royaImage1.SetActive(false);
                royaImage2.SetActive(true);
                royaImage3.SetActive(false);
                royaImage4.SetActive(false);
                royaImage5.SetActive(false);
                objectTransform = royaImage2.GetComponent<Transform>();
                break;


            case 3:
                royaImage0.SetActive(false);
                royaImage1.SetActive(false);
                royaImage2.SetActive(false);
                royaImage3.SetActive(true);
                royaImage4.SetActive(false);
                royaImage5.SetActive(false);
                objectTransform = royaImage3.GetComponent<Transform>();
                break;

            case 4:
                royaImage0.SetActive(false);
                royaImage1.SetActive(false);
                royaImage2.SetActive(false);
                royaImage3.SetActive(false);
                royaImage4.SetActive(true);
                royaImage5.SetActive(false);
                objectTransform = royaImage4.GetComponent<Transform>();
                break;

            case 5:
                royaImage0.SetActive(false);
                royaImage1.SetActive(false);
                royaImage2.SetActive(false);
                royaImage3.SetActive(false);
                royaImage4.SetActive(false);
                royaImage5.SetActive(true);
                objectTransform = royaImage5.GetComponent<Transform>();
                break;
        }
    }

    void Jump()
    {
        if(blowFlg)
        {
            return;
        }
        // ジャンプアニメーションを実行
        objectTransform.DOLocalMoveY(jumpHeight, duration)
            .SetRelative() // 相対的な移動を行う
            .SetEase(Ease.OutQuad) // ジャンプのイージング（少しリアルなジャンプの動き）
            .SetLoops(2, LoopType.Yoyo); // 1回の上昇と1回の下降でループ
    }

}

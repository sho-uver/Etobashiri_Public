using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo_Player : MonoBehaviour
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
    private Coroutine vibrationCoroutine;
    public Animator animator;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (lineCollisionFlg)
        {
            lineCollisionTime += Time.deltaTime;
            if (lineCollisionTime > 0.1f) ResetGravity();
            rb.angularVelocity = 0f;
            rb.linearVelocity = new Vector2(0, 0);
        }

        transform.Translate(Vector2.up * (speed * gear * Time.deltaTime + ordinarySpeed * Time.deltaTime));
    }


    public void ResetPosition()
    {
        transform.position = new Vector2(-1.5f, -10f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void ResetGravity()
    {
        rb.gravityScale = 0;
        lineCollisionFlg = false;
        lineCollisionTime = 0;
        animator.SetBool("LineFlg", false);
        StopVibration();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {


        switch (collision.gameObject.tag)
        {
            case "Enemy":
                CollisionEnemy(collision.gameObject);
                break;


            case "Wall":
                transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(0 - transform.position.x / 2, 10, transform.position.z));
                transform.position = new Vector3(transform.position.x + (0 - transform.position.x) / 5, transform.position.y, transform.position.z);

                break;

            case "Cleaner":
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case "Gate":
                ResetPosition();
                break;
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Wall":
                transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(transform.position.x, 10, transform.position.z));
                transform.position = new Vector3(transform.position.x + (0 - transform.position.x) / 5, transform.position.y, transform.position.z);
                break;

            case "Cleaner":
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

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
#if UNITY_ANDROID || UNITY_IOS
Handheld.Vibrate(); // Android/iOS のみの場合
#endif

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
            Demo_Line lineScript = collision.gameObject.GetComponent<Demo_Line>();
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

                // SetDirection(lineScript.GetDir());
            }
            // rb.gravityScale = defaultGravityScale;
            lineCollisionFlg = true;
            lineCollisionTime = 0;
            animator.SetBool("LineFlg", true);
            // StartVibration();
            Demo_Step2.Instance.PlayerCollisionLine();
        }

    }

    public void SetDirection(Vector2 direction)
    {
        // ベクトルの向きを取得
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 回転を設定（Z軸回り）
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.Log(angle);
        Debug.Log(transform.rotation);
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

    public void ResetVelocity()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
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
    public void ReSetBaseSpeed()
    {
        baseSpeed -= 2f;
    }

    public void DeleteFiledInactivate()
    {
        df.DeleteFiledInactivate();
    }

    public void CollisionEnemy(GameObject collision)
    {
        VibrationMng.ShortVibration();
        blowParticle.Play();

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
    }

    public void BubbleReset()
    {
        Invoke("BubbleResetNext", 0.2f);
    }

    public void BubbleResetNext()
    {
        rb.linearVelocity = Vector3.zero;
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

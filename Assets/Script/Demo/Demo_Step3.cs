using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
public class Demo_Step3 : MonoBehaviour
{
    public GameObject nextBtn;
    // step開始時はそのステップ数、ステップ終了後に変更する。直接数値を入れる。
    public int step;
    private static Demo_Step3 instance;
    public bool drawFlg;
    public GameObject player;
    public GameObject finger;
    public GameObject enemy;
    public GameObject people;

    // インスタンスを取得するためのプロパティ
    public static Demo_Step3 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Demo_Step3>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Demo_Step3>();
                    singletonObject.name = typeof(Demo_Step3).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }

    // Awakeメソッドでインスタンスを設定
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は破棄
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!drawFlg) return;
        if (Input.touchSupported)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.touches[i].fingerId == 0)
                {
                    Demo_DrawLine.Instance.SPDraw(Input.GetTouch(i));
                    SPDraw(Input.GetTouch(i));
                }
            }
        }
        else
        {
            Demo_DrawLine.Instance.PCDraw();
            PCDraw();
        }
    }

    public void NextBtn()
    {
        switch (step)
        {
            case 2:
                nextBtn.SetActive(false);
                StartCoroutine(Step2());
                break;
            case 4:
                nextBtn.SetActive(false);
                StartCoroutine(Step4());
                break;
            case 5:
                nextBtn.SetActive(false);
                StartCoroutine(Step5());
                break;
            case 6:
                nextBtn.SetActive(false);
                StartCoroutine(Step6());
                break;
            case 7:
                nextBtn.SetActive(false);
                StartCoroutine(Step7());
                break;
            case 8:
                SceneManager.LoadScene("Mugen");
                break;
        }
        nextBtn.SetActive(false);
    }
    public void PlayerCollisionLine()
    {
        switch (step)
        {
            case 3:
                StartCoroutine(Step3());
                break;
        }
    }
    public void PlayerCollisionEnemy()
    {
        StartCoroutine(Step3());
    }

    public void SPDraw(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                finger.SetActive(false);
                break;

            case TouchPhase.Moved:
                break;

            case TouchPhase.Ended:

                break;
        }
    }

    public void PCDraw()
    {
        if (Input.GetMouseButtonDown(0))
        {
            finger.SetActive(false);
        }
        if (Input.GetMouseButton(0))
        {
        }
        if (Input.GetMouseButtonUp(0))
        {

        }
    }

    public void StartStep()
    {
        StartCoroutine(Step1());
    }

    public IEnumerator Step1()
    {
        player.SetActive(false);
        player.GetComponent<Demo_Player>().ResetPosition();
        // 今出てきた黒いやつは敵だよ

        yield return new WaitForSeconds(0.5f);
        enemy.SetActive(true);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step3_1"));
        yield return new WaitForSeconds(2);

        nextBtn.SetActive(true);

        step = 2;
    }

    public IEnumerator Step2()
    {
        // うまく壁を作って敵にえとをぶつけよう！
        yield return new WaitForSeconds(0.5f);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step3_2"));
        yield return new WaitForSeconds(1);
        drawFlg = true;
        finger.SetActive(true);
        player.SetActive(true);
        step = 3;
    }

    public IEnumerator Step3()
    {
        // 敵がボムした時に発動
        // えとが敵にぶつかると敵を倒せるよ！
        step = 4;
        yield return new WaitForSeconds(1);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step3_3"));
        yield return new WaitForSeconds(1);
        nextBtn.SetActive(true);
    }

    public IEnumerator Step4()
    {
        // 本番では敵を倒しながら12年間走り抜けるとクリアになるよ！
        player.SetActive(false);
        step = 5;
        yield return new WaitForSeconds(1);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step3_4"));
        yield return new WaitForSeconds(1);
        nextBtn.SetActive(true);
    }

    public IEnumerator Step5()
    {
        // 今出てきたのは応援団

        yield return new WaitForSeconds(0.5f);
        people.SetActive(true);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step3_5"));
        yield return new WaitForSeconds(1);
        nextBtn.SetActive(true);
        step = 6;
    }

    public IEnumerator Step6()
    {
        // 敵を倒せないと彼らが一人帰ってしまうよ！
        //全員帰ったらゲームオーバーだ
        yield return new WaitForSeconds(0.5f);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step3_6"));
        yield return new WaitForSeconds(1);
        nextBtn.SetActive(true);
        step = 7;
    }

    public IEnumerator Step7()
    {
        // それじゃあ完走できるように頑張ってね！
        yield return new WaitForSeconds(0.5f);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step3_7"));
        yield return new WaitForSeconds(1);
        nextBtn.SetActive(true);
        step = 8;
    }

}

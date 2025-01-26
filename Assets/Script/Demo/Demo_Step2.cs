using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class Demo_Step2 : MonoBehaviour
{
    public GameObject nextBtn;
    // step開始時はそのステップ数、ステップ終了後に変更する。直接数値を入れる。
    public int step;
    private static Demo_Step2 instance;
    public bool drawFlg;
    public GameObject player;
    public GameObject finger;

    // インスタンスを取得するためのプロパティ
    public static Demo_Step2 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Demo_Step2>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Demo_Step2>();
                    singletonObject.name = typeof(Demo_Step2).ToString() + " (Singleton)";
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
        // 走ってるのはえとだよ
        player.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step2_1"));
        yield return new WaitForSeconds(2);
        nextBtn.SetActive(true);
        step = 2;
    }

    public IEnumerator Step2()
    {
        // 線を引いてぶつけてみよう
        yield return new WaitForSeconds(0.5f);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step2_2"));
        yield return new WaitForSeconds(2);
        drawFlg = true;
        finger.SetActive(true);
        step = 3;
    }

    public IEnumerator Step3()
    {
        // えとが壁にぶつかった時に発動
        // えとは壁にぶつかると壁走りをするよ！
        step = 4;
        Time.timeScale = 0.2f;
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step2_3"));
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;
        nextBtn.SetActive(true);
    }

    public IEnumerator Step4()
    {
        // 大Step3に移動
        yield return new WaitForSeconds(0.5f);
        Demo_Step3.Instance.StartStep();
        step = 5;
    }
}

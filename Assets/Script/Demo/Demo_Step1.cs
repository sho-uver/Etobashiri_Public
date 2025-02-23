using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class Demo_Step1 : MonoBehaviour
{
    public GameObject nextBtn;
    // step開始時はそのステップ数、ステップ終了後に変更する。直接数値を入れる。
    public int step;
    private static Demo_Step1 instance;
    public bool drawFlg;
    public GameObject finger;

    // インスタンスを取得するためのプロパティ
    public static Demo_Step1 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Demo_Step1>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Demo_Step1>();
                    singletonObject.name = typeof(Demo_Step1).ToString() + " (Singleton)";
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
        PlayerPrefs.SetInt("DemoDone", 1);
        StartCoroutine(Step1());
        step = 1;
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
            case 3:
                StartCoroutine(Step3());
                break;
        }
        nextBtn.SetActive(false);
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
                if (step == 2)
                {
                    drawFlg = false;
                    StartCoroutine(Step2());
                }
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
            if (step == 2)
            {
                drawFlg = false;
                StartCoroutine(Step2());
            }
        }
    }

    public IEnumerator Step1()
    {
        // 線を引いてみよう
        yield return new WaitForSeconds(0.5f);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step1_1"));
        yield return new WaitForSeconds(2);
        finger.SetActive(true);
        drawFlg = true;
        step = 2;
    }

    public IEnumerator Step2()
    {
        // 線を引いたら壁が出てくるよ
        yield return new WaitForSeconds(0.5f);
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString("TextTable", "Step1_2"));
        yield return new WaitForSeconds(1);
        nextBtn.SetActive(true);
        step = 3;

    }

    public IEnumerator Step3()
    {
        // 大Step2に移動
        yield return new WaitForSeconds(0.5f);
        Demo_Step2.Instance.StartStep();
        drawFlg = false;
        step = 4;
    }
}

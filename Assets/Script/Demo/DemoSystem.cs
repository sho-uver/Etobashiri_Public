using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSytem : MonoBehaviour
{
    public int step;
    private string tableName = "TextTable"; // Localizationテーブル名を指定

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start0());
    }

    // Update is called once per frame
    void Update()
    {
        switch (step)
        {
            case 1:
                Step1();
                break;

            case 2:
                Step2();
                break;
        }
    }

    public void NextBtn()
    {
        switch (step)
        {
            case 4:
                Step4();
                break;

            case 5:
                Step5();
                break;

            case 8:
                Step8();
                break;
        }
    }

    public int PostStep()
    {
        return step;
    }

    public IEnumerator Step0()
    {
        // 線を引くと壁を作れるよ！日本線を引いてみよう
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step1"));
        step++;
        yield return new WaitForSeconds(1);
    }

    public void Step1()
    {
        // そうそう！もう一本引いてみよう！
        if (Input.GetMouseButtonUp(0))
        {
            TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step2"));
        }
        step++;
    }

    public void Step2()
    {
        // 上手！
        if (Input.GetMouseButtonUp(0))
        {
            TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step3"));
        }
        step++;
        Step3();
    }
    public IEnumerator Step3()
    {
        // 今道を走っているのはえとだよ！
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Step4()
    {
        // えとは壁にぶつかると壁走りをするよ！
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Step5()
    {
        // えとは壁にぶつかると壁走りをするよ！実査にやってみよう
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Step6()
    {
        // えとが横になったらえとを止めて呼び出す
        // そうそう！えとが横向きの絵になっている時が壁走りの状態。方向を変えることができるよ。
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
        // えとを動かし1秒したら敵を出す
        Step7()
    }

    public IEnumerator Step7()
    {
        // 今出てきた黒くて丸いやつは敵だよ。
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Step8()
    {
        // えとをぶつけてぶっ飛ばセルよ！やってみよう
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Step9()
    {
        // 敵をボムさせたら呼び出す
        // 上手上手！もう一体行ってみよう.
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Step10()
    {
        // 敵をボムさせたら呼び出す
        // いいね！本番でもボムを見つけたら必ずぶっ飛ばしてね！
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
        Step11();
    }

    public IEnumerator Step12()
    {
        // この白いのは応援団でボムを取り逃すと彼らが一人減るよ！
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
        Step13()
    }

    public IEnumerator Step13()
    {
        // 応援団が全員いなくなったらゲームオーバーになるから気をつけて！
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Step14()
    {
        // それじゃあ完走目指して頑張ろう！
        TypewriterText.Instance.DisplayInterruptibleText(LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "step4"));
        step++;
        yield return new WaitForSeconds(1);
    }




}

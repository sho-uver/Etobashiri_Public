using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 最近のスマホゲームによくある「スタミナ」を扱うクラス
/// </summary>
public class StaminaController : MonoBehaviour {

    // UIに表示する場合はInspectorから以下を設定してあげる
    [SerializeField]
    private Text staminaNumText; // スタミナの値を表示するテキスト

    [SerializeField]
    private Text restStaminaTimeText; // スタミナが1回復するまでの残り時間を表示するテキスト

    [SerializeField]
    private Slider staminaBarSlider; // スタミナの割合を表示するバー

    private bool isInitializeFinished = false;
    private int nowStaminaNum;
    private int maxStaminaNum;
    private DateTime recoveryStartTime;
    private int recoverTimePerStamina;

    void Start()
    {
        // テスト -> [現在のスタミナ30、スタミナ最大50、現在時刻から回復開始、300秒（5分）で1回復する] で初期化する
        // 使うときにゲームを管理しているクラスとかからプレイヤーのスタミナと回復開始時刻と1回復する秒数を渡してあげる感じ
        Init(30, 50, DateTime.Now, 300);
    }

    void Update()
    {
        if (isInitializeFinished)
        {
            UpdateStamina();
            UpdateStaminaBar();
        }
    }

    /// <summary>
    /// 使うときはこの初期化を呼び出す
    /// </summary>
    /// <param name="nowStaminaNum">スタミナ現在値</param>
    /// <param name="maxStaminaNum">スタミナ最大値</param>
    /// <param name="recoveryStartTime">スタミナ回復を開始した時間</param>
    /// <param name="recoverTimePerStamina">スタミナを1回復する時間（秒）</param>
    public void Init(int nowStaminaNum, int maxStaminaNum, DateTime recoveryStartTime, int recoverTimePerStamina)
    {
        this.nowStaminaNum = nowStaminaNum;
        this.maxStaminaNum = maxStaminaNum;
        this.recoveryStartTime = recoveryStartTime;
        this.recoverTimePerStamina = recoverTimePerStamina;

        Debug.Log("スタミナ " + this.nowStaminaNum + " / " + this.maxStaminaNum
                  + " スタミナが最大値未満になった時間：" + this.recoveryStartTime);

        isInitializeFinished = true;
    }

    /// <summary>
    /// 現在の日時を取得する
    /// </summary>
    /// <returns>現在の日時を返す</returns>
    private DateTime GetTimeNow()
    {
        return DateTime.Now; // ゲームを管理しているクラスとかからサーバ時間を渡してあげるようにしたい
    }

    /// <summary>
    /// スタミナが最大値以上かどうか
    /// </summary>
    /// <returns><c>true</c>最大以上である <c>false</c>最大ではない</returns>
    public bool IsStaminaFull()
    {
        return nowStaminaNum >= maxStaminaNum;
    }

    /// <summary>
    /// スタミナの更新
    /// </summary>
    private void UpdateStamina()
    {
        // スタミナが最大以上の場合は表示更新のみ
        if (IsStaminaFull())
        {
            if (staminaNumText != null) staminaNumText.text = "" + nowStaminaNum + " / " + maxStaminaNum;
            if (restStaminaTimeText != null) restStaminaTimeText.text = "MAX";

            return;
        }

        DateTime time = GetTimeNow();
        TimeSpan diff = time - recoveryStartTime;
        double totalSeconds = diff.TotalSeconds;

        // 経過時間分のスタミナを回復させる
        while (totalSeconds > recoverTimePerStamina)
        {
            if (IsStaminaFull()) break;

            totalSeconds -= recoverTimePerStamina;
            recoveryStartTime = recoveryStartTime.Add(TimeSpan.FromSeconds(recoverTimePerStamina));
            nowStaminaNum++;
        }

        double restTime = recoverTimePerStamina - totalSeconds + 1; // 「+1」->00:00を見せないため
        int minutes = (int)restTime / 60;
        int seconds = (int)restTime % 60;

        if (staminaNumText != null) staminaNumText.text = "" + nowStaminaNum + " / " + maxStaminaNum;
        if (restStaminaTimeText != null) restStaminaTimeText.text = ""
                + string.Format("{0:D2}", minutes) + ":" + string.Format("{0:D2}", seconds);
    }

    /// <summary>
    /// スタミナバーの表示更新
    /// </summary>
    private void UpdateStaminaBar()
    {
        if (staminaBarSlider != null)
        {
            // スタミナの現在値と最大値の割合をスタミナバーに反映する
            // バーは最大値を超えない
            float staminaPercentage = (float)nowStaminaNum / (float)maxStaminaNum;
            if (staminaPercentage >= 1) staminaPercentage = 1;
            staminaBarSlider.value = staminaPercentage;
        }
    }

    /// <summary>
    /// スタミナを消費する
    /// </summary>
    /// <returns><c>true</c>スタミナを消費した <c>false</c>スタミナが不足している</returns>
    /// <param name="spendStaminaNum">消費するスタミナ値</param>
    public bool SpendStamina(int spendStaminaNum)
    {
        if (nowStaminaNum < spendStaminaNum) return false;

        // スタミナ消費後の値がスタミナ最大値を下回った際に時間を保存する（回復開始となる時間）
        if (nowStaminaNum >= maxStaminaNum && (nowStaminaNum - spendStaminaNum) < maxStaminaNum)
        {
            recoveryStartTime = GetTimeNow();

            // ゲームを管理しているクラスとかで回復開始となる時間を保存しておく
            //SystemManager systemManager = GameObject.Find("SystemManager").GetComponent<SystemManager>();
            //systemManager.SaveTimeStamp(recoveryStartTime);
        }

        nowStaminaNum -= spendStaminaNum;

        return true;
    }

    /// <summary>
    /// スタミナを回復する
    /// </summary>
    /// <param name="num">回復する値</param>
    public void RecoverStamina(int num)
    {
        if (IsStaminaFull()) return;
        nowStaminaNum += num;
        if (nowStaminaNum > maxStaminaNum) nowStaminaNum = maxStaminaNum;
    }

    /// <summary>
    /// スタミナを最大値を無視して回復する
    /// </summary>
    /// <param name="num">回復する値</param>
    public void RecoverStaminaOverLimit(int num)
    {
        nowStaminaNum += num;
    }

    /// <summary>
    /// 最大値までスタミナを回復させる
    /// </summary>
    public void RecoverStaminaMax()
    {
        if (IsStaminaFull()) return;
        nowStaminaNum = maxStaminaNum;
    }

    /// <summary>
    /// 最大値分のスタミナを回復させる
    /// </summary>
    public void RecoverStaminaMaxOverLimit()
    {
        nowStaminaNum += maxStaminaNum;
    }
}
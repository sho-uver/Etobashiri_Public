using UnityEngine;
using DG.Tweening;

public class ButtonShake : MonoBehaviour
{
    public RectTransform buttonRectTransform; // インスペクターから割り当てる
    public float minShakeInterval = 2f; // 揺れる最小間隔
    public float maxShakeInterval = 5f; // 揺れる最大間隔

    void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        // 最初の揺れをスケジュール
        ScheduleNextShake();
    }

    void ScheduleNextShake()
    {
        // 次の揺れまでのランダムな時間を決定
        float delay = Random.Range(minShakeInterval, maxShakeInterval);
        
        // ランダムなディレイの後にShakeButtonメソッドを実行
        DOVirtual.DelayedCall(delay, ShakeButton);
    }

    void ShakeButton()
    {
        // 揺れのアニメーション
        // ここでは例としてZ軸周りで10度の揺れを0.5秒間で実行
        buttonRectTransform.DOShakeRotation(0.5f, new Vector3(0f, 0f, 5f), 10, 90);

        // 次の揺れをスケジュール
        ScheduleNextShake();
    }
}

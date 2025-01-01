using UnityEngine;
using DG.Tweening;

public class ButtonJump : MonoBehaviour
{
    private RectTransform buttonRectTransform; // ボタンのRectTransform
    public float jumpHeight; // ジャンプの高さ
    public float duration; // ジャンプにかかる時間（上昇と下降）
    public float jumpTime;

    void Start()
    {
        jumpHeight = 50f;
        duration = 0.2f;
        jumpTime = 3;

        // このGameObjectのRectTransformを取得
        buttonRectTransform = GetComponent<RectTransform>();

        // ジャンプのアニメーションを繰り返し実行
        InvokeRepeating(nameof(Jump), 0f, jumpTime); // 4秒ごとにジャンプ
    }

    void Jump()
    {
        // ジャンプアニメーションを実行
        buttonRectTransform.DOLocalMoveY(jumpHeight, duration)
            .SetRelative() // 相対的な移動を行う
            .SetEase(Ease.OutQuad) // ジャンプのイージング（少しリアルなジャンプの動き）
            .SetLoops(2, LoopType.Yoyo); // 1回の上昇と1回の下降でループ
    }
}

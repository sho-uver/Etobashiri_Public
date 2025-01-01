using UnityEngine;
using DG.Tweening;

public class SShapeMovement : MonoBehaviour
{
    public Vector3 pos1, pos2, pos3, pos4, pos5, pos6;
    public float time;
    private Sequence sequence;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // S字形のパスを2つ定義
        Vector3[] firstPath = { pos1, pos2, pos3 };
        Vector3[] secondPath = { pos4, pos5, pos6 };

        // DOTweenシーケンスの作成
        sequence = DOTween.Sequence();
        // sequence.Append(spriteRenderer.DOFade(1f, 0.5f));
        // spriteRenderer.DOFade(1f, 0f);

        // ワープ前のパス
        sequence.Append(transform.DOPath(firstPath, time, PathType.CatmullRom).SetEase(Ease.Linear))
                .Join(spriteRenderer.DOFade(1f, 0.5f))
                .AppendCallback(() => WarpEffect(secondPath)); // ワープ効果

        // ワープ後のパス
        sequence.Append(transform.DOPath(secondPath, time, PathType.CatmullRom).SetEase(Ease.Linear));

        sequence.Append(spriteRenderer.DOFade(0f, 0.2f));

        // シーケンスの設定
        sequence.Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);
        MySequence();
    }

    void WarpEffect(Vector3[] path)
    {
        // ワープ効果: オブジェクトを一瞬非表示にし、指定した位置に移動
        gameObject.SetActive(false);
        transform.position = path[0]; // ワープ地点に移動
        gameObject.SetActive(true);
    }

    public void MySequence()
    {
        
        // シーケンスの再開
        sequence.Restart();
        // sequence.Append(spriteRenderer.DOFade(1f, 0f));
    }
}

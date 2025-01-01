using UnityEngine;
using DG.Tweening;

public class DemoPlayer : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;
    public Vector3 pos5;
    public Vector3 pos6;
    public float time;
    public Sequence sequence;
    private SpriteRenderer spriteRenderer;

    private Vector3[] path;
    private int currentTargetIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // S字形のパスを定義します。
        path = new Vector3[] {
            pos1, pos2, pos3, pos4, pos5, pos6
        };

        // DOTweenシーケンスを作成します。
        sequence = DOTween.Sequence();
        
        

        // シーケンスの開始時に0.3秒のディレイを追加します。
        sequence.AppendInterval(0.5f); // 0.5秒待つ
                

        // シーケンスにS字形のパス上を移動するアニメーションを追加します。
        sequence.Append(transform.DOPath(path, time, PathType.CatmullRom)
            .SetOptions(false)
            .SetEase(Ease.Linear)
            .OnWaypointChange(OnWaypointChanged))
            .Join(spriteRenderer.DOFade(1f, 0.5f));

        sequence.Append(spriteRenderer.DOFade(0f, 0.2f));

        // シーケンスの設定
        sequence.Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);
        MySequence();
        // シーケンスを無限にループさせます。
        // sequence.SetLoops(-1, LoopType.Restart);
    }

    void Update()
    {
        if (currentTargetIndex < path.Length)
        {
            Vector3 targetDirection = (path[currentTargetIndex] - transform.position).normalized;
            float angle = Mathf.Atan2(-1 * targetDirection.x, targetDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnWaypointChanged(int waypointIndex)
    {
        currentTargetIndex = waypointIndex;
    }

    public void MySequence()
    {
        sequence.Restart();
    }
}

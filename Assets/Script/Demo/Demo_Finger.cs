using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class Demo_Finger : MonoBehaviour
{
    [SerializeField] private float moveDistance = 2f;    // S字の振幅
    public float moveDuration;    // 移動にかかる時間
    [SerializeField] private float parabolicHeight = 5f; // 放物線の高さ
    [SerializeField] private Transform[] sWaypoints;      // S字用の通過点
    [SerializeField] private Transform[] parabolicWaypoints;  // 放物線用の通過点
    [SerializeField] private bool isClosedPath = false;
    [SerializeField] private Color waypointColor = Color.blue;
    [SerializeField] private Color pathColor = Color.yellow;
    [SerializeField] private float waypointSize = 0.3f;
    [SerializeField] private PathType pathType = PathType.CatmullRom;
    [SerializeField] private Ease easeType = Ease.Linear;

    // パスの色を個別に設定
    [SerializeField] private Color sPathColor = Color.red;        // S字パスの色
    [SerializeField] private Color parabolicPathColor = Color.blue; // 放物線パスの色

    public Transform[] currentWaypoints;  // 現在使用中のwaypoints

    public int pattern;

    private void Start()
    {
        switch (pattern)
        {
            case 1:
                currentWaypoints = sWaypoints;
                break;
            case 2:
                currentWaypoints = parabolicWaypoints;
                break;
        }
        StartWaypointMovement();
    }

    private void KillAllTweens()
    {
        // すべてのTweenを確実に停止
        transform.DOKill(true);  // complete = true
        DOTween.Kill(transform);
    }

    public void StartWaypointMovement()
    {
        if (currentWaypoints == null || currentWaypoints.Length < 2)
        {
            Debug.LogWarning("少なくとも2つの通過点が必要です。");
            return;
        }

        // すべてのTweenを停止させてから始める
        KillAllTweens();

        // 最初のウェイポイントに位置を合わせる
        if (currentWaypoints[0] != null)
        {
            transform.position = currentWaypoints[0].position;
        }

        Vector3[] path = new Vector3[currentWaypoints.Length];
        for (int i = 0; i < currentWaypoints.Length; i++)
        {
            if (currentWaypoints[i] == null)
            {
                Debug.LogError($"Waypoint {i} が設定されていません。");
                return;
            }
            path[i] = currentWaypoints[i].position;
        }

        Sequence pathSequence = DOTween.Sequence();
        pathSequence.Append(
            transform.DOPath(
                path,
                moveDuration,
                pathType,
                PathMode.Sidescroller2D,
                10
            )
            .SetOptions(isClosedPath)
            .SetEase(easeType)
        )
        .SetLoops(-1);
    }



    private void OnDrawGizmos()
    {
        // S字パスの描画
        DrawWaypointPath(sWaypoints, sPathColor);

        // 放物線パスの描画
        DrawWaypointPath(parabolicWaypoints, parabolicPathColor);
    }

    // パス描画用のヘルパーメソッド
    private void DrawWaypointPath(Transform[] points, Color pathColor)
    {
        if (points == null || points.Length < 2)
            return;

        // 通過点を球体で表示
        Gizmos.color = waypointColor;
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] != null)
            {
                Gizmos.DrawSphere(points[i].position, waypointSize);

#if UNITY_EDITOR
                UnityEditor.Handles.Label(points[i].position + Vector3.up * waypointSize,
                    $"Point {i}");
#endif
            }
        }

        // パスを表示
        Gizmos.color = pathColor;
        for (int i = 0; i < points.Length - 1; i++)
        {
            if (points[i] != null && points[i + 1] != null)
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }

        if (isClosedPath && points.Length > 2)
        {
            if (points[0] != null && points[points.Length - 1] != null)
                Gizmos.DrawLine(points[points.Length - 1].position, points[0].position);
        }
    }

    private void OnDestroy()
    {
        KillAllTweens();  // Tweenのクリーンアップのみ残す
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}

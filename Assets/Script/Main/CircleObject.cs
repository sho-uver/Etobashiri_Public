/*
using UnityEngine;
using UnityEngine.UI;

public class CircleObject : MonoBehaviour
{
    public int startAngle = 15;
    public int endAngle = 270;
    public float radius = 100f;

    void Start()
    {
        // オブジェクトを配置するRectTransformを生成
        RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(radius * 2f, radius * 2f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        // オブジェクトの形状を設定するためにMaskコンポーネントを追加
        Mask mask = gameObject.AddComponent<Mask>();
        mask.showMaskGraphic = false;

        // オブジェクトに表示するImageを生成
        Image image = gameObject.AddComponent<Image>();
        image.color = Color.white;

        // 表示範囲を制限するためにRectMask2Dコンポーネントを追加
        RectMask2D rectMask2D = gameObject.AddComponent<RectMask2D>();
        rectMask2D.padding = new Vector4(radius, radius, radius, radius);

        // 表示範囲にだけColliderを追加するために、Childオブジェクトを生成
        GameObject childObject = new GameObject("ChildObject");
        childObject.transform.SetParent(gameObject.transform);
        childObject.transform.localPosition = Vector3.zero;

        // 表示範囲にだけColliderを追加するために、ChildオブジェクトにColliderを追加
        CircleCollider2D collider = childObject.AddComponent<CircleCollider2D>();
        collider.radius = radius;
        collider.offset = new Vector2(0f, 0f);

        // 円形に表示するための頂点情報を生成
        int numVertices = (endAngle - startAngle) / 15 + 2;
        Vector2[] vertices = new Vector2[numVertices];
        float radian = (float)startAngle * Mathf.Deg2Rad;
        vertices[0] = new Vector2(0f, 0f);
        for (int i = 1; i < numVertices; i++)
        {
            float x = radius * Mathf.Cos(radian);
            float y = radius * Mathf.Sin(radian);
            vertices[i] = new Vector2(x, y);
            radian += (15f * Mathf.Deg2Rad);
        }

        // Meshを生成して、オブジェクトに設定
        Mesh mesh = new Mesh();
        mesh.vertices = System.Array.ConvertAll<Vector2, Vector3>(vertices, v => v);
        int[] triangles = new int[(numVertices - 2) * 3];
        for (int i = 0; i < numVertices - 2; i++)
        {
            triangles[i * 3 + 0] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        image.sprite = Sprite2D.Create(mesh, new Rect(0f, 0f, radius * 2f, radius * 2f), new Vector2(0.5f, 0.5f), 100f);
    }
}
*/
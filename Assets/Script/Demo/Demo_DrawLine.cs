using UnityEngine;
using System.Collections;

public class Demo_DrawLine : MonoBehaviour
{
    public float lineLength;
    public float lineWidth;
    public GameObject fude;
    public GameObject[] objs;
    public int lineCount;
    public Vector3 lineStartPos;
    public GameObject linePrefab;

    private Vector3 touchPos;
    private Vector3 startPos;
    private Vector3 endPos;

    // シングルトンインスタンス
    private static Demo_DrawLine instance;

    // インスタンスを取得するためのプロパティ
    public static Demo_DrawLine Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Demo_DrawLine>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Demo_DrawLine>();
                    singletonObject.name = typeof(Demo_DrawLine).ToString() + " (Singleton)";
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

    void Start()
    {
        lineStartPos = new Vector3(0, -100, 0);
        objs = new GameObject[100];
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i] = (i % 2 == 0) ? Instantiate(linePrefab, lineStartPos, transform.rotation) : Instantiate(linePrefab, lineStartPos, transform.rotation);
            objs[i].transform.parent = this.transform;
            objs[i].GetComponent<Renderer>().sortingOrder = 200 - i; // レイヤー順序を設定
        }
    }

    void Update()
    {

    }

    public void SPDraw(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                BeganDraw(touch.position);
                break;

            case TouchPhase.Moved:
                MoveDraw(touch.position);
                break;

            case TouchPhase.Ended:
                EndDraw(touch.position);
                break;
        }
    }

    public void PCDraw()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeganDraw(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            MoveDraw(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDraw(Input.mousePosition);
        }
    }

    public void BeganDraw(Vector3 inputPos)
    {
        touchPos = Camera.main.ScreenToWorldPoint(inputPos);
        touchPos.z = 0;
    }

    public void MoveDraw(Vector3 inputPos)
    {
        startPos = touchPos;
        endPos = Camera.main.ScreenToWorldPoint(inputPos);
        endPos.z = 0;

        if (startPos.y > endPos.y)
        {
            return;
        }

        if ((endPos - startPos).magnitude > lineLength)
        {
            float segments = Mathf.Floor((endPos - startPos).magnitude / lineLength);
            for (int n = 0; n < segments; n++)
            {
                float posPer = (n + 1) / segments;
                objs[lineCount].transform.position = startPos + (endPos - startPos) * posPer;

                objs[lineCount].GetComponent<Demo_Line>().SetLineCount(lineCount);
                objs[lineCount].GetComponent<Demo_Line>().SetDir((endPos - startPos).normalized);

                lineCount = (lineCount >= objs.Length - 1) ? 0 : lineCount + 1;
            }
            touchPos = endPos;
        }
    }

    public void EndDraw(Vector3 inputPos)
    {
    }

    IEnumerator AudioFadeOut()
    {
        yield return null; // 必要であれば実装
    }
}
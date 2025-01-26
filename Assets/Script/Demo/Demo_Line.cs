using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Line : MonoBehaviour
{
    public float liveTime;
    public GameObject timeOverSprite;
    public GameObject lineBack;
    public SpriteRenderer tOSSR;
    public SpriteRenderer sR;
    public LineBack lB;
    public bool tOSSRFlg;
    public int randomNum;
    public float closedTime;
    public int lineCount;
    public float scaleX;
    public float scaleY;
    public float scaleUp;
    public Vector3 startPos;
    public float returnTime;
    public Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        liveTime = 0;
        sR = this.GetComponent<SpriteRenderer>();
        startPos = new Vector3(0, -100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == startPos)
        {
            liveTime = 0;
            return;
        }
        liveTime += Time.deltaTime;

        if (liveTime >= returnTime)
        {
            transform.position = startPos;

        }

    }


    public void Remove()
    {
        liveTime = returnTime;
    }

    public void SetLineCount(int num)
    {
        lineCount = num;
    }

    public int GetLineCount()
    {
        return lineCount;
    }

    public void SetDir(Vector2 vec)
    {
        dir = vec;
    }

    public Vector2 GetDir()
    {
        return dir;
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        liveTime = 0;
        // randomNum = Random.Range(0,10000);
        // tOSSR = timeOverSprite.GetComponent<SpriteRenderer>();
        // lB = lineBack.GetComponent<LineBack>();
        // lB.SetRandomNum(randomNum);
        sR = this.GetComponent<SpriteRenderer>();
        // transform.localScale = new Vector3(transform.localScale.x * scaleUp, transform.localScale.y , transform.localScale.x);
        startPos = new Vector3(0,-100,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == startPos)
        {
            liveTime = 0;
            return;
        }
        liveTime += Time.deltaTime;
        /*
        if(tOSSRFlg && liveTime < 0.5f)
        {
            tOSSR.color += new Color(0,0,0,Time.deltaTime * 3);
        }
        
        else if(tOSSRFlg && liveTime >= 0.5f)
        {
            sR.color -= new Color(0,0,0,Time.deltaTime * 3);
            tOSSR.color -= new Color(0,0,0,Time.deltaTime * 3);
        }
        if(liveTime >= 0.7f)
        {
            sR.color -= new Color(0,0,0,Time.deltaTime * 1);
        }
        */
        /*
        if(liveTime < 0.2f)
        {
            if(transform.localScale.y > 0.4f)
            {
                scaleY = 1f * Time.deltaTime;
            }
            else
            {
                scaleY = 0;
            }
            if(transform.localScale.x < 10f)
            {
                scaleX = 0f * Time.deltaTime;
            }
            else
            {
                scaleX = 0;
            }
            transform.localScale = new Vector2(transform.localScale.x + scaleX, transform.localScale.y - scaleY);
        }
        */
        /*2024/02/28
        if(liveTime < 0.4f)
        {
            if(transform.localScale.y < 1f)
            {
                scaleY = 3f * Time.deltaTime;
            }
            else
            {
                scaleY = 0;
            }
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + scaleY);
        }
        if(liveTime >= 0.4f && liveTime < 0.7f)
        {
            if(transform.localScale.y < 0.6f)
            {
                scaleY = 3f * Time.deltaTime;
            }
            else
            {
                scaleY = 0;
            }
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + scaleY);
        }
        2024/02/28*/
        if (liveTime >= returnTime && liveTime <= 1.2f )
        {
            // gameObject.SetActive(false);
            transform.position = startPos;
            
        }
        
    }

/*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("a");
        if(collision.gameObject.tag == "lineBack")
        {
            if(collision.gameObject.GetComponent<LineBack>().GetRandomNum() == randomNum)
            {
                return;
            }
            tOSSRFlg = true;
            // tOSSR.color = new Color(0,0,0,1);
            tOSSR.color = new Color(1,1,1,1);
            Debug.Log("b");
        }
        
    }
*/
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ice":
                // gameObject.SetActive(false);
                break;

            case "Player":
                liveTime = 1f;
                break;

        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Player":
                /*
                closedTime += Time.deltaTime;
                if(closedTime > 0.3f)
                {
                    liveTime = 2f;
                }
                */
                break;
        }
    }

    public void SetLineCount(int num)
    {
        lineCount = num;
    }

    public int GetLineCount()
    {
        return lineCount;
    }




}

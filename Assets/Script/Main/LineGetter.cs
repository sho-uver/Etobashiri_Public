using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGetter : MonoBehaviour
{
    public GameObject player;
    public Player ps;
    public int lineCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(ps.GetChototsuFlg())
        {
            return;
        }

        switch(collision.gameObject.tag)
        {
            case "Line":
                if(lineCount < collision.gameObject.GetComponent<Line>().GetLineCount())
                {
                    lineCount = collision.gameObject.GetComponent<Line>().GetLineCount();
                    ps.BaseSpeedReset();
                }
                ps.SpeedEffect();
                break;           
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(ps.GetChototsuFlg())
        {
            return;
        }

        switch(collision.gameObject.tag)
        {
            case "Line":
                ps.LineGetter(5f * Time.deltaTime);
                break;           
        }
    }

}

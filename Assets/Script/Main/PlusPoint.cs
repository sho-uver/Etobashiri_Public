using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusPoint : MonoBehaviour
{
    public Text plusPoint;
    public Outline outLine;
    public float lifeTime;
    public Vector3 startPos;
    // public Canvas canvas;
    public RectTransform pos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = pos.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 1 && lifeTime > 0)
        {
            plusPoint.color -= new Color(0,0,0,1f * Time.deltaTime);
            outLine.effectColor -= new Color(0,0,0,1f * Time.deltaTime);
        }
        if(lifeTime > 2.75f)
        {
            pos.position = new Vector2(pos.position.x, pos.position.y - 200 * Time.deltaTime);
        }
        
        
    }

    public void Plus(int num)
    {
        lifeTime = 3;
        plusPoint.color =  new Color(0.7f,0.95f,0.7f,1f);
        outLine.effectColor = new Color(0f,0f,0f,1f);
        plusPoint.text = "+" + num + "徳";
        // pos.anchoredPosition = new Vector2(400,-60);
        pos.anchoredPosition = startPos;
    }
}

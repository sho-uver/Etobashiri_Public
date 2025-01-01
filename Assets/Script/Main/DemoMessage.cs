using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoMessage : MonoBehaviour
{
    public Text demoText;
    public float colorNum;
    // Start is called before the first frame update
    void Start()
    {
        colorNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        colorNum += Time.deltaTime;
        if(0 <= colorNum && colorNum < 0.4f)
        {
            demoText.color += new Color(0,0,0,2.5f * Time.deltaTime);
        }
        /*
        if(0.2f < colorNum && colorNum =< 0.8f)
        {
            demoText.color += new Color(0,0,0,2.5f * Time.deltaTime);
        }
        */
        if(0.8f < colorNum && colorNum <= 1.2f)
        {
            demoText.color -= new Color(0,0,0,2.5f * Time.deltaTime);
        }

        if(1.2f < colorNum )
        {
            demoText.color = new Color(1f,1f,1,0);
            colorNum = 0;
        }

        
    }
}

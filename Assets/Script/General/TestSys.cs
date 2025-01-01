using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSys : MonoBehaviour
{
    public GameObject testPly;
    public float actTime;
    public float inActTime;
    public bool actFlg;
    public bool inActFlg;
    // Start is called before the first frame update
    void Start()
    {
        actTime = 0;
        inActTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actTime += Time.deltaTime;
        inActTime += Time.deltaTime;
        if(actTime > 10)
        {
            actFlg = true;
            actTime = 0;
        }

        if(inActTime > 15)
        {
            inActFlg = true;
            inActTime = 0;
        }

        
        

        if(actFlg)
        {
            actFlg = false;
            testPly.SetActive(false);
            Debug.Log("false");
        }

        if(inActFlg)
        {
            testPly.SetActive(true);
            inActFlg = false;
            Debug.Log("true");
        }
    }
}

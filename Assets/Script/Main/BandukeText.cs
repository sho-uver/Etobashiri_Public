using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class BandukeText : MonoBehaviour
{
    // Start is called before the first frame update
    public bool redFlg;
    public Text text;
    public float chikachikaTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!redFlg){return;}
        if(chikachikaTime < 0)
        {
            text.color = new Color(1,0,0,0.5f);
            chikachikaTime = 0.1f;
        }
        else if(chikachikaTime >= 0)
        {
            text.color += new Color(1,0,0,5f * Time.deltaTime);
            chikachikaTime -= Time.deltaTime;
        }
        
    }

    public void SetRedFlg(){
        redFlg = true;
    }
}

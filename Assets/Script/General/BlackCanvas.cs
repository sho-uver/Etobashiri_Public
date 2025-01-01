using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackCanvas : MonoBehaviour
{
    public bool startFlg;
    public bool endFlg;
    public GameObject image;
    public float yPos;
    public bool adFlg;
    // Start is called before the first frame update
    void Start()
    {
        yPos = image.GetComponent<RectTransform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(startFlg && adFlg)
        {
            // image.GetComponent<RectTransform>().position += new Vector3(-1000,0,0) * Time.deltaTime * 1f;
            image.GetComponent<Image>().color -= new Color(0,0,0,1f * Time.deltaTime);
        }
        if(endFlg)
        {
            // image.GetComponent<RectTransform>().position += new Vector3(-1000,0,0) * Time.deltaTime * 1f;
            image.GetComponent<Image>().color += new Color(0,0,0,5f * Time.deltaTime);
        }
        /*
        if(startFlg && image.GetComponent<RectTransform>().position.x < -1000)
        {
            startFlg = false;
            // gameObject.SetActive(false);
        }
        if(endFlg && image.GetComponent<RectTransform>().position.x < 0)
        {
            endFlg = false;
        }
        */
    }

    public void StartFlgTrue()
    {
        startFlg = true;
        if(adFlg)
        {
            Invoke("SetActiveFalse",1f);
        }
        
    }

    public void SetAdFlgTrue()
    {
        adFlg = true;
        if(startFlg)
        {
            Invoke("SetActiveFalse",1f);
        }
    }
    
    public void StartFlgFalse()
    {
        startFlg = false;
    }

    public void EndFlgTrue()
    {
        endFlg = true;
        // image.GetComponent<RectTransform>().position = new Vector3(1500,yPos,0);
    }

    public void SetActiveFalse()
    {
        startFlg = false;
        gameObject.SetActive(false);
    }
}

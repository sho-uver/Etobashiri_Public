using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject pillar;
    public GameObject fireBase;
    public SpriteRenderer baseSP;
    public bool fireFlg;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FirePillar",0.7f);
        baseSP = fireBase.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        baseSP.color -= new Color(0f,0.03f,0.03f,0f);
        if(fireFlg)
        {
            baseSP.color -= new Color(0f,0f,0f,0.01f);
        }
    }

    public void FirePillar()
    {
        fireFlg = true;
        pillar.SetActive(true);
        Invoke("SetActiveFalse",1.5f);
    } 

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}

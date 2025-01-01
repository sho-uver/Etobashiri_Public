using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBase : MonoBehaviour
{
    public bool deleteFlg;
    // Start is called before the first frame update
    void Start()
    {
        deleteFlg = true;
        // Invoke("SetDeleteFlgFalse",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDeleteFlgFalse()
    {
        deleteFlg = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(!deleteFlg)
        {
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                collision.gameObject.GetComponent<Enemy>().Bom();
                break;

            case "Prism":
                collision.gameObject.GetComponent<Roya>().BlowChototsu();
                break;

            case "Warp":
                collision.gameObject.SetActive(false);
                break;

            case "Hole":
                GetComponent<Collider>().gameObject.SetActive(false);
                break;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tori : MonoBehaviour
{
    public bool deleteFlg;
    // Start is called before the first frame update
    void Start()
    {
        deleteFlg = true;
        Invoke("SetDeleteFlgFalse",0.5f);
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
                collision.gameObject.SetActive(false);
                break;

            case "Obstacle":
                collision.gameObject.SetActive(false);
                break;

            case "Hole":
                collision.gameObject.SetActive(false);
                break;

            /*
            case "Tori":
                collision.gameObject.SetActive(false);
                break;
            */

            case "Bubble":
                collision.gameObject.SetActive(false);
                break;

            case "Ice":
                collision.gameObject.SetActive(false);
                break;

            case "SnowBall":
                collision.gameObject.SetActive(false);
                break;

            case "Warp":
                collision.gameObject.SetActive(false);
                break;

            /*
            case "LifeThread":
                collision.gameObject.SetActive(false);
                break;
            */

        }
    }
}

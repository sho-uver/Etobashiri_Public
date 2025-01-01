using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteField : MonoBehaviour
{
    public bool activeFlg;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    public void DeleteFiledActivate()
    {
        activeFlg = true;
    }

    public void DeleteFiledInactivate()
    {
        activeFlg = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(!activeFlg)
        {
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                collision.gameObject.SetActive(false);
                break;

            case "Hole":
                collision.gameObject.SetActive(false);
                break;

            case "Ice":
                collision.gameObject.SetActive(false);
                break;

            case "Warp":
                collision.gameObject.SetActive(false);
                break;

            case "Bubble":
                collision.gameObject.SetActive(false);
                break;
            
            case "SnowBall":
                collision.gameObject.SetActive(false);
                break;

            /*
            case "Fire":
                collision.gameObject.SetActive(false);
                break;
            */

        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(!activeFlg)
        {
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "Obstacle":
                collision.gameObject.SetActive(false);
                break;
        }
    }
}

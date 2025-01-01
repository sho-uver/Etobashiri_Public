using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chinowa : MonoBehaviour
{
    public GameObject player;
    public GameObject mure;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, player.transform.position.y + 12  , 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                if(collision.gameObject.GetComponent<Enemy>().GetBlowFlg())
                {
                    Vector3 murePos = player.transform.position;
                    murePos.y = murePos.y + 12;
                    Instantiate(mure, murePos, transform.rotation);
                }
                break;
        }
        */
    }
}

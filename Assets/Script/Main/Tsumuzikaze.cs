using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsumuzikaze : MonoBehaviour
{
    public GameObject player;
    public Player ps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        // transform.Rotate(0f,0f, 10f);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(ps.GetChototsuFlg())
        {
            return;
        }

        switch(collision.gameObject.tag)
        {
            case "Enemy":
                collision.gameObject.GetComponent<Enemy>().SetJustFlg();
                ps.CollisionEnemy(collision.gameObject);
                break;

            case "MureSymbol":
                ps.CollisionMureSymbol(collision.gameObject);
                break;

            case "Tori":
                ps.CollisionTori(collision.gameObject);
                break;          
            
            case "AmaterasuSymbol":
                ps.CollisionAmaterasuSymbol(collision.gameObject);
                break;   
        }
    }
}

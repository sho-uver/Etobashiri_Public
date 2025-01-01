using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    public GameObject player;
    public Player ps;
    public string name;
    public Vector3 dis;
    // Start is called before the first frame update
    void Start()
    {
        switch(name)
        {
            case "1":
                dis = new Vector3(0, -2f, 0);
                break;

            case "2":
                dis = new Vector3(0, -2.17f, 0);
                break;

            case "3":
                dis = new Vector3(0, -3f, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = dis;
        transform.rotation = player.transform.rotation;
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
                ps.CollisionEnemy(collision.gameObject);
                break;

            case "MureSymbol":
                ps.CollisionMureSymbol(collision.gameObject);
                break;

            case "Tori":
                ps.CollisionTori(collision.gameObject);
                break;            
        }
    }
}

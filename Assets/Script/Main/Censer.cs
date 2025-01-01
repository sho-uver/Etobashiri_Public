using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Censer : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // enemy.SweetSpotON(collision.gameObject.GetComponent<Player>().GetBaseSpeed());
            enemy.MoveFlgOn();
        }
        /*
        if(collision.gameObject.tag == "SpeedEffect")
        {
            
            enemy.SweetSpotON(GameObject.FindWithTag("Player").GetComponent<Player>().GetBaseSpeed());
            enemy.MoveFlgOn();
        }
        */
    }

    /*
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemy.SweetSpotOFF();
            
        }
        
    }
    */
}

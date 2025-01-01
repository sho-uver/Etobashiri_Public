using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Censerprism : MonoBehaviour
{
    public Roya roya;
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
            roya.SweetSpotON();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            return;
        }
        if(collision.gameObject.transform.position.y > transform.position.y)
        {
            // roya.SetActiveFalse();
        }
    }

}

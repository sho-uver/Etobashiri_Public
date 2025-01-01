using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikanPrefab : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        
    }

    /*
    public void OnTriggerStay2D(Collider2D collider)
    {
        
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            Debug.Log("aa");
            gameObject.SetActive(false);
        }
    }
    */

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        switch(collider.gameObject.tag)
        {
            case "Player":
                GetComponent<BoxCollider2D>().enabled = false;
                break;

            case "Enemy":
                collider.gameObject.SetActive(false);
                break;

            case "SnowBall":
                collider.gameObject.SetActive(false);
                break;

            case "Bubble":
                collider.gameObject.SetActive(false);
                break;

            case "Hole":
                collider.gameObject.SetActive(false);
                break;

            case "BigTori":
                gameObject.SetActive(false);
                break;
        }

        
    }
}

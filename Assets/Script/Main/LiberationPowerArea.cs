using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiberationPowerArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
            collision.gameObject.SetActive(false);
            break;

            case "Hole":
            collision.gameObject.SetActive(false);
            break;

            case "Obstacle":
            collision.gameObject.SetActive(false);
            break;

        }
    }
}

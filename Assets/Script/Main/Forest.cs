using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public float speed;
    public float positionX;
    public float positionY;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        positionX = transform.position.x;
        positionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        // positionY += speed;
        // if(player.transform.position.y - transform.position.y > 14.4f)
        if(player.transform.position.y - transform.position.y > 7.2f)
        {
            // positionY = player.transform.position.y + 38.4f;
            // transform.position = new Vector3(positionX, positionY, 1);
            transform.position += new Vector3(positionX, 38.4f, 1);
            // transform.position += new Vector3(positionX, 9.6f, 1);
        }
    }
}

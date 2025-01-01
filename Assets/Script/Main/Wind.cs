using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public GameObject player;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartPosition();
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y > player.transform.position.y - 6f)
        {
            StartPosition();
        }
        distance -= 9 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, player.transform.position.y + distance, transform.position.z);
    }

    public void StartPosition()
    {
        // distance = Random.Range(-9.6f, -19.2f);
        transform.position = new Vector3(player.transform.position.x + Random.Range(-0.5f, 0.5f), player.transform.position.y, 0);
    }
}

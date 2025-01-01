using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(1.0f,2.0f);
        transform.localScale = new Vector3(scale,scale,1);
        transform.position = new Vector3(Random.Range(-1f,1f), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        lifeTime += Time.deltaTime;
        if(lifeTime > 15)
        {
            gameObject.SetActive(false);
        }
        */
    }
}

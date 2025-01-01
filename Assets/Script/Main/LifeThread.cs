using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeThread : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0;
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

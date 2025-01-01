using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicMove : MonoBehaviour
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
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            gameObject.SetActive(false);
        }
        
        transform.localScale = transform.localScale * 1.1f;
        this.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,0.1f);
        
    }
}

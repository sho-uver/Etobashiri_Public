using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            gameObject.SetActive(false);
        }
        
        if(lifeTime > 0.2f)
        {
            transform.localScale = new Vector3(transform.localScale.x / 1.2f,transform.localScale.y,transform.localScale.z);
        }
        
        this.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,0.1f);
        
    }
}

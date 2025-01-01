using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public float lifeTime;
    public bool subFlg;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 1;
        if(subFlg)
        {
            StartCoroutine(ChikaChika());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            gameObject.SetActive(false);
        }
        
        if(lifeTime > 0.7f)
        {
            transform.localScale = transform.localScale * 1.05f;
        }
        if(!subFlg)
        {
            this.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,0.02f);
        }
        // this.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,0.02f);
        
    }

    public IEnumerator ChikaChika()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.8f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.6f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.4f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.3f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.2f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.1f);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWorkUI : MonoBehaviour
{
    public float lifeTime;
    public bool subFlg;
    public bool miniFlg;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 1;
        if(subFlg)
        {
            StartCoroutine(ChikaChika());
        }
        if(!miniFlg)
        {
            transform.localScale = transform.localScale * 0.5f;
        }
        else
        {
            transform.localScale = transform.localScale * 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            gameObject.SetActive(false);
            // lifeTime = 1;
            // Invoke("Again",4);
        }
        
        if(lifeTime > 0.7f && !miniFlg)
        {
            transform.localScale = transform.localScale * 1.05f;
        }
        else if(lifeTime > 0.7f && miniFlg)
        {
            transform.localScale = transform.localScale * 1.05f;
        }
        if(!subFlg)
        {
            this.GetComponent<Image>().color -= new Color(0,0,0,0.02f);
        }
        // this.GetComponent<Image>().color -= new Color(0,0,0,0.02f);
        
    }

    public IEnumerator ChikaChika()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.8f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.6f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.4f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.3f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.2f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.1f);
    }
}

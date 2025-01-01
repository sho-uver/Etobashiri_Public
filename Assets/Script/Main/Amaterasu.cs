using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amaterasu : MonoBehaviour
{
    public GameObject player;
    public Vector3 dis;
    public GameObject rainbow;
    public AudioSource audioSource;
    public float lifeTime;
    public ParticleSystem tokuParticle;
    // Start is called before the first frame update
    void Start()
    {
        SetStartTime();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + dis;
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            StartCoroutine(End());
        }

    }

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                Flare();
                break;         
        }
    }
    */

    public void Flare()
    {
        // Debug.Log("Flare");
        audioSource.Play();
        tokuParticle.Play();
        GameObject obj;
        obj = Instantiate(rainbow,transform.position,transform.rotation);
        obj.transform.SetParent(transform);
    }

    public void SetLifeTime(float num)
    {
        SetStartTime();
        lifeTime += num;
    }

    public IEnumerator End()
    {
        lifeTime = 10;
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        gameObject.SetActive(false);
    }

    public void SetStartTime()
    {
        lifeTime = 10;
    }
}

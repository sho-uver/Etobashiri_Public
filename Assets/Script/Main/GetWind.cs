using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWind : MonoBehaviour
{
    public float lifeTime;
    public bool getFlg;
    public GameObject player;
    public AudioSource audioSource;
    public float tsumuzikazeNum;
    public Vector3 scale;
    public ParticleSystem particle;
    public SpriteRenderer sr;
    public Color clr;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0.5f;
        player = GameObject.FindWithTag("Player");
        sr = this.GetComponent<SpriteRenderer>();
        clr = new Color(0,0,0,0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(getFlg)
        {
            lifeTime -= Time.deltaTime;
            if(transform.localScale.x <= 0)
            {
                transform.localScale = new Vector3(0,0,0);
            }
            else
            {
                transform.localScale -= new Vector3(4,4,4) * Time.deltaTime;
            }

            if(lifeTime < 0)
            {
                gameObject.SetActive(false);
            }
            return;
        }
        */
        /*
        if(transform.localScale.y <= 1)
        {
            scale = new Vector3(0, 1, 0);
        }
        else if(transform.localScale.y > 1.5f)
        {
            scale = new Vector3(0, -1, 0);
        }
        transform.localScale += scale * Time.deltaTime;
        */
        
        transform.Rotate(0f,0f, 5f);
        
        if(!getFlg)
        {
            return;
        }
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            gameObject.SetActive(false);
        }
        
        /*
        if(lifeTime > 0.2f)
        {
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z) * 1.2f;
        }
        */
        
        sr.color -= clr;
        transform.Rotate(0f,0f, 30f);
        
        
    }

    public void Rebirth()
    {
        lifeTime = 0.5f;
        getFlg = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(getFlg)
        {
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "Player":
                audioSource.Play();
                // particle.Play();
                // player = GameObject.FindWithTag("Player");
                player.GetComponent<Player>().GetWind(tsumuzikazeNum);
                getFlg = true;
                break;

            case "SpeedEffect":
                audioSource.Play();
                // particle.Play();
                // player = GameObject.FindWithTag("Player");
                player.GetComponent<Player>().GetWind(tsumuzikazeNum);
                getFlg = true;
                break;

            case "Tsumuzikaze":
                audioSource.Play();
                // particle.Play();
                // player = GameObject.FindWithTag("Player");
                player.GetComponent<Player>().GetWind(tsumuzikazeNum);
                getFlg = true;
                break;

            case "Enemy":
                audioSource.Play();
                // particle.Play();
                // player = GameObject.FindWithTag("Player");
                player.GetComponent<Player>().GetWind(tsumuzikazeNum);
                getFlg = true;
                break;

            case "Mure":
                audioSource.Play();
                // particle.Play();
                // player = GameObject.FindWithTag("Player");
                player.GetComponent<Player>().GetWind(tsumuzikazeNum);
                getFlg = true;
                break;

            case "Prism":
                audioSource.Play();
                // particle.Play();
                // player = GameObject.FindWithTag("Player");
                player.GetComponent<Player>().GetWind(tsumuzikazeNum);
                getFlg = true;
                break;
        }
    }
}

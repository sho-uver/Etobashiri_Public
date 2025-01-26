using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mure : MonoBehaviour
{
    public float speed;
    public float baseSpeed;
    public int gear;
    public bool chototsuFlg;
    public float chototsuSpeed;
    public float chototsuTime;
    public float chototsuBaseSpeed;
    public bool rankingFlg;
    public GameObject player;
    public float accele;
    public float lifeTime;
    public float resetPosTime;
    public AudioSource snowBallAudio;
    public Rigidbody2D rb;
    public ParticleSystem tokuParticle;
    public AudioSource audioSource;
    public AudioClip blowSE;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<CapsuleCollider2D>(), gameObject.GetComponent<CapsuleCollider2D>());
        Input.gyro.enabled = true;
        lifeTime = player.GetComponent<Player>().SetMureLifeTime();
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90,90));
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 pos = transform.position;
        pos.y = player.transform.position.y + 5;
        transform.position = pos;
        Debug.Log(pos);
        */
        lifeTime -= Time.deltaTime;
        resetPosTime += Time.deltaTime;
        if(resetPosTime > 5)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90,90));
            resetPosTime = 0;
        }
        if(lifeTime < 2)
        {
            StartCoroutine(ResetPositionChikaChika());
        }
        if(transform.position.y < player.transform.position.y + 3)
        {
            accele = 1.2f;

            // transform.Translate(Player.instance.PlayerVector() * 1.2f);
            // return;
        }

        if(transform.position.y > player.transform.position.y + 7)
        {
            accele = 0.8f;

            // transform.Translate(Player.instance.PlayerVector() * 0.5f);
            // return;
        }

        if(transform.position.y > player.transform.position.y + 15)
        {
            accele = 0f;
            // transform.Translate(Player.instance.PlayerVector() * 0.5f);
            // return;
        }
        
        if(transform.position.y < player.transform.position.y - 3)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
            // transform.Translate(Player.instance.PlayerVector() * 0.5f);
            // return;
        }

        /*
        if (transform.position.x < -4.5f || transform.position.x > 4.5f )
        {
            Debug.Log("外にいる");
            transform.position = new Vector2(0, player.transform.position.y + 5);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        */
        transform.Translate(Player.instance.PlayerVector() * accele);


        
    }

    public IEnumerator ResetPositionChikaChika()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1f);
        gameObject.SetActive(false);
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(0, player.transform.position.y + 5);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90,90));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                /*
                VibrationMng.ShortVibration();
                collision.GetComponent<Enemy>().Blow(transform.position, transform.up);
                */
                tokuParticle.Play();
                audioSource.PlayOneShot(blowSE);
                break;

            case "Wall":
                // ResetPosition();
                // Debug.Log(transform.rotation.z);
                /*
                if (transform.rotation.z >= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 350);
                    // Debug.Log("右");
                }
                else if (transform.rotation.z < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 10);
                    // Debug.Log("左");
                }
                */
                transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(0 - transform.position.x, 10, transform.position.z));
                transform.position = new Vector3(transform.position.x + (0 - transform.position.x)/5, transform.position.y, transform.position.z);
                
                break;
            /*
            case "Tori":
                collision.gameObject.SetActive(false);
                GameSystem.instance.GetTori("Tori");
                break;

            case "ShiroTori":
                collision.gameObject.SetActive(false);
                GameSystem.instance.GetTori("ShiroTori");
                break;
            
            case "Hude":
                collision.gameObject.SetActive(false);
                GameSystem.instance.GetHude();
                break;

            case "Cleaner":
                ResetPosition();
                break;
            */
            case "Hole":
                ResetPosition();
                break;

            case "Fire":
                ResetPosition();
                break;

            case "LiberationPower":
                GameSystem.instance.StartChototsumoshin();
                collision.gameObject.SetActive(false);
                break;

            case "SnowBall":
                snowBallAudio = GameObject.FindWithTag("SnowBallSound").GetComponent<AudioSource>();
                snowBallAudio.Play();                    
                ResetPosition();
                collision.gameObject.SetActive(false);
                break;

            case "Tori":
                    GameObject.FindWithTag("Player").GetComponent<Player>().CollisionTori(collision.gameObject);
                    break;

            case "MureSymbol":
                    GameObject.FindWithTag("Player").GetComponent<Player>().CollisionMureSymbol(collision.gameObject);
                    break;
        }
    }

    public void InvokeResetBubble()
    {
        Invoke("ResetVelocity",0.3f);
        Invoke("ResetRotation",0.3f);
    }

    public void OnTrigger2D(Collider2D collision)
    {
        
        switch(collision.gameObject.tag)
        {
            case "Wall":
                transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(0 - transform.position.x, 10, transform.position.z));
                // transform.position.x = transform.position.x + (0 - transform.position.x)/5;
                transform.position = new Vector3(transform.position.x + (0 - transform.position.x)/5, transform.position.y, transform.position.z);
                break;
        }
    }

    public void BubbleReset()
    {
        Invoke("BubbleResetNext",0.2f);
    }

    public void BubbleResetNext()
    {
        rb.linearVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.angularVelocity = 0;
    }

}

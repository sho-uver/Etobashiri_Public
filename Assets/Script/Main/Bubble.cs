using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public List<Collider2D> colList;
    public Vector3 distance;
    private Rigidbody2D rb;
    private Vector2 newVelocity;
    public bool moveFlg;
    public bool rightMoveFlg;
    public bool leftMoveFlg;
    public bool burstFlg;
    public AudioSource audioSource;
    public Animator anim;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            moveFlg = true;
        }
        else
        {
            moveFlg = false;
        }
        if (Random.Range(0, 2) == 0)
        {
            rightMoveFlg = true;
        }
        else
        {
            leftMoveFlg = true;
        }
        colList = new List<Collider2D>();
        /*
        scale = Random.Range(1.0f,2.0f);
        transform.localScale = new Vector3(scale,scale,1);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveFlg)
        {
            return;
        }
        if (rightMoveFlg)
        {
            transform.position += new Vector3(1.5f, 0, 0) * Time.deltaTime;
        }

        if (leftMoveFlg)
        {
            transform.position += new Vector3(-1.5f, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x > 2.2f)
        {
            rightMoveFlg = false;
            leftMoveFlg = true;
        }

        if (transform.position.x < -2.2f)
        {
            rightMoveFlg = true;
            leftMoveFlg = false;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (burstFlg)
        {
            return;
        }

        // colList.Add(collision);
        switch (collision.gameObject.tag)
        {
            case "Player":
                burstFlg = true;
                distance = collision.gameObject.transform.position - transform.position;
                // distance.x = distance.x * -1;
                // distance.y = distance.y * -1;
                // collision.transform.Translate(distance * Time.deltaTime * 100);
                rb = collision.gameObject.GetComponent<Rigidbody2D>();
                newVelocity = distance.normalized * 3000;
                rb.linearVelocity = newVelocity;
                // collision.gameObject.transform.position += distance.normalized * 3f;
                // collision.gameObject.GetComponent<Player>().InvokeResetBubble();
                StartCoroutine("Momentum");
                StartCoroutine(Bound(collision.gameObject));
                // Debug.Log(collision.gameObject);
                break;

            case "Mure":
                burstFlg = true;
                distance = collision.gameObject.transform.position - transform.position;
                // distance.x = distance.x * -1;
                // distance.y = distance.y * -1;
                // collision.transform.Translate(distance * Time.deltaTime * 100);
                rb = collision.gameObject.GetComponent<Rigidbody2D>();
                newVelocity = distance.normalized * 3000;
                rb.linearVelocity = newVelocity;
                // collision.gameObject.transform.position += distance.normalized * 3f;
                // collision.gameObject.GetComponent<Player>().InvokeResetBubble();
                StartCoroutine("Momentum");
                StartCoroutine(Bound(collision.gameObject));
                // Debug.Log(collision.gameObject);
                break;


        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (burstFlg)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Player":
                if (collision.gameObject.GetComponent<Player>().GetChototsuFlg())
                {
                    return;
                }
                burstFlg = true;
                distance = collision.gameObject.transform.position - transform.position;
                // distance.x = distance.x * -1;
                // distance.y = distance.y * -1;
                // collision.transform.Translate(distance * Time.deltaTime * 100);
                rb = collision.gameObject.GetComponent<Rigidbody2D>();
                newVelocity = distance.normalized * 30;
                rb.linearVelocity = newVelocity;
                // collision.gameObject.transform.position += distance.normalized * 3f;
                // collision.gameObject.GetComponent<Player>().InvokeResetBubble();
                // StartCoroutine("Momentum");
                collision.gameObject.GetComponent<Player>().BubbleReset();
                StartCoroutine(Bound(collision.gameObject));
                // Debug.Log(collision.gameObject);
                break;

            case "Enemy":
                burstFlg = true;
                // distance = transform.position - collision.transform.position;
                // distance.x = distance.x * -1;
                // distance.y = distance.y * -1;
                // collision.transform.Translate(distance * Time.deltaTime * 100);
                // collision.gameObject.GetComponent<Rigidbody2D>().AddForce(distance.normalized * 30000);
                // collision.gameObject.GetComponent<Player>().InvokeResetBubble();
                // StartCoroutine(Bound2(collision.gameObject));
                StartCoroutine("Momentum");
                break;

            case "Mure":
                burstFlg = true;
                distance = collision.gameObject.transform.position - transform.position;
                rb = collision.gameObject.GetComponent<Rigidbody2D>();
                newVelocity = distance.normalized * 3000;
                rb.linearVelocity = newVelocity;
                // StartCoroutine("Momentum");
                collision.gameObject.GetComponent<Mure>().BubbleReset();
                StartCoroutine(Bound(collision.gameObject));
                break;

        }

    }

    IEnumerator Momentum()
    {
        audioSource.Play();
        anim.SetBool("burst", true);
        yield return new WaitForSeconds(1f);
        /*
        transform.localScale = transform.localScale * 1.5f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = transform.localScale / 1.5f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = transform.localScale * 1.4f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = transform.localScale / 1.4f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = transform.localScale * 1.3f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = transform.localScale / 1.3f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = transform.localScale * 1.2f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = transform.localScale / 1.2f;
        yield return new WaitForSeconds(0.1f);
        */
        burstFlg = false;
        gameObject.SetActive(false);
    }

    IEnumerator Bound(GameObject collision)
    {
        audioSource.Play();
        anim.SetBool("burst", true);
        yield return new WaitForSeconds(0.2f);
        // collision.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        // collision.transform.rotation = Quaternion.Euler(0, 0, 0);
        // collision.GetComponent<Rigidbody2D>().angularVelocity = 0;
        yield return new WaitForSeconds(0.8f);

        burstFlg = false;
        gameObject.SetActive(false);
    }

    IEnumerator Bound2(GameObject collision)
    {
        yield return new WaitForSeconds(0.1f);
        collision.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
        collision.transform.rotation = Quaternion.Euler(0, 0, 0);
        collision.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

}

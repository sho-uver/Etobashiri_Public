using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UriboMenu : MonoBehaviour
{
    public float dirTime;
    public Vector3 dir;
    public bool esaFlg;
    public Vector3 esaPos;
    public GameObject ms;
    public MenuSystem mss;
    // Start is called before the first frame update
    void Start()
    {
        dirTime = 0;
        DirMake();
        mss = ms.GetComponent<MenuSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(esaFlg)
        {
            //transform.position = Vector3.MoveTowards(transform.position, esaPos, 1 * Time.deltaTime);
            return;
        }
        dirTime += Time.deltaTime;
        if(dirTime > 2)
        {
            DirMake();
        }
        // transform.Translate((dir + new Vector2(0,Random.Range(-0.5f, 0.5f))) * Time.deltaTime);
        transform.Translate(dir * Time.deltaTime);
    }

    public void DirMake()
    {
        dir = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0).normalized * Random.Range(1.0f,3.0f);
        if(dir.x > 0)
        {
            transform.localScale = new Vector3(0.1f,0.1f,1);
        }
        else
        {
            transform.localScale = new Vector3(-0.1f,0.1f,1);
        }
        dirTime = 0;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Wall":
                // DirMake();
                // dir = ((collision.gameObject.transform.position - transform.position).normalized * -3 + dir)/2;
                // DirMake();
                /*
                dir = (collision.gameObject.transform.position - transform.position).normalized * -3 / 2;
                if(dir.x > 0)
                {
                    transform.localScale = new Vector3(0.1f,0.1f,1);
                }
                else
                {
                    transform.localScale = new Vector3(-0.1f,0.1f,1);
                }
                dirTime = 0;
                */
                break;

        }
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Wall":
                dir = dir * -1;
                // DirMake();
                // dir = ((collision.gameObject.transform.position - transform.position).normalized * -3 + dir)/2;
                // DirMake();
                /*
                dir = (collision.gameObject.transform.position - transform.position).normalized * -3 / 2;
                */
                if(dir.x > 0)
                {
                    transform.localScale = new Vector3(0.1f,0.1f,1);
                }
                else
                {
                    transform.localScale = new Vector3(-0.1f,0.1f,1);
                }
                DirMake();
                // dirTime = 0;
                
                break;

        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Mikan":
                esaPos = collision.gameObject.transform.position;
                mss.UpdateLevel(1);
                //esaFlg = true;
                break;
            
        }
        // Invoke("SetEsaFlgFalse",0.1f);
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Mikan":
                esaFlg = false;
                break;
        }
        
    }

    public void SetEsaFlgFalse()
    {
        esaFlg = false;
    }

}

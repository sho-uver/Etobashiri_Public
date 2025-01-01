using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject pair;
    public GameObject player;
    public bool warpFlg;
    public Warp pairWarpComponent;
    public AudioSource warpAudio;
    // Start is called before the first frame update
    void Start()
    {
        pairWarpComponent = pair.GetComponent<Warp>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.GetComponent<Player>().GetChototsuFlg() || warpFlg)
        {
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "Player":
                warpAudio.Play();
                pairWarpComponent.SetWarpFlgTrue();
                collision.gameObject.transform.position = new Vector3(pair.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                break;

            case "Enemy":
                pairWarpComponent.SetWarpFlgTrue();
                warpAudio.Play();
                collision.gameObject.transform.position = new Vector3(pair.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                break;
        }

        /*
        if (player.GetComponent<Player>().GetChototsuFlg())
        {
            return;
        }
        if (collision.gameObject.tag == "Player" && !warpFlg)
        {
            // Debug.Log(3);
            // SetWarpFlgTrue();
            pairWarpComponent.SetWarpFlgTrue();
            collision.gameObject.transform.position = new Vector3(pair.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
        }
        */
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (player.GetComponent<Player>().GetChototsuFlg() || !warpFlg)
        {
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "Player":
                SetWarpFlgFalse();
                // Invoke("SetActiveFalse",0.05f);
                break;

            case "Enemy":
                SetWarpFlgFalse();
                // Invoke("SetActiveFalse",0.05f);
                break;
        }
        /*
        if (player.GetComponent<Player>().GetChototsuFlg())
        {
            return;
        }
        if (collision.gameObject.tag == "Player" && warpFlg)
        {
            // Debug.Log(6);
            SetWarpFlgFalse();
            // pairWarpComponent.SetWarpFlgFalse();
            
        }
        Invoke("SetActiveFalse",0.05f);
        */
    }

    public void SetWarpFlgTrue()
    {
        warpFlg = true;
    }

    public void SetWarpFlgFalse()
    {
        warpFlg = false;
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}

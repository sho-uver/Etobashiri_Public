using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    public bool chototsuFlg;
    public bool blowFlg;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(distance > 4.2f)
        {
            distance = 4.2f;
        }
        if(distance < 4.2f)
        {
            distance += 1f * Time.deltaTime;
        }
        
        if(chototsuFlg)
        {
            transform.position = new Vector3(player.transform.position.x + Random.Range(-0.1f, 0.1f), player.transform.position.y + distance + Random.Range(-0.1f, 0.1f), -22);
            return;
        }
        if(blowFlg)
        {
            // transform.position = new Vector3(Random.Range(-0.1f, 0.1f), player.transform.position.y + distance + Random.Range(-0.1f, 0.1f), -22);
            transform.position = new Vector3(Random.Range(-0.2f, 0.2f), player.transform.position.y + distance, -22);
            return;
        }
        transform.position = new Vector3(0, player.transform.position.y + distance , -22);
        
        
    }

    public void Chototsumoshin()
    {
        chototsuFlg = true;
    }

    public void EndChototsumoshin()
    {
        chototsuFlg = false;
    }

    public void BlowStart()
    {
        blowFlg = true;
        Invoke("BlowEnd", 0.1f); 
    }

    public void LostLifeStart()
    {
        blowFlg = true;
        Invoke("BlowEnd", 0.3f); 
    }

    public void BlowEnd()
    {
        blowFlg = false;
    }

    public void PlayerOnIce()
    {
        distance -= 10f * Time.deltaTime;
    }

}

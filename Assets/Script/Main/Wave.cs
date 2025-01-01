using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Vector3 waveMove;
    public float waveVector;
    public string LR;
    public int pattern;
    public WaveSet waveSet;
    public bool moveFlg;
    // Start is called before the first frame update
    void Start()
    {
        pattern = Random.Range(1,4);
    }

    // Update is called once per frame
    void Update()
    {
        switch(LR)
        {
            case "Left":
                LWaveMove();
                if(transform.position.x < -10)
                {
                    ChangeMoveFlg();
                    return;
                }
                break;
            
            case "Right":
                RWaveMove();
                if(transform.position.x > 10)
                {
                    ChangeMoveFlg();
                    return;
                }
                break;
        }
        if(!moveFlg)
        {
            return;
        }
        transform.Translate(waveMove);
    }

    public void LWaveMove()
    {
        waveVector -= 0.02f;
        /*
        if(transform.position.x <= -10f && pattern == 1)
        {
            waveVector = 2.5f;
            pattern = Random.Range(1,4);
        }
        else if(transform.position.x <= -10f && pattern == 2)
        {
            waveVector = 3f;
            pattern = Random.Range(1,4);
        }
        else if(transform.position.x <= -10f && pattern == 3)
        {
            waveVector = 3.5f;
            pattern = Random.Range(1,4);
        }
        */
        if(transform.position.x <= -10f)
        {
            waveVector = 4f;
        }
        waveMove = new Vector3(waveVector, 0, 0) * Time.deltaTime;
    }

    public void RWaveMove()
    {
        waveVector += 0.02f;
        /*
        if(transform.position.x >= 10f && pattern == 1)
        {
            waveVector = -2.5f;
            pattern = Random.Range(1,4);
        }
        else if(transform.position.x >= 10f && pattern == 2)
        {
            waveVector = -3f;
            pattern = Random.Range(1,4);
        }
        else if(transform.position.x >= 10f && pattern == 3)
        {
            waveVector = -3.5f;
            pattern = Random.Range(1,4);
        }
        */
        if(transform.position.x >= 10f)
        {
            waveVector = -4f;
        }
        waveMove = new Vector3(waveVector, 0, 0) * Time.deltaTime;
        /*
        else if(transform.position.x <= 6f)
        {
            waveMove = new Vector3(1f, 0, 0) * Time.deltaTime;
        }
        */
    }

    public void SetMoveFlgTrue()
    {
        moveFlg = true;
    }

    public void ChangeMoveFlg()
    {
        moveFlg = false;
        switch(LR)
        {
            case "Left":
                transform.position = new Vector3(-10, transform.position.y, transform.position.z);
                waveSet.SetMoveFlgTrueR();
                break;

            case "Right":
                transform.position = new Vector3(10, transform.position.y, transform.position.z);
                waveSet.SetMoveFlgTrueL();
                break;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
                        
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                /*
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.1f, Space.World);
                */
                collision.gameObject.GetComponent<Enemy>().OnWave(waveVector,LR);
            // Debug.Log("a");
                break;

            case "Obstacle":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.1f, Space.World);
                break;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
                        
        switch(collision.gameObject.tag)
        {
            /*
            case "Enemy":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.1f, Space.World);
            // Debug.Log("a");
                break;
            */
            case "Obstacle":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.1f, Space.World);
                break;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
                        
        switch(collision.gameObject.tag)
        {
            
            case "Enemy":
                /*
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.1f, Space.World);
            // Debug.Log("a");
                */
                collision.gameObject.GetComponent<Enemy>().OnWave(0,"");
                break;

            case "Obstacle":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.1f, Space.World);
                break;
        }
    }

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
                        
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.08f, Space.World);
            // Debug.Log("a");
                break;

            case "Obstacle":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.08f, Space.World);
                break;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
                        
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.08f, Space.World);
            // Debug.Log("a");
                break;

            case "Obstacle":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.08f, Space.World);
                break;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
                        
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.08f, Space.World);
            // Debug.Log("a");
                break;

            case "Obstacle":
                if(collision.transform.position.x >= 2f && waveMove.x >= 0)
                {
                    return;
                }
                if(collision.transform.position.x <= -2f && waveMove.x <= 0)
                {
                    return;
                }
                collision.transform.Translate(waveMove * 0.08f, Space.World);
                break;
        }
    }
    */
}
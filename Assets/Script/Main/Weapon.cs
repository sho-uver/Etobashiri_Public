using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public int life;
    public Text lifeUI;
    public GameObject player;
    public float lifeTime;
    public int attackPoint;
    public string name;
    public bool rightMoveFlg;
    public bool leftMoveFlg;
    public bool frontMoveFlg;
    public bool backMoveFlg;
    public Vector3 startPosition;
    public int flgJudgeNum;
    public Animator weaponAnim;
    public bool blowFlg;
    public Vector3 blowingDir;
    public bool rankingFlg;
    public bool justFlg;
    public GameObject center;
    public Canvas getPoint;
    public int point;
    public bool bomFlg;
    public Canvas getPointIns;
    // public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(blowFlg)
        {
            transform.position += blowingDir.normalized * Time.deltaTime * 25;
            if(getPointIns != null)
            {
                getPointIns.transform.position += blowingDir.normalized * Time.deltaTime * 25;
            }
            return;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(bomFlg)
        {
            return;
        }

        switch(collision.gameObject.tag)
        {
            case "Enemy":
                /*
                blowFlg = true;
                justFlg = true;
                blowingDir = ((center.transform.position - collision.gameObject.GetComponent<Enemy>().center.transform.position) + blowingDir);
                GetPoint(2);
                Invoke("Bom", 3f);
                switch(name)
                {
                    case "mochi":
                    weaponAnim.SetBool("BlowFlg", true);
                    break;
                }
                */
                break;

            case "Weapon":
                /*
                blowFlg = true;
                justFlg = true;
                blowingDir = ((center.transform.position - collision.gameObject.GetComponent<Weapon>().center.transform.position) + blowingDir);
                GetPoint(2);
                Invoke("Bom", 3f);
                switch(name)
                {
                    case "mochi":
                    weaponAnim.SetBool("BlowFlg", true);
                    break;
                }
                */
                break;

            case "LifeThread":
                if(justFlg)
                {
                    if(rankingFlg)
                    {
                        GameSystem.instance.Critical();
                        GameSystem.instance.GetLifeThread();
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                        GameSystemTrick.instance.GetLifeThread();
                    }
                    collision.gameObject.SetActive(false);
                    return;
                }
                collision.gameObject.SetActive(false);
                break;

            case "Tori":
                if(justFlg)
                {
                    if(rankingFlg)
                    {
                        GameSystem.instance.Critical();
                        GameSystem.instance.GetTori("Tori");
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                        GameSystemTrick.instance.GetTori("Tori");
                    }
                    collision.gameObject.SetActive(false);
                    return;
                }
                collision.gameObject.SetActive(false);
                break;

            case "ShiroTori":
                if(justFlg)
                {
                    if(rankingFlg)
                    {
                        GameSystem.instance.Critical();
                        GameSystem.instance.GetTori("ShiroTori");
                    }
                    else
                    {
                        GameSystemTrick.instance.Critical();
                        GameSystemTrick.instance.GetTori("ShiroTori");
                    }
                    collision.gameObject.SetActive(false);
                    return;
                }
                collision.gameObject.SetActive(false);
                break;

            case "Obstacle":
                GetPoint(1);
                blowingDir = ((center.transform.position - collision.gameObject.transform.position) + blowingDir);
                break;

            case "Wall":
                if(blowFlg)
                {
                    blowingDir = new Vector3(blowingDir.x * -1, blowingDir.y, blowingDir.z);
                    GetPoint(1);
                    return;
                }
                break;

            case "Cleaner":
                if (blowFlg)
                {
                    SetActiveFalse();
                    return;
                }
                if(rankingFlg)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;

            case "BoundWall":
                if(blowFlg)
                {
                    blowingDir = new Vector3(blowingDir.x , blowingDir.y * -1, blowingDir.z);
                    GetPoint(1);
                    return;
                }
                break;

            case "JackPod":
                GetPoint(10);
                Debug.Log("1000");
                break;
        }
    }

    public void Blow(Vector3 playerPos, Vector3 playerDir)
    {
        if (blowFlg)
        {
            return;
        }
        blowingDir = center.transform.position - playerPos;
        blowFlg = true;
        Vector3 a = blowingDir.normalized;
        Vector3 b = playerDir.normalized;

        justFlg = true;
        Invoke(nameof(Bom), 3f);
        
        if(rankingFlg)
        {
            GameSystem.instance.Critical();
        }
        else
        {
            GameSystemTrick.instance.Critical();
        }
        GetPoint(2);
        switch(name)
        {
            case "mochi":
            weaponAnim.SetBool("BlowFlg", true);
            break;
        }
    }


    public void Bom()
    {
        bomFlg = true;
        // GetPoint(1);
        blowingDir = new Vector3(0, 0, 0);

        Invoke(nameof(SetActiveFalse), 0.5f);
    }

    public void SetActiveFalse()
    {
        if(rankingFlg)
        {

        }
        else
        {
            GameSystemTrick.instance.GetPoint(point);
        }
        point = 0;
        switch(name)
        {
            case "mochi":
            weaponAnim.SetBool("BlowFlg", false);
            break;
        }
        blowFlg = false;
        justFlg = false;
        bomFlg = false;
        gameObject.SetActive(false);
        
    }

    IEnumerator ResetTime() 
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1f;
    }    

    public void GetPoint(int num)
    {
        if (point == -100)
        {
            return;
        }
        point += num;

        if(getPointIns == null)
        {
            getPointIns = Instantiate(getPoint, transform.position + new Vector3(0,1,0), Quaternion.identity);
            // getPointIns.transform.SetParent(this.gameObject.transform);
        }
        getPointIns.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "+" + point;
        getPointIns.GetComponent<GetPoint>().SetLifeTimeLimit(5);
        /*
        Canvas canvas = Instantiate(getPoint, transform.position + new Vector3(0,3,0), Quaternion.identity);
        canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "+" + point;
        */
        /*
        if(point == 1)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.5f,0.5f,0.5f,1f);
        }
        if(point == 2)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.86f,0.86f,0.86f,1f);
        }
        if(point == 3)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.86f,0.86f,0.86f,1f);
        }
        if(point == 4)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.9f,0.96f,0.96f,1f);
        }
        if(point == 5)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.94f,0.94f,0.56f,1f);
        }
        if(point == 6)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.94f,0.94f,0f,1f);
        }
        if(point == 7)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.92f,0.37f,0f,1f);
        }
        if(point == 8)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.92f,0f,0f,1f);
        }
        if(point == 9)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.19f,0.38f,0.96f,1f);
        }
        if(point == 10)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.18f,0.18f,0.55f,1f);
        }
        if(point == 11)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.75f,0.56f,0.95f,1f);
        }
        if(point >= 12)
        {
            canvas.GetComponent<Transform>().GetChild(0).GetComponent<Text>().color = new Color(0.5f,0,0.5f,1f);
        }
        */
        /*
        if(rankingFlg)
        {

        }
        else
        {
            GameSystemTrick.instance.GetPoint(point);
        }
        */
    }

    public bool GetBlowFlg()
    {
        return blowFlg;
    }
}

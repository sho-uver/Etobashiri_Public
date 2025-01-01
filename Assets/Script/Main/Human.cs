using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{    
    public bool lostFlg;
    public float restTime;
    public Animator humanAnim;
    public Vector3 startPos;
    public Quaternion initialRotation;

    void Start()
    {
        startPos = transform.localPosition;
        initialRotation = transform.rotation;
    }



    void Update()
    {
        if(!lostFlg)
        {
            return;
        }
        restTime -= Time.deltaTime;
        if(restTime > 0.55f)
        {
            transform.position += new Vector3(0, 10, 0)  * Time.deltaTime;
        }
        else if(restTime <= 0.55f)
        {
            transform.position -= new Vector3(0, 5, 0)  * Time.deltaTime;
        }
        
        /*
        transform.localScale += new Vector3(100f, 100f, 0)  * Time.deltaTime;
        transform.Rotate (0f, 0f, 10.0f);
        */
        if(restTime < 0)
        {
            gameObject.SetActive(false);
        }
        

    }
    public void Lost()
    {
        lostFlg = true;
        humanAnim.SetBool("BomFlg", true);
        GetComponent<Renderer>().sortingOrder = 100;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnEnable()
    {
        lostFlg = false;
        humanAnim.SetBool("BomFlg", false);
        transform.localPosition = startPos;
        transform.rotation = initialRotation;
    }

}


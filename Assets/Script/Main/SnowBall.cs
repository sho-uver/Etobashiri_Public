using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public bool moveFlg;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(0.6f,1.0f);
        transform.localScale = new Vector3(scale,scale,1);
        transform.position = new Vector3(Random.Range(-2f,2f), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveFlg)
        {
            transform.Translate(Vector3.up * -1.5f * Time.deltaTime);
        }
        
    }

    public void MoveFlgOn()
    {
        moveFlg = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                gameObject.SetActive(false);
                break;

        }
    }
}

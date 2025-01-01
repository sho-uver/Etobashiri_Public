using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetSpot : MonoBehaviour
{
    public Enemy enemy;
    public SpriteRenderer renderer;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        time += Time.deltaTime;
        if(0.5f < time && time <1f)
        {
            renderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        if(1f < time && time <1.5f)
        {
            renderer.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        }
        if(1.5f < time)
        {
            time = 0;
        }
        */
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemy.SetJustFlg();
        }
        if(collision.gameObject.tag == "SpeedEffect")
        {
            enemy.SetJustFlg();
        }
    }
}

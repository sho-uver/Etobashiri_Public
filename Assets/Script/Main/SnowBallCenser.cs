using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallCenser : MonoBehaviour
{
    public SnowBall snowBall;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            snowBall.MoveFlgOn();
            particle.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Enemy : MonoBehaviour
{
    public Animator bomberAnim;
    public AudioSource audioSource;
    public AudioClip bomSE;
    public ParticleSystem tokuParticle;

    void Start()
    {
    }

    void Update()
    {
    }

    public void Bom()
    {
        audioSource.PlayOneShot(bomSE);
        tokuParticle.Play();
        bomberAnim.SetBool("BomFlg", true);
        Invoke(nameof(SetActiveFalse), 0.5f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("きた");
            Demo_Step3.Instance.PlayerCollisionEnemy();
            Bom();
        }

    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
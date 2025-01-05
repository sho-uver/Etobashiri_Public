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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("きた");
            Bom();
        }

    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
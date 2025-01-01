using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DemoBomb : MonoBehaviour
{
    public ParticleSystem tokuParticle;
    public AudioSource audioSource;
    public Animator bomberAnim;
    public AudioClip bomSE;
    public SpriteRenderer sr;
    public float time;
    public SpriteRenderer shadow;
    public bool bomFlg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveFalse()
    {
        bomberAnim.SetBool("BomFlg", false);
        // gameObject.SetActive(false);
        sr.color = new Color(1f,1f,1f,0f);
        shadow.color = new Color(0f,0f,0f,0f);
        Invoke(nameof(SetActiveTrue),time);
    }

    public void SetActiveTrue()
    {
        bomFlg = false;
        sr.DOFade(1f, 0.5f);
        shadow.DOFade(0.3f, 0.5f);
        /*
        sr.color = new Color(1f,1f,1f,1f);
        shadow.color = new Color(0f,0f,0f,0.3f);
        */
    }

    public void Bom()
    {
        if(bomFlg)
        {
            return;
        }
        bomFlg = true;
        // audioSource.PlayOneShot(bomSE);
        tokuParticle.Play();
        bomberAnim.SetBool("BomFlg", true);
        Invoke(nameof(SetActiveFalse), 0.5f);
    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "DemoPlayer")
        {
            Bom();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip soundEffect;  // 再生する効果音

    public AudioSource audioSource;
    public AudioSource fudeSound;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
    }

    public void PlaySound()
    {
        // audioSource.clip = soundEffect;
        audioSource.Play();
    }

    public void StopFudeSound()
    {
        fudeSound.Stop();   
    }
}

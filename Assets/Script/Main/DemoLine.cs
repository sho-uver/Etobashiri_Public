using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLine : MonoBehaviour
{
    public float time;
    public SpriteRenderer sr;
    public Color colorS;
    public Color colorE;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        colorS = new Color(1,1,1,1);
        colorE = new Color(1,1,1,0);
        ColorFalse();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ColorTrue()
    {
        sr.color = colorS;
        Invoke(nameof(ColorFalse),time);
    }

    public void ColorFalse()
    {
        sr.color = colorE;
    }
}

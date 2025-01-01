using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoLineCtrl : MonoBehaviour
{
    public DemoLine dl1;
    public DemoLine dl2;
    public DemoLine dl3;
    public DemoLine dl4;
    public DemoLine dl5;
    public DemoLine dl6;
    public DemoLine dl7;
    public DemoLine dl8;
    public DemoLine dl9;
    public DemoLine dl10;
    public DemoLine dl11;
    public DemoLine dl12;
    public float time1;
    public float time2;
    public float time3;
    public float time4;
    public float time5;
    public float time6;
    public float time7;
    public float time8;
    public float time9;
    public float time10;
    public float time11;
    public float time12;
    public float time13;
    public DemoPlayer dp;
    public SShapeMovement sm;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LineSpawn");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator LineSpawn()
    {
        dp.MySequence();
        sm.MySequence();
        yield return new WaitForSeconds(time1);
        dl1.ColorTrue();

        yield return new WaitForSeconds(time2);
        dl2.ColorTrue();

        yield return new WaitForSeconds(time3);
        dl3.ColorTrue();

        yield return new WaitForSeconds(time4);
        dl4.ColorTrue();

        yield return new WaitForSeconds(time5);
        dl5.ColorTrue();

        yield return new WaitForSeconds(time6);
        dl6.ColorTrue();

        yield return new WaitForSeconds(time7);
        dl7.ColorTrue();

        yield return new WaitForSeconds(time8);
        dl8.ColorTrue();

        yield return new WaitForSeconds(time9);
        dl9.ColorTrue();

        yield return new WaitForSeconds(time10);
        dl10.ColorTrue();

        yield return new WaitForSeconds(time11);
        dl11.ColorTrue();

        yield return new WaitForSeconds(time12);
        dl12.ColorTrue();

        yield return new WaitForSeconds(time13);
        StartCoroutine("LineSpawn");
    }


}

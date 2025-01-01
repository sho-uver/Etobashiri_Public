using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvas : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject startButton;
    public GameObject guidButton;
    public GameObject closeButton;
    public GameObject stampPanel;
    public GameObject stampOpenButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuidOpen()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
        startButton.SetActive(false);
        guidButton.SetActive(false);
        stampOpenButton.SetActive(false);
        closeButton.SetActive(true);
    }

    public void GuidClose()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        startButton.SetActive(true);
        guidButton.SetActive(true);
        stampOpenButton.SetActive(true);
        closeButton.SetActive(false);
    }

    public void StampOpen()
    {
        startButton.SetActive(false);
        guidButton.SetActive(false);
        stampOpenButton.SetActive(false);
        stampPanel.SetActive(true);
    }

    public void StampClose()
    {
        startButton.SetActive(true);
        guidButton.SetActive(true);
        stampOpenButton.SetActive(true);
        stampPanel.SetActive(false);
    }

    public void Panel1()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    public void Panel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        panel3.SetActive(false);
    }

    public void Panel3()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

}

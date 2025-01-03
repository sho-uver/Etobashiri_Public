using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stamp : MonoBehaviour
{
    public GameObject invisible;
    public GameObject stamp;
    public string name;
    public string startName;
    public Text text;
    public GameObject invisibleText;
    public GameObject visibleText;
    // Start is called before the first frame update
    void Start()
    {
        startName = name;
        name += "春夏秋冬並木";
        Display();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Display();
    }

    public void Display()
    {
        if (PlayerPrefs.GetInt(name, 0) == 1)
        {
            invisible.SetActive(false);
        }
    }
}
